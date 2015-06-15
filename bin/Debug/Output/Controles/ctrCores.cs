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
    public class ctrCores
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblCores {0} ORDER BY 1 ASC", parametroSQL);
                var objCoresLista = new mdoCoresLista();
                DataTable dataTableCores = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableCores.Rows)
                {
                    var objCores = new mdoCores();
                    objCores.corCodigo = Convert.ToInt32(linha["corCodigo"]);
                    objCores.corDescricao = Convert.ToString(linha["corDescricao"]);
                    objCoresLista.Add(objCores);
                }
                return objCoresLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoCores obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblCores ");
                ParametroSQL.Append("(corCodigo, corDescricao)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@corCodigo, @corDescricao)");

                comando.limparParametros();
                comando.adicionarParametros("@corCodigo", obj.corCodigo);
                comando.adicionarParametros("@corDescricao", obj.corDescricao);
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

        public void Alterar(mdoCores obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblCores SET ");
                ParametroSQL.Append("corDescricao = @corDescricao ");
                ParametroSQL.Append("WHERE corCodigo = @corCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@corCodigo", obj.corCodigo);
                comando.adicionarParametros("@corDescricao", obj.corDescricao);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoCores obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblCores WHERE corCodigo = @corCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@corCodigo", obj.corCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
