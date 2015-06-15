using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MasterServiceManager.Modelos
{
    public class mdoNotasFiscaisNcm
    {
        public Int32 ncmCodigo { get; set; } 
        public String ncmCodigoNcm { get; set; } 
        public String ncmDescricao { get; set; } 
        public Int32? ncmRegimeTributacao { get; set; } 
        public Int32? ncmOrigemTributacao { get; set; } 
        public Int32? ncmCst { get; set; } 
        public Int32 ncmCstPis { get; set; } 
        public Int32 ncmCstCofins { get; set; } 
        public Int32? ncmCfop { get; set; } 
        public Decimal? ncmAliquotaIcms { get; set; } 
        public Decimal? ncmAliquotaIcmsReducao { get; set; } 
        public Decimal? ncmAliquotaPis { get; set; } 
        public Decimal? ncmAliquotaCofins { get; set; } 
        public Decimal? ncmAliquotaIpi { get; set; } 
        public Int32? ncmExTipiTipo { get; set; } 
        public String ncmExTipi { get; set; } 
        public Int32? nopCfop { get; set; } 
        public String nopDescricao { get; set; } 
        public Int32? otbCodigoOrigem { get; set; } 
        public String otbOrigem { get; set; } 
        public Int32? rtbCodigoRegime { get; set; } 
        public String rtbRegime { get; set; } 
        public Int32? cstRegimeTributacao { get; set; } 
        public String cstCst { get; set; } 
        public String cstDescricao { get; set; } 
        public Boolean? cstOperacao { get; set; } 
        public String cstCstPis { get; set; } 
        public String cstDescricaoPis { get; set; } 
        public Int32 extCodigoFiscal { get; set; } 
        public String extDescricao { get; set; } 
    }
}
