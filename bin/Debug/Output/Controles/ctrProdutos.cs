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
    public class ctrProdutos
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM tblProdutos {0} ORDER BY 1 ASC", parametroSQL);
                var objProdutosLista = new mdoProdutosLista();
                DataTable dataTableProdutos = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableProdutos.Rows)
                {
                    var objProdutos = new mdoProdutos();
                    objProdutos.proAtivo = Convert.ToBoolean(linha["proAtivo"]);
                    objProdutos.proCodigo = Convert.ToInt32(linha["proCodigo"]);
                    objProdutos.proReferencia = Convert.ToString(linha["proReferencia"]);
                    objProdutos.proCodigoFornecedor = Convert.ToString(linha["proCodigoFornecedor"]);
                    objProdutos.proFornecedor = Convert.ToInt32(linha["proFornecedor"]);
                    objProdutos.proDescricao = Convert.ToString(linha["proDescricao"]);
                    objProdutos.proCategoria = Convert.ToInt32(linha["proCategoria"]);
                    objProdutos.proCodigoBarras = Convert.ToString(linha["proCodigoBarras"]);
                    objProdutos.proValorCompra = Convert.ToDecimal(linha["proValorCompra"]);
                    objProdutos.proValorVenda = Convert.ToDecimal(linha["proValorVenda"]);
                    objProdutos.proPeso = Convert.ToDecimal(linha["proPeso"]);
                    objProdutos.proDimensao = Convert.ToString(linha["proDimensao"]);
                    objProdutos.proQuantidadeMinima = Convert.ToDecimal(linha["proQuantidadeMinima"]);
                    objProdutos.proQuantidadeMaxima = Convert.ToDecimal(linha["proQuantidadeMaxima"]);
                    objProdutos.proQuantidadeImobilizado = Convert.ToDecimal(linha["proQuantidadeImobilizado"]);
                    objProdutos.proQuantidadeUsoConsumo = Convert.ToDecimal(linha["proQuantidadeUsoConsumo"]);
                    objProdutos.proProdutoFiscal = Convert.ToBoolean(linha["proProdutoFiscal"]);
                    objProdutos.proTipoProduto = Convert.ToInt16(linha["proTipoProduto"]);
                    objProdutos.proModalidade = Convert.ToInt32(linha["proModalidade"]);
                    objProdutos.proNcm = Convert.ToInt32(linha["proNcm"]);
                }
                return objProdutosLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoProdutos obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO tblProdutos ");
                ParametroSQL.Append("(proAtivo, proCodigo, proReferencia, proCodigoFornecedor, proFornecedor, proDescricao, proCategoria, proCodigoBarras, proValorCompra, proValorVenda, proPeso, proDimensao, proQuantidadeMinima, proQuantidadeMaxima, proQuantidadeImobilizado, proQuantidadeUsoConsumo, proProdutoFiscal, proTipoProduto, proModalidade, proNcm)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@proAtivo, @proCodigo, @proReferencia, @proCodigoFornecedor, @proFornecedor, @proDescricao, @proCategoria, @proCodigoBarras, @proValorCompra, @proValorVenda, @proPeso, @proDimensao, @proQuantidadeMinima, @proQuantidadeMaxima, @proQuantidadeImobilizado, @proQuantidadeUsoConsumo, @proProdutoFiscal, @proTipoProduto, @proModalidade, @proNcm)");

                comando.limparParametros();
                comando.adicionarParametros("@proAtivo", obj.proAtivo);
                comando.adicionarParametros("@proCodigo", obj.proCodigo);
                comando.adicionarParametros("@proReferencia", obj.proReferencia);
                comando.adicionarParametros("@proCodigoFornecedor", obj.proCodigoFornecedor);
                comando.adicionarParametros("@proFornecedor", obj.proFornecedor);
                comando.adicionarParametros("@proDescricao", obj.proDescricao);
                comando.adicionarParametros("@proCategoria", obj.proCategoria);
                comando.adicionarParametros("@proCodigoBarras", obj.proCodigoBarras);
                comando.adicionarParametros("@proValorCompra", obj.proValorCompra);
                comando.adicionarParametros("@proValorVenda", obj.proValorVenda);
                comando.adicionarParametros("@proPeso", obj.proPeso);
                comando.adicionarParametros("@proDimensao", obj.proDimensao);
                comando.adicionarParametros("@proQuantidadeMinima", obj.proQuantidadeMinima);
                comando.adicionarParametros("@proQuantidadeMaxima", obj.proQuantidadeMaxima);
                comando.adicionarParametros("@proQuantidadeImobilizado", obj.proQuantidadeImobilizado);
                comando.adicionarParametros("@proQuantidadeUsoConsumo", obj.proQuantidadeUsoConsumo);
                comando.adicionarParametros("@proProdutoFiscal", obj.proProdutoFiscal);
                comando.adicionarParametros("@proTipoProduto", obj.proTipoProduto);
                comando.adicionarParametros("@proModalidade", obj.proModalidade);
                comando.adicionarParametros("@proNcm", obj.proNcm);
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

        public void Alterar(mdoProdutos obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE tblProdutos SET ");
                ParametroSQL.Append("proAtivo = @proAtivo, ");
                ParametroSQL.Append("proReferencia = @proReferencia, ");
                ParametroSQL.Append("proCodigoFornecedor = @proCodigoFornecedor, ");
                ParametroSQL.Append("proFornecedor = @proFornecedor, ");
                ParametroSQL.Append("proDescricao = @proDescricao, ");
                ParametroSQL.Append("proCategoria = @proCategoria, ");
                ParametroSQL.Append("proCodigoBarras = @proCodigoBarras, ");
                ParametroSQL.Append("proValorCompra = @proValorCompra, ");
                ParametroSQL.Append("proValorVenda = @proValorVenda, ");
                ParametroSQL.Append("proPeso = @proPeso, ");
                ParametroSQL.Append("proDimensao = @proDimensao, ");
                ParametroSQL.Append("proQuantidadeMinima = @proQuantidadeMinima, ");
                ParametroSQL.Append("proQuantidadeMaxima = @proQuantidadeMaxima, ");
                ParametroSQL.Append("proQuantidadeImobilizado = @proQuantidadeImobilizado, ");
                ParametroSQL.Append("proQuantidadeUsoConsumo = @proQuantidadeUsoConsumo, ");
                ParametroSQL.Append("proProdutoFiscal = @proProdutoFiscal, ");
                ParametroSQL.Append("proTipoProduto = @proTipoProduto, ");
                ParametroSQL.Append("proModalidade = @proModalidade, ");
                ParametroSQL.Append("proNcm = @proNcm ");
                ParametroSQL.Append("WHERE proCodigo = @proCodigo");
                comando.limparParametros();
                comando.adicionarParametros("@proAtivo", obj.proAtivo);
                comando.adicionarParametros("@proCodigo", obj.proCodigo);
                comando.adicionarParametros("@proReferencia", obj.proReferencia);
                comando.adicionarParametros("@proCodigoFornecedor", obj.proCodigoFornecedor);
                comando.adicionarParametros("@proFornecedor", obj.proFornecedor);
                comando.adicionarParametros("@proDescricao", obj.proDescricao);
                comando.adicionarParametros("@proCategoria", obj.proCategoria);
                comando.adicionarParametros("@proCodigoBarras", obj.proCodigoBarras);
                comando.adicionarParametros("@proValorCompra", obj.proValorCompra);
                comando.adicionarParametros("@proValorVenda", obj.proValorVenda);
                comando.adicionarParametros("@proPeso", obj.proPeso);
                comando.adicionarParametros("@proDimensao", obj.proDimensao);
                comando.adicionarParametros("@proQuantidadeMinima", obj.proQuantidadeMinima);
                comando.adicionarParametros("@proQuantidadeMaxima", obj.proQuantidadeMaxima);
                comando.adicionarParametros("@proQuantidadeImobilizado", obj.proQuantidadeImobilizado);
                comando.adicionarParametros("@proQuantidadeUsoConsumo", obj.proQuantidadeUsoConsumo);
                comando.adicionarParametros("@proProdutoFiscal", obj.proProdutoFiscal);
                comando.adicionarParametros("@proTipoProduto", obj.proTipoProduto);
                comando.adicionarParametros("@proModalidade", obj.proModalidade);
                comando.adicionarParametros("@proNcm", obj.proNcm);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoProdutos obj)
        {
            try
            {
                var ParametroSQL = "DELETE tblProdutos WHERE proCodigo = @proCodigo";
                comando.limparParametros();
                comando.adicionarParametros("@proCodigo", obj.proCodigo);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
