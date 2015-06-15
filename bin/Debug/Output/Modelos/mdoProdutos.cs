using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MasterServiceManager.Modelos
{
    public class mdoProdutos
    {
        public Boolean proAtivo;
        public Int32 proCodigo;
        public String proReferencia;
        public String proCodigoFornecedor;
        public Int32 proFornecedor;
        public String proDescricao;
        public Int32 proCategoria;
        public String proCodigoBarras;
        public Decimal proValorCompra;
        public Decimal proValorVenda;
        public Decimal? proPeso;
        public String proDimensao;
        public Decimal? proQuantidadeMinima;
        public Decimal? proQuantidadeMaxima;
        public Decimal? proQuantidadeImobilizado;
        public Decimal? proQuantidadeUsoConsumo;
        public Boolean proProdutoFiscal;
        public Int32? proNcm;
        public Int32? proModalidade;
        public Int16 proTipoProduto;
        public String pcaCategoria;
        public String ncmCodigoNcm;
        public String ncmDescricao;
        public String pesNome;
        public String pesNomeRazao;
    }
}
