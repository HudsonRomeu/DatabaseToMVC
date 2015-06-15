using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MasterServiceManager.Persistencia;
using MasterServiceManager.Modelos;

namespace MasterServiceManager.Controles
{
    public class ctrProdutosGrades
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblProdutosGrades {0} ORDER BY 1 ASC", parametroSQL);
                var objProdutosGradesLista = new mdoProdutosGradesLista();
                DataTable dataTableProdutosGrades = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableProdutosGrades.Rows)
                {
                    var objProdutosGrades = new mdoProdutosGrades();
                    objProdutosGrades.proGrdCodigo = Convert.ToInt32(linha["proGrdCodigo"]);
                    objProdutosGrades.proGrdProduto = Convert.ToInt32(linha["proGrdProduto"]);
                    objProdutosGrades.proGrdCor = Convert.ToInt32(linha["proGrdCor"]);
                    objProdutosGrades.proGrdTamanho = Convert.ToInt32(linha["proGrdTamanho"]);
                    objProdutosGrades.proGrdTamanhoSigla = Convert.ToString(linha["proGrdTamanhoSigla"]);
                    objProdutosGrades.proGrdQuantidade = Convert.ToDecimal(linha["proGrdQuantidade"]);
                    objProdutosGradesLista.Add(objProdutosGrades);
                }
                return objProdutosGradesLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoProdutosGrades obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblProdutosGrades ");
                ParametroSQL.Append("(proGrdCodigo, proGrdProduto, proGrdCor, proGrdTamanho, proGrdTamanhoSigla, proGrdQuantidade)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@proGrdCodigo, @proGrdProduto, @proGrdCor, @proGrdTamanho, @proGrdTamanhoSigla, @proGrdQuantidade)");

                comando.limparParametros();
                comando.adicionarParametros("@proGrdCodigo", obj.proGrdCodigo);
                comando.adicionarParametros("@proGrdProduto", obj.proGrdProduto);
                comando.adicionarParametros("@proGrdCor", obj.proGrdCor);
                comando.adicionarParametros("@proGrdTamanho", obj.proGrdTamanho);
                comando.adicionarParametros("@proGrdTamanhoSigla", obj.proGrdTamanhoSigla);
                comando.adicionarParametros("@proGrdQuantidade", obj.proGrdQuantidade);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (ConstraintException)
            {
                throw new Exception("Registros duplicados. Usuário já cadastrado.");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Alterar(mdoProdutosGrades obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblProdutosGrades SET ");
                ParametroSQL.Append("proGrdProduto = @proGrdProduto, ");
                ParametroSQL.Append("proGrdCor = @proGrdCor, ");
                ParametroSQL.Append("proGrdTamanho = @proGrdTamanho, ");
                ParametroSQL.Append("proGrdTamanhoSigla = @proGrdTamanhoSigla, ");
                ParametroSQL.Append("proGrdQuantidade = @proGrdQuantidade ");
                ParametroSQL.Append("WHERE proGrdCodigo = @proGrdCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@proGrdCodigo", obj.proGrdCodigo);
                comando.adicionarParametros("@proGrdProduto", obj.proGrdProduto);
                comando.adicionarParametros("@proGrdCor", obj.proGrdCor);
                comando.adicionarParametros("@proGrdTamanho", obj.proGrdTamanho);
                comando.adicionarParametros("@proGrdTamanhoSigla", obj.proGrdTamanhoSigla);
                comando.adicionarParametros("@proGrdQuantidade", obj.proGrdQuantidade);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoProdutosGrades obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblProdutosGrades WHERE proGrdCodigo = @proGrdCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@proGrdCodigo", obj.proGrdCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
