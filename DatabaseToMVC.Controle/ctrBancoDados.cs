using DatabaseToMVC.Modelo;
using DatabaseToMVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToMVC.Controle
{
    public class ctrBancoDados
    {
        private const string conSQLConsutar = " select * from sys.databases where name not in ('master', 'tempdb', 'model', 'msdb')";
        private string[] conUsings = { "using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Text;", "using System.Threading.Tasks;", "using System.Data;" };
        

        private List<mdoTabelas> listaTabelas = new List<mdoTabelas>();
        private List<mdoColunas> listaColunas = new List<mdoColunas>();

        public List<String> ListarBancoDados()
        {
            var lista = new List<String>();
            var objPerBancoDados = new perBancoDados();

            var datBancos = objPerBancoDados.executaConsulta(conSQLConsutar, mdoBancoDados.ConnectionString);
            foreach (DataRow objRow in datBancos.Rows)
            {
                lista.Add(objRow["name"].ToString());
            }
            return lista;
        }

        public void IniciarExportacao(List<mdoTabelas> listaTabelas)
        {
            this.listaTabelas = listaTabelas;
            if (mdoBancoDados.ExportarModelos)
            {
                ExportarModelos();
            }

            if (mdoBancoDados.ExportarControles)
            {
                ExportarControles();
            }

            System.Diagnostics.Process.Start("explorer.exe", mdoBancoDados.DiretorioDestino);
        }

        private void ExportarControles()
        {
            var objCtrColunas = new ctrColunas();
            foreach (var objTabela in listaTabelas)
            {
                if (!objTabela.tblSelecionada)
                    continue;

                OnFollowUp(String.Format("Escrevendo controle para a tabela: {0}", objTabela.tblNome));

                var stb = new StringBuilder();
                listaColunas = objCtrColunas.ListarColunas(objTabela.tblNome);

                //Padrão Cambel Case
                var sNomeClasse = objTabela.tblNome.Replace("tbl", string.Empty);
                if (mdoBancoDados.RemoverDeclaracaoView)
                {
                    sNomeClasse = sNomeClasse.Replace("view", string.Empty).Replace("vw", string.Empty).Replace("vw_", string.Empty);
                }

                #region Cria classe de controle
                sNomeClasse = sNomeClasse.Substring(0, 1).ToUpper() + sNomeClasse.Substring(1, sNomeClasse.Length - 1);
                sNomeClasse = "ctr" + sNomeClasse;

                //Adiciona as usings
                foreach (string sUsing in conUsings)
                    stb.AppendLine(sUsing);

                stb.AppendLine(String.Format("using {0}.Persistencia;", mdoBancoDados.Namespace));
                stb.AppendLine(String.Format("using {0}.Modelos;", mdoBancoDados.Namespace));


                //Cria o namespace
                stb.AppendLine(string.Empty);
                stb.AppendLine(String.Format("namespace {0}.Controles", mdoBancoDados.Namespace));
                stb.AppendLine("{");

                //Cria a classe
                stb.AppendLine(String.Format("    public class {0}", sNomeClasse));
                stb.AppendLine("    {");
                stb.AppendLine("        perComando comando = new perComando();");
                stb.AppendLine(string.Empty);

                //Escreve os métodos padrões (Buscar, Inserir, Alterar e Excluir)
                EscreverMetodos(stb, sNomeClasse.Replace("ctr", string.Empty), objTabela, listaColunas);

                stb.AppendLine("    }");
                stb.AppendLine("}");

                OnFollowUp(String.Format("Criando arquivo para a tabela: {0}", objTabela.tblNome));
                OnFollowUp(string.Empty);
                GerarArquivo(stb.ToString(), "Controles", sNomeClasse);
                #endregion
            }

            OnFollowUp(string.Empty);
            OnFollowUp("Exportação das classes de controle concluída.");
            OnFollowUp(string.Empty);
        }
        
        private void EscreverMetodos(StringBuilder stb, string sNomeClasse, mdoTabelas objTabela, List<mdoColunas> objListColunas)
        {
            EscreverMetodoBuscar(stb, sNomeClasse, objTabela, objListColunas);
            EscreverMetodoInserir(stb, sNomeClasse, objTabela, objListColunas);
            EscreverMetodoAlterar(stb, sNomeClasse, objTabela, objListColunas);
            EscreverMetodoExcluir(stb, sNomeClasse, objTabela);
        }


        private void EscreverMetodoBuscar(StringBuilder stb, string sNomeClasse, mdoTabelas objTabela, List<mdoColunas> objListColunas)
        {
            stb.AppendLine("        public object Buscar(String parametroSQL)");
            stb.AppendLine("        {");
            stb.AppendLine("            try");
            stb.AppendLine("            {");
            stb.AppendLine("                String stringSQL = String.Format(\"SELECT * FROM @tabela {0} ORDER BY 1 ASC\", parametroSQL);".Replace("@tabela", objTabela.tblNome));
            stb.AppendLine(String.Format("                var obj{0}Lista = new mdo{1}Lista();", sNomeClasse, sNomeClasse));
            stb.AppendLine(String.Format("                DataTable dataTable{0} = comando.executaConsulta(stringSQL);", sNomeClasse));
            stb.AppendLine(string.Empty);
            stb.AppendLine(String.Format("                foreach (DataRow linha in dataTable{0}.Rows)", sNomeClasse));
            stb.AppendLine("                {");
            stb.AppendLine(String.Format("                    var obj{0} = new mdo{1}();", sNomeClasse, sNomeClasse));
            foreach (var objColuna in listaColunas)
            {
                stb.AppendLine(String.Format("                    obj{0}.{1} = Convert.To{2}(linha[\"{3}\"]);", sNomeClasse, objColuna.colNome, ctrColunas.ObterTipoColuna(objColuna).Replace("?", ""), objColuna.colNome));
            }
            stb.AppendLine(String.Format("                    obj{0}Lista.Add(obj{1});", sNomeClasse, sNomeClasse));
            stb.AppendLine("                }");
            stb.AppendLine(String.Format("                return obj{0}Lista;", sNomeClasse));
            stb.AppendLine("            }");
            stb.AppendLine("            catch (Exception exception)");
            stb.AppendLine("            {");
            stb.AppendLine("                throw new Exception(exception.Message);");
            stb.AppendLine("            }");
            stb.AppendLine("        }");
            stb.AppendLine(string.Empty);

        }

        private void EscreverMetodoInserir(StringBuilder stb, string sNomeClasse, mdoTabelas objTabela, List<mdoColunas> objListColunas)
        {
            var sCampos = "(";
            var sParametros = "(";

            foreach (var objColuna in objListColunas)
            {
                sCampos += objColuna.colNome + ", ";
                sParametros += "@" + objColuna.colNome + ", ";
            }
            sCampos = sCampos.Substring(0, sCampos.Trim().Length - 1) + ")";
            sParametros = sParametros.Substring(0, sParametros.Trim().Length - 1) + ")";

            stb.AppendLine(String.Format("        public void Incluir(mdo{0} obj)", sNomeClasse));
            stb.AppendLine("        {");
            stb.AppendLine("            try");
            stb.AppendLine("            {");
            stb.AppendLine("                StringBuilder ParametroSQL = new StringBuilder();");
            stb.AppendLine(string.Empty);
            stb.AppendLine(String.Format("                ParametroSQL.Append(\"INSERT INTO {0} \");", objTabela.tblNome));
            stb.AppendLine(String.Format("                ParametroSQL.Append(\"{0}\");", sCampos));
            stb.AppendLine("                ParametroSQL.Append(\" VALUES \");");
            stb.AppendLine(String.Format("                ParametroSQL.Append(\"{0}\");", sParametros));
            stb.AppendLine(string.Empty);
            stb.AppendLine("                comando.limparParametros();");
            foreach (var objColuna in objListColunas)
            {
                stb.AppendLine(String.Format("                comando.adicionarParametros(\"@{0}\", obj.{1});", objColuna.colNome, objColuna.colNome));
            }
            stb.AppendLine("                comando.executaComando(ParametroSQL.ToString());");
            stb.AppendLine("            }");
            stb.AppendLine("            catch (ConstraintException)");
            stb.AppendLine("            {");
            stb.AppendLine("                throw new Exception(\"Registros duplicados. Usuário já cadastrado.\");");
            stb.AppendLine("            }");
            stb.AppendLine("            catch (Exception exception)");
            stb.AppendLine("            {");
            stb.AppendLine("                throw new Exception(exception.Message);");
            stb.AppendLine("            }");
            stb.AppendLine("        }");
            stb.AppendLine(string.Empty);
        }

        private void EscreverMetodoAlterar(StringBuilder stb, string sNomeClasse, mdoTabelas objTabela, List<mdoColunas> objListColunas)
        {
            stb.AppendLine(String.Format("        public void Alterar(mdo{0} obj)", sNomeClasse));
            stb.AppendLine("        {");
            stb.AppendLine("            try");
            stb.AppendLine("            {");
            stb.AppendLine("                StringBuilder ParametroSQL = new StringBuilder();");
            stb.AppendLine(string.Empty);
            stb.AppendLine(String.Format("                ParametroSQL.Append(\"UPDATE {0} SET \");", objTabela.tblNome));

            var sChavePrimaria = new ctrColunas().ObterColunaChavePrimaria(objTabela.tblNome);
            foreach (var objColunas in objListColunas)
            {
                if (objColunas.colNome.Equals(sChavePrimaria))
                    continue;

                if (objListColunas.IndexOf(objColunas) != objListColunas.Count - 1)
                    stb.AppendLine(String.Format("                ParametroSQL.Append(\"{0} = @{1}, \");", objColunas.colNome, objColunas.colNome));
                else
                    stb.AppendLine(String.Format("                ParametroSQL.Append(\"{0} = @{1} \");", objColunas.colNome, objColunas.colNome)); //Remove vírgula
            }
            stb.AppendLine(String.Format("                ParametroSQL.Append(\"WHERE {0} = @{1}\");", sChavePrimaria, sChavePrimaria));
            stb.AppendLine("                comando.limparParametros();");
            foreach (var objColuna in objListColunas)
            {
                stb.AppendLine(String.Format("                comando.adicionarParametros(\"@{0}\", obj.{1});", objColuna.colNome, objColuna.colNome));
            }
            stb.AppendLine("                comando.executaComando(ParametroSQL.ToString());");
            stb.AppendLine("            }");
            stb.AppendLine("            catch (Exception exception)");
            stb.AppendLine("            {");
            stb.AppendLine("                throw new Exception(exception.Message);");
            stb.AppendLine("            }");
            stb.AppendLine("        }");
            stb.AppendLine(string.Empty);
        }

        private void EscreverMetodoExcluir(StringBuilder stb, string sNomeClasse, mdoTabelas objTabela)
        {
            var sChavePrimaria = new ctrColunas().ObterColunaChavePrimaria(objTabela.tblNome);

            stb.AppendLine(String.Format("        public void Excluir(mdo{0} obj)", sNomeClasse));
            stb.AppendLine("        {");
            stb.AppendLine("            try");
            stb.AppendLine("            {");
            stb.AppendLine(String.Format("                var ParametroSQL = \"DELETE {0} WHERE {1} = @{2}\";", objTabela.tblNome, sChavePrimaria, sChavePrimaria));
            stb.AppendLine("                comando.limparParametros();");
            stb.AppendLine(String.Format("                comando.adicionarParametros(\"@{0}\", obj.{1});", sChavePrimaria, sChavePrimaria));
            stb.AppendLine("                comando.executaComando(ParametroSQL.ToString());");
            stb.AppendLine("            }");
            stb.AppendLine("            catch (Exception exception)");
            stb.AppendLine("            {");
            stb.AppendLine("                throw new Exception(exception.Message);");
            stb.AppendLine("            }");
            stb.AppendLine("        }");
            stb.AppendLine(string.Empty);
        }

        private void ExportarModelos()
        {
            var objCtrColunas = new ctrColunas();
            foreach (var objTabela in listaTabelas)
            {
                if (!objTabela.tblSelecionada)
                    continue;

                OnFollowUp(String.Format("Escrevendo modelo para a tabela: {0}", objTabela.tblNome));

                var stb = new StringBuilder();
                listaColunas = objCtrColunas.ListarColunas(objTabela.tblNome);

                //Padrão Cambel Case
                var sNomeClasse = objTabela.tblNome.Replace("tbl", string.Empty);
                if (mdoBancoDados.RemoverDeclaracaoView)
                {
                    sNomeClasse = sNomeClasse.Replace("view", string.Empty).Replace("vw", string.Empty).Replace("vw_", string.Empty);
                }

                #region Cria classe Modelo
                sNomeClasse = sNomeClasse.Substring(0, 1).ToUpper() + sNomeClasse.Substring(1, sNomeClasse.Length - 1);
                sNomeClasse = "mdo" + sNomeClasse;
                
                //Adiciona as usings
                foreach (string sUsing in conUsings)
                    stb.AppendLine(sUsing);

                //Cria o namespace
                stb.AppendLine(string.Empty);
                stb.AppendLine(String.Format("namespace {0}.Modelos", mdoBancoDados.Namespace));
                stb.AppendLine("{");
                    
                //Cria a classe
                stb.AppendLine(String.Format("    public class {0}", sNomeClasse));
                stb.AppendLine("    {");

                foreach (var objColuna in listaColunas)
                {
                    var sColumnType = ctrColunas.ObterTipoColuna(objColuna);
                    stb.AppendLine(String.Format("        public {0} {1} ", sColumnType, objColuna.colNome) + "{ get; set; } ");
                }
                stb.AppendLine("    }");
                stb.AppendLine("}");

                OnFollowUp(String.Format("Criando arquivo para a tabela: {0}", objTabela.tblNome));
                OnFollowUp(string.Empty);
                GerarArquivo(stb.ToString(), "Modelos", sNomeClasse);
                #endregion

                #region Cria classe Lista modelo
                stb.Clear();
                OnFollowUp(String.Format("Escrevendo lista para a tabela: {0}", objTabela.tblNome));

                //Adiciona as usings
                foreach (string sUsing in conUsings)
                    stb.AppendLine(sUsing);

                //Cria o namespace
                stb.AppendLine(string.Empty);
                stb.AppendLine(String.Format("namespace {0}.Modelos", mdoBancoDados.Namespace));
                stb.AppendLine("{");

                //Cria a classe
                stb.AppendLine(String.Format("    public class {0}Lista : List<{1}>", sNomeClasse, sNomeClasse));
                stb.AppendLine("    {");
                stb.AppendLine("    }");
                stb.AppendLine("}");

                OnFollowUp(String.Format("Criando arquivo de listagem para a tabela: {0}", objTabela.tblNome));
                OnFollowUp(string.Empty);
                GerarArquivo(stb.ToString(), "Modelos", sNomeClasse + "Lista");
                #endregion
            }

            OnFollowUp(string.Empty);
            OnFollowUp("Exportação das classes de modelo concluída.");
            OnFollowUp(string.Empty);
        }

        private void GerarArquivo(string sTexto, string sDiretorioObjeto, string sNomeClasse)
        {
            var sPath = String.Format(@"{0}\{1}\{2}.cs", mdoBancoDados.DiretorioDestino, sDiretorioObjeto, sNomeClasse);
            File.Create(sPath).Close();
            var stw = new StreamWriter(sPath);
            try
            {
                stw.Write(sTexto);
            }
            finally
            {
                stw.Close();
            }
        }

        public static void InstanciarConexao()
        {
            var connection = perBancoDados.StringConexao;
            int idx = connection.IndexOf("Data Source=") + 12;
            mdoBancoDados.Servidor = connection.Substring(idx, connection.Length - idx);
            mdoBancoDados.Servidor = mdoBancoDados.Servidor.Substring(0, mdoBancoDados.Servidor.IndexOf(";"));


            idx = connection.IndexOf("User ID=") + 8;
            mdoBancoDados.Usuario = connection.Substring(idx, connection.Length - idx);
            mdoBancoDados.Usuario = mdoBancoDados.Usuario.Substring(0, mdoBancoDados.Usuario.IndexOf(";"));

            idx = connection.IndexOf("Password=") + 9;
            mdoBancoDados.Senha = connection.Substring(idx, connection.Length - idx);
        }


        #region Eventos
        
        public delegate void FollowUpDelegate(string sFollowUp);
        public event FollowUpDelegate FollowUp;
        public virtual void OnFollowUp(string sFollowUp)
        {
            if (FollowUp != null)
                FollowUp(sFollowUp);
        }

        #endregion
    }
}
