using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace multas_B.Models
{
    public class Multas
    {
        [Key]
        public int ID { get; set; }

        public string Infracao { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataDaMulta { get; set; }

        public string LocalMulta { get; set; }

        //**************************************************************************
        //representar as chaves estrangeiras que relaciona esta classe com as outras
        //**************************************************************************

        //FK para a tabela dos condutores

        // ...Constraint NomeDaTermo
        //Foreign Key NomeDoAtributo references NomeTabela(NomeAtribPK)
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }

        //FK para Viaturas 
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

        //FK para Agentes 
        [ForeignKey("Agente")]
        public int AgentesFK { get; set; }
        public virtual Agentes Agente { get; set; }


    }
}