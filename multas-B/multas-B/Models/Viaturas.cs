using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multas_B.Models
{
    public class Viaturas
    {

        public Viaturas() {
            ListaDeMultas = new HashSet<Multas>();
        }

        [Key]
        public int ID { get; set; } // chave primaria

        //dados de uma viatura
        public string Matricula { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        //dados do dono de uma viatura

        public string NomeDono { get; set; }

        public string MoradaDono { get; set; }

        public string CodPostalDono { get; set; }

        //tambem é necessario isto para relacionar as tabelas atraves das FK
        //referência ás multas que um condutor recebe numa viatura 
        public virtual ICollection <Multas> ListaDeMultas { get; set; }

        
    }
}