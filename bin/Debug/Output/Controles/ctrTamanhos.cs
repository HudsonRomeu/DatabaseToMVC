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
    public class ctrTamanhos
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblTamanhos {0} ORDER BY 1 ASC", parametroSQL);
                var objTamanhosLista = new mdoTamanhosLista();
                DataTable dataTableTamanhos = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableTamanhos.Rows)
                {
                    var objTamanhos = new mdoTamanhos();
                    objTamanhos.tamCodigo = Convert.ToInt32(linha["tamCodigo"]);
                    objTamanhos.tamTamanho = Convert.ToString(linha["tamTamanho"]);
                    objTamanhosLista.Add(objTamanhos);
                }
                return objTamanhosLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoTamanhos obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblTamanhos ");
                ParametroSQL.Append("(tamCodigo, tamTamanho)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@tamCodigo, @tamTamanho)");

                comando.limparParametros();
                comando.adicionarParametros("@tamCodigo", obj.tamCodigo);
                comando.adicionarParametros("@tamTamanho", obj.tamTamanho);
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

        public void Alterar(mdoTamanhos obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblTamanhos SET ");
                ParametroSQL.Append("tamTamanho = @tamTamanho ");
                ParametroSQL.Append("WHERE tamCodigo = @tamCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@tamCodigo", obj.tamCodigo);
                comando.adicionarParametros("@tamTamanho", obj.tamTamanho);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoTamanhos obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblTamanhos WHERE tamCodigo = @tamCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@tamCodigo", obj.tamCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
