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
    public class ctrNotasFiscaisNcm
    {
        perComando comando = new perComando();

        public object Buscar(String parametroSQL)
        {
            try
            {
                String stringSQL = String.Format("SELECT * FROM viewNotasFiscaisNcm {0} ORDER BY 1 ASC", parametroSQL);
                var objNotasFiscaisNcmLista = new mdoNotasFiscaisNcmLista();
                DataTable dataTableNotasFiscaisNcm = comando.executaConsulta(stringSQL);

                foreach (DataRow linha in dataTableNotasFiscaisNcm.Rows)
                {
                    var objNotasFiscaisNcm = new mdoNotasFiscaisNcm();
                    objNotasFiscaisNcm.ncmCodigo = Convert.ToInt32(linha["ncmCodigo"]);
                    objNotasFiscaisNcm.ncmCodigoNcm = Convert.ToString(linha["ncmCodigoNcm"]);
                    objNotasFiscaisNcm.ncmDescricao = Convert.ToString(linha["ncmDescricao"]);
                    objNotasFiscaisNcm.ncmRegimeTributacao = Convert.ToInt32(linha["ncmRegimeTributacao"]);
                    objNotasFiscaisNcm.ncmOrigemTributacao = Convert.ToInt32(linha["ncmOrigemTributacao"]);
                    objNotasFiscaisNcm.ncmCst = Convert.ToInt32(linha["ncmCst"]);
                    objNotasFiscaisNcm.ncmCstPis = Convert.ToInt32(linha["ncmCstPis"]);
                    objNotasFiscaisNcm.ncmCstCofins = Convert.ToInt32(linha["ncmCstCofins"]);
                    objNotasFiscaisNcm.ncmCfop = Convert.ToInt32(linha["ncmCfop"]);
                    objNotasFiscaisNcm.ncmAliquotaIcms = Convert.ToDecimal(linha["ncmAliquotaIcms"]);
                    objNotasFiscaisNcm.ncmAliquotaIcmsReducao = Convert.ToDecimal(linha["ncmAliquotaIcmsReducao"]);
                    objNotasFiscaisNcm.ncmAliquotaPis = Convert.ToDecimal(linha["ncmAliquotaPis"]);
                    objNotasFiscaisNcm.ncmAliquotaCofins = Convert.ToDecimal(linha["ncmAliquotaCofins"]);
                    objNotasFiscaisNcm.ncmAliquotaIpi = Convert.ToDecimal(linha["ncmAliquotaIpi"]);
                    objNotasFiscaisNcm.ncmExTipiTipo = Convert.ToInt32(linha["ncmExTipiTipo"]);
                    objNotasFiscaisNcm.ncmExTipi = Convert.ToString(linha["ncmExTipi"]);
                    objNotasFiscaisNcm.nopCfop = Convert.ToInt32(linha["nopCfop"]);
                    objNotasFiscaisNcm.nopDescricao = Convert.ToString(linha["nopDescricao"]);
                    objNotasFiscaisNcm.otbCodigoOrigem = Convert.ToInt32(linha["otbCodigoOrigem"]);
                    objNotasFiscaisNcm.otbOrigem = Convert.ToString(linha["otbOrigem"]);
                    objNotasFiscaisNcm.rtbCodigoRegime = Convert.ToInt32(linha["rtbCodigoRegime"]);
                    objNotasFiscaisNcm.rtbRegime = Convert.ToString(linha["rtbRegime"]);
                    objNotasFiscaisNcm.cstRegimeTributacao = Convert.ToInt32(linha["cstRegimeTributacao"]);
                    objNotasFiscaisNcm.cstCst = Convert.ToString(linha["cstCst"]);
                    objNotasFiscaisNcm.cstDescricao = Convert.ToString(linha["cstDescricao"]);
                    objNotasFiscaisNcm.cstOperacao = Convert.ToBoolean(linha["cstOperacao"]);
                    objNotasFiscaisNcm.cstCstPis = Convert.ToString(linha["cstCstPis"]);
                    objNotasFiscaisNcm.cstDescricaoPis = Convert.ToString(linha["cstDescricaoPis"]);
                    objNotasFiscaisNcm.extCodigoFiscal = Convert.ToInt32(linha["extCodigoFiscal"]);
                    objNotasFiscaisNcm.extDescricao = Convert.ToString(linha["extDescricao"]);
                    objNotasFiscaisNcmLista.Add(objNotasFiscaisNcm);
                }
                return objNotasFiscaisNcmLista;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Incluir(mdoNotasFiscaisNcm obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("INSERT INTO viewNotasFiscaisNcm ");
                ParametroSQL.Append("(ncmCodigo, ncmCodigoNcm, ncmDescricao, ncmRegimeTributacao, ncmOrigemTributacao, ncmCst, ncmCstPis, ncmCstCofins, ncmCfop, ncmAliquotaIcms, ncmAliquotaIcmsReducao, ncmAliquotaPis, ncmAliquotaCofins, ncmAliquotaIpi, ncmExTipiTipo, ncmExTipi, nopCfop, nopDescricao, otbCodigoOrigem, otbOrigem, rtbCodigoRegime, rtbRegime, cstRegimeTributacao, cstCst, cstDescricao, cstOperacao, cstCstPis, cstDescricaoPis, extCodigoFiscal, extDescricao)");
                ParametroSQL.Append(" VALUES ");
                ParametroSQL.Append("(@ncmCodigo, @ncmCodigoNcm, @ncmDescricao, @ncmRegimeTributacao, @ncmOrigemTributacao, @ncmCst, @ncmCstPis, @ncmCstCofins, @ncmCfop, @ncmAliquotaIcms, @ncmAliquotaIcmsReducao, @ncmAliquotaPis, @ncmAliquotaCofins, @ncmAliquotaIpi, @ncmExTipiTipo, @ncmExTipi, @nopCfop, @nopDescricao, @otbCodigoOrigem, @otbOrigem, @rtbCodigoRegime, @rtbRegime, @cstRegimeTributacao, @cstCst, @cstDescricao, @cstOperacao, @cstCstPis, @cstDescricaoPis, @extCodigoFiscal, @extDescricao)");

                comando.limparParametros();
                comando.adicionarParametros("@ncmCodigo", obj.ncmCodigo);
                comando.adicionarParametros("@ncmCodigoNcm", obj.ncmCodigoNcm);
                comando.adicionarParametros("@ncmDescricao", obj.ncmDescricao);
                comando.adicionarParametros("@ncmRegimeTributacao", obj.ncmRegimeTributacao);
                comando.adicionarParametros("@ncmOrigemTributacao", obj.ncmOrigemTributacao);
                comando.adicionarParametros("@ncmCst", obj.ncmCst);
                comando.adicionarParametros("@ncmCstPis", obj.ncmCstPis);
                comando.adicionarParametros("@ncmCstCofins", obj.ncmCstCofins);
                comando.adicionarParametros("@ncmCfop", obj.ncmCfop);
                comando.adicionarParametros("@ncmAliquotaIcms", obj.ncmAliquotaIcms);
                comando.adicionarParametros("@ncmAliquotaIcmsReducao", obj.ncmAliquotaIcmsReducao);
                comando.adicionarParametros("@ncmAliquotaPis", obj.ncmAliquotaPis);
                comando.adicionarParametros("@ncmAliquotaCofins", obj.ncmAliquotaCofins);
                comando.adicionarParametros("@ncmAliquotaIpi", obj.ncmAliquotaIpi);
                comando.adicionarParametros("@ncmExTipiTipo", obj.ncmExTipiTipo);
                comando.adicionarParametros("@ncmExTipi", obj.ncmExTipi);
                comando.adicionarParametros("@nopCfop", obj.nopCfop);
                comando.adicionarParametros("@nopDescricao", obj.nopDescricao);
                comando.adicionarParametros("@otbCodigoOrigem", obj.otbCodigoOrigem);
                comando.adicionarParametros("@otbOrigem", obj.otbOrigem);
                comando.adicionarParametros("@rtbCodigoRegime", obj.rtbCodigoRegime);
                comando.adicionarParametros("@rtbRegime", obj.rtbRegime);
                comando.adicionarParametros("@cstRegimeTributacao", obj.cstRegimeTributacao);
                comando.adicionarParametros("@cstCst", obj.cstCst);
                comando.adicionarParametros("@cstDescricao", obj.cstDescricao);
                comando.adicionarParametros("@cstOperacao", obj.cstOperacao);
                comando.adicionarParametros("@cstCstPis", obj.cstCstPis);
                comando.adicionarParametros("@cstDescricaoPis", obj.cstDescricaoPis);
                comando.adicionarParametros("@extCodigoFiscal", obj.extCodigoFiscal);
                comando.adicionarParametros("@extDescricao", obj.extDescricao);
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

        public void Alterar(mdoNotasFiscaisNcm obj)
        {
            try
            {
                StringBuilder ParametroSQL = new StringBuilder();

                ParametroSQL.Append("UPDATE viewNotasFiscaisNcm SET ");
                ParametroSQL.Append("ncmCodigo = @ncmCodigo, ");
                ParametroSQL.Append("ncmCodigoNcm = @ncmCodigoNcm, ");
                ParametroSQL.Append("ncmDescricao = @ncmDescricao, ");
                ParametroSQL.Append("ncmRegimeTributacao = @ncmRegimeTributacao, ");
                ParametroSQL.Append("ncmOrigemTributacao = @ncmOrigemTributacao, ");
                ParametroSQL.Append("ncmCst = @ncmCst, ");
                ParametroSQL.Append("ncmCstPis = @ncmCstPis, ");
                ParametroSQL.Append("ncmCstCofins = @ncmCstCofins, ");
                ParametroSQL.Append("ncmCfop = @ncmCfop, ");
                ParametroSQL.Append("ncmAliquotaIcms = @ncmAliquotaIcms, ");
                ParametroSQL.Append("ncmAliquotaIcmsReducao = @ncmAliquotaIcmsReducao, ");
                ParametroSQL.Append("ncmAliquotaPis = @ncmAliquotaPis, ");
                ParametroSQL.Append("ncmAliquotaCofins = @ncmAliquotaCofins, ");
                ParametroSQL.Append("ncmAliquotaIpi = @ncmAliquotaIpi, ");
                ParametroSQL.Append("ncmExTipiTipo = @ncmExTipiTipo, ");
                ParametroSQL.Append("ncmExTipi = @ncmExTipi, ");
                ParametroSQL.Append("nopCfop = @nopCfop, ");
                ParametroSQL.Append("nopDescricao = @nopDescricao, ");
                ParametroSQL.Append("otbCodigoOrigem = @otbCodigoOrigem, ");
                ParametroSQL.Append("otbOrigem = @otbOrigem, ");
                ParametroSQL.Append("rtbCodigoRegime = @rtbCodigoRegime, ");
                ParametroSQL.Append("rtbRegime = @rtbRegime, ");
                ParametroSQL.Append("cstRegimeTributacao = @cstRegimeTributacao, ");
                ParametroSQL.Append("cstCst = @cstCst, ");
                ParametroSQL.Append("cstDescricao = @cstDescricao, ");
                ParametroSQL.Append("cstOperacao = @cstOperacao, ");
                ParametroSQL.Append("cstCstPis = @cstCstPis, ");
                ParametroSQL.Append("cstDescricaoPis = @cstDescricaoPis, ");
                ParametroSQL.Append("extCodigoFiscal = @extCodigoFiscal, ");
                ParametroSQL.Append("extDescricao = @extDescricao ");
                ParametroSQL.Append("WHERE  = @");
                comando.limparParametros();
                comando.adicionarParametros("@ncmCodigo", obj.ncmCodigo);
                comando.adicionarParametros("@ncmCodigoNcm", obj.ncmCodigoNcm);
                comando.adicionarParametros("@ncmDescricao", obj.ncmDescricao);
                comando.adicionarParametros("@ncmRegimeTributacao", obj.ncmRegimeTributacao);
                comando.adicionarParametros("@ncmOrigemTributacao", obj.ncmOrigemTributacao);
                comando.adicionarParametros("@ncmCst", obj.ncmCst);
                comando.adicionarParametros("@ncmCstPis", obj.ncmCstPis);
                comando.adicionarParametros("@ncmCstCofins", obj.ncmCstCofins);
                comando.adicionarParametros("@ncmCfop", obj.ncmCfop);
                comando.adicionarParametros("@ncmAliquotaIcms", obj.ncmAliquotaIcms);
                comando.adicionarParametros("@ncmAliquotaIcmsReducao", obj.ncmAliquotaIcmsReducao);
                comando.adicionarParametros("@ncmAliquotaPis", obj.ncmAliquotaPis);
                comando.adicionarParametros("@ncmAliquotaCofins", obj.ncmAliquotaCofins);
                comando.adicionarParametros("@ncmAliquotaIpi", obj.ncmAliquotaIpi);
                comando.adicionarParametros("@ncmExTipiTipo", obj.ncmExTipiTipo);
                comando.adicionarParametros("@ncmExTipi", obj.ncmExTipi);
                comando.adicionarParametros("@nopCfop", obj.nopCfop);
                comando.adicionarParametros("@nopDescricao", obj.nopDescricao);
                comando.adicionarParametros("@otbCodigoOrigem", obj.otbCodigoOrigem);
                comando.adicionarParametros("@otbOrigem", obj.otbOrigem);
                comando.adicionarParametros("@rtbCodigoRegime", obj.rtbCodigoRegime);
                comando.adicionarParametros("@rtbRegime", obj.rtbRegime);
                comando.adicionarParametros("@cstRegimeTributacao", obj.cstRegimeTributacao);
                comando.adicionarParametros("@cstCst", obj.cstCst);
                comando.adicionarParametros("@cstDescricao", obj.cstDescricao);
                comando.adicionarParametros("@cstOperacao", obj.cstOperacao);
                comando.adicionarParametros("@cstCstPis", obj.cstCstPis);
                comando.adicionarParametros("@cstDescricaoPis", obj.cstDescricaoPis);
                comando.adicionarParametros("@extCodigoFiscal", obj.extCodigoFiscal);
                comando.adicionarParametros("@extDescricao", obj.extDescricao);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Excluir(mdoNotasFiscaisNcm obj)
        {
            try
            {
                var ParametroSQL = "DELETE viewNotasFiscaisNcm WHERE  = @";
                comando.limparParametros();
                comando.adicionarParametros("@", obj.);
                comando.executaComando(ParametroSQL.ToString());
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
