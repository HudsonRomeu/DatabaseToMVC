using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MasterServiceManager.Modelos
{
    public class mdoProdutosGrades
    {
        public Int32 proGrdCodigo { get; set; } 
        public Int32 proGrdProduto { get; set; } 
        public Int32 proGrdCor { get; set; } 
        public Int32 proGrdTamanho { get; set; } 
        public Decimal proGrdQuantidade { get; set; } 
        public String proGrdTamanhoSigla { get; set; } 
    }
}
