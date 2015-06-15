using DatabaseToMVC.Modelo;
using DatabaseToMVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToMVC.Controle
{
    public class ctrTabelas
    {
        public enum enumTipoTabela { Tabela, View };
        const string conSQLConsultaTabelas = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{0}' order by TABLE_TYPE, TABLE_NAME asc";

        private perBancoDados objPersistencia;

        public List<mdoTabelas> ListarTabelas( string sSchema = "dbo")
        {
            var listaTabelas = new List<mdoTabelas>();
            objPersistencia = new perBancoDados();

            var datTabelas = objPersistencia.executaConsulta(String.Format(conSQLConsultaTabelas, sSchema), mdoBancoDados.ConnectionString);
            foreach (DataRow objRow in datTabelas.Rows)
            {
                var objTabela = new mdoTabelas();
                objTabela.tblSelecionada = true;
                objTabela.tblNome = objRow["TABLE_NAME"].ToString();
                objTabela.tblCatalogo = objRow["TABLE_CATALOG"].ToString();
                objTabela.tblTipo = objRow["TABLE_TYPE"].ToString();


                listaTabelas.Add(objTabela);
            }
            return listaTabelas;
        }
    }
}
