using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToMVC.Modelo
{
    public static class mdoBancoDados
    {
        static string cEmptyDatabaseString = "Data Source={0};Persist Security Info=True;User ID={1};Password={2}";
        static string cDefaultString = "Data Source={0};Initial Catalog=\"{1}\";Persist Security Info=True;User ID={2};Password={3}";

        public static string Servidor { get; set; }
        public static string BancoDados { get; set; }
        public static string Usuario { get; set; }
        public static string Senha { get; set; }

        public static string Namespace { get; set; }
        public static string DiretorioDestino { get; set; }

        public static bool ExportarModelos { get; set; }
        public static bool ExportarControles { get; set; }
        public static bool RemoverDeclaracaoView { get; set; }
        public static bool UtilizarPadraoHyperLib { get; set; }

        public static string ConnectionString
        {
            get
            {
                return string.IsNullOrEmpty(BancoDados) ? String.Format(cEmptyDatabaseString, Servidor, Usuario, Senha) :
                    String.Format(cDefaultString, Servidor, BancoDados, Usuario, Senha);
            }
        }
    }
}
