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
    public class ctrProdutosCategorias
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblProdutosCategorias {0} ORDER BY 1 ASC", parametroSQL);
                var objProdutosCategoriasLista = new mdoProdutosCategoriasLista();
                DataTable dataTableProdutosCategorias = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableProdutosCategorias.Rows)
                {
                    var objProdutosCategorias = new mdoProdutosCategorias();
                    objProdutosCategorias.pcaCodigo = Convert.ToInt32(linha["pcaCodigo"]);
                    objProdutosCategorias.pcaCategoria = Convert.ToString(linha["pcaCategoria"]);
                }
                return objProdutosCategoriasLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoProdutosCategorias obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblProdutosCategorias ");
                ParametroSQL.Append("(pcaCodigo, pcaCategoria)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@pcaCodigo, @pcaCategoria)");

                comando.limparParametros();
                comando.adicionarParametros("@pcaCodigo", obj.pcaCodigo);
                comando.adicionarParametros("@pcaCategoria", obj.pcaCategoria);
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

        public void Alterar(mdoProdutosCategorias obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblProdutosCategorias SET ");
                ParametroSQL.Append("pcaCategoria = @pcaCategoria ");
                ParametroSQL.Append("WHERE pcaCodigo = @pcaCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@pcaCodigo", obj.pcaCodigo);
                comando.adicionarParametros("@pcaCategoria", obj.pcaCategoria);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoProdutosCategorias obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblProdutosCategorias WHERE pcaCodigo = @pcaCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@pcaCodigo", obj.pcaCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
