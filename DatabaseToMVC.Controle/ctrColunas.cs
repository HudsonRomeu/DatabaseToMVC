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
    public class ctrColunas
    {
        const string conSQLConsultaTabelas = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{0}' and TABLE_NAME = '{1}' ORDER BY ORDINAL_POSITION ASC ";
        const string conSQLChavePrimaria = "SELECT INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.COLUMN_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " +
            " LEFT JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS ON (TABLE_CONSTRAINTS.CONSTRAINT_NAME = CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME) " +
            " WHERE	INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_SCHEMA = '{0}' AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.TABLE_NAME = '{1}' " +
            "AND INFORMATION_SCHEMA.TABLE_CONSTRAINTS.CONSTRAINT_TYPE = 'PRIMARY KEY'";

        private perBancoDados objPersistencia;

        public List<mdoColunas> ListarColunas(string sTabela = "", string sSchema = "dbo")
        {
            var listaColunas = new List<mdoColunas>();
            objPersistencia = new perBancoDados();

            var datColunas = objPersistencia.executaConsulta(String.Format(conSQLConsultaTabelas, sSchema, sTabela), mdoBancoDados.ConnectionString);
            foreach (DataRow objRow in datColunas.Rows)
            {
                var objColuna = new mdoColunas();
                objColuna.colNome = objRow["COLUMN_NAME"].ToString();
                objColuna.colTipo = objRow["DATA_TYPE"].ToString();
                objColuna.colIsNull = objRow["IS_NULLABLE"].ToString().ToUpper().Equals("YES");

                objColuna.tblSelecionada = true;
                objColuna.tblNome = objRow["TABLE_NAME"].ToString();
                objColuna.tblCatalogo = objRow["TABLE_CATALOG"].ToString();
                
                listaColunas.Add(objColuna);
            }

            return listaColunas;
        }

        public string ObterColunaChavePrimaria(string sTabela = "", string sSchema = "dbo")
        {
            objPersistencia = new perBancoDados();
            var datColunas = objPersistencia.executaConsulta(String.Format(conSQLChavePrimaria, sSchema, sTabela), mdoBancoDados.ConnectionString);

            foreach (DataRow objRow in datColunas.Rows)
            {
                return objRow["COLUMN_NAME"].ToString();
            }
            return "";
        }

        public static string ObterTipoColuna(mdoColunas objColuna)
        {
            switch (objColuna.colTipo)
            {
                case "bit":
                    {
                        return objColuna.colIsNull ? "Boolean?" : "Boolean";
                    }
                case "varchar":
                    {
                        return "String";
                    }
                case "int":
                    {
                        return objColuna.colIsNull ? "Int32?" : "Int32";
                    }
                case "bigint":
                    {
                        return objColuna.colIsNull ? "Int64?" : "Int64";
                    }
                case "decimal":
                    {
                        return objColuna.colIsNull ? "Decimal?" : "Decimal";
                    }
                case "smallint":
                    {
                        return objColuna.colIsNull ? "Int16?" : "Int16";
                    }
                case "date":
                    {
                        return objColuna.colIsNull ? "DateTime?" : "DateTime";
                    }
                case "time":
                    {
                        return objColuna.colIsNull ? "DateTime?" : "DateTime";
                    }
                case "datetime":
                    {
                        return objColuna.colIsNull ? "DateTime?" : "DateTime";
                    }
                default:
                    return "String";
            }
        }
    }
}
