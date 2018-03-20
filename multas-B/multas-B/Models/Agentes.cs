using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace multas_B.Models
{
    public class Agentes
    {

        public Agentes()
        {
            ListaDeMultas = new HashSet<Multas>();
        }

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }
        //tambem é necessario isto para relacionar as tabelas atraves das FK
        //referência ás multas que um agente passa
        public virtual ICollection<Multas> ListaDeMultas { get; set; }

    }
}