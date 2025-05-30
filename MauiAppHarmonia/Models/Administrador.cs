using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiAppHarmonia.Models
{
   public class Administrador
    {
        [PrimaryKey]


        public int codigoAdmin { get; set; }
        public string Nome {  get; set; }
        public int codigoPessoa { get; set; }
        public string Matricula { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public double Salario { get; set; }
    }
}
