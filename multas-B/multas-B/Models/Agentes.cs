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

        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüçãõ]+(( |'|-| dos | da | de | e | d')[A-ZÍÉÂÁ][a-záéíóúàèìòùâêîôûäëïöüçãõ]+){1,3}", ErrorMessage = "O {0} apenas pode conter letras e espaço em branco etc !")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [RegularExpression("[A-ZÉÍÂÁ]*[a-zçáéíóúàèìòùâêîôûãõ -]*", ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public string Esquadra { get; set; }

        public string Fotografia { get; set; }
        //tambem é necessario isto para relacionar as tabelas atraves das FK
        //referência ás multas que um agente passa
        public virtual ICollection<Multas> ListaDeMultas { get; set; }

    }
}