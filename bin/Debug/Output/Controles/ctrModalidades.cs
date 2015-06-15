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
    public class ctrModalidades
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblModalidades {0} ORDER BY 1 ASC", parametroSQL);
                var objModalidadesLista = new mdoModalidadesLista();
                DataTable dataTableModalidades = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableModalidades.Rows)
                {
                    var objModalidades = new mdoModalidades();
                    objModalidades.mdlCodigo = Convert.ToInt32(linha["mdlCodigo"]);
                    objModalidades.mdlProCodigo = Convert.ToInt32(linha["mdlProCodigo"]);
                    objModalidades.mdlVariacao = Convert.ToString(linha["mdlVariacao"]);
                    objModalidades.mdlTamanho = Convert.ToString(linha["mdlTamanho"]);
                    objModalidades.mdlCodigoBarras = Convert.ToString(linha["mdlCodigoBarras"]);
                }
                return objModalidadesLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoModalidades obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblModalidades ");
                ParametroSQL.Append("(mdlCodigo, mdlProCodigo, mdlVariacao, mdlTamanho, mdlCodigoBarras)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@mdlCodigo, @mdlProCodigo, @mdlVariacao, @mdlTamanho, @mdlCodigoBarras)");

                comando.limparParametros();
                comando.adicionarParametros("@mdlCodigo", obj.mdlCodigo);
                comando.adicionarParametros("@mdlProCodigo", obj.mdlProCodigo);
                comando.adicionarParametros("@mdlVariacao", obj.mdlVariacao);
                comando.adicionarParametros("@mdlTamanho", obj.mdlTamanho);
                comando.adicionarParametros("@mdlCodigoBarras", obj.mdlCodigoBarras);
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

        public void Alterar(mdoModalidades obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblModalidades SET ");
                ParametroSQL.Append("mdlProCodigo = @mdlProCodigo, ");
                ParametroSQL.Append("mdlVariacao = @mdlVariacao, ");
                ParametroSQL.Append("mdlTamanho = @mdlTamanho, ");
                ParametroSQL.Append("mdlCodigoBarras = @mdlCodigoBarras ");
                ParametroSQL.Append("WHERE mdlCodigo = @mdlCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@mdlCodigo", obj.mdlCodigo);
                comando.adicionarParametros("@mdlProCodigo", obj.mdlProCodigo);
                comando.adicionarParametros("@mdlVariacao", obj.mdlVariacao);
                comando.adicionarParametros("@mdlTamanho", obj.mdlTamanho);
                comando.adicionarParametros("@mdlCodigoBarras", obj.mdlCodigoBarras);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoModalidades obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblModalidades WHERE mdlCodigo = @mdlCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@mdlCodigo", obj.mdlCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
