using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToMVC.Modelo
{
    public class mdoColunas : mdoTabelas
    {
        public string colNome { get; set; }
        public string colTipo { get; set; }
        public bool colIsNull { get; set; }
    }
}
