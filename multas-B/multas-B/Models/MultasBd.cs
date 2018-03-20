using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace multas_B.Models
{
    public class MultasBd : DbContext
    {

        //construtorq indica qual a base de dados a utilizar
        public MultasBd() : base("name=MultasBDConnectionString") { }

        //descrever os nomes das tabelas na base de dados
        public virtual DbSet<Multas> Multas { get; set; } //tabela Multas

        public virtual DbSet<Condutores> Condutores { get; set; } //tabela Condutores

        public virtual DbSet<Agentes> Agentes { get; set; } //tabela Agentes

        public virtual DbSet<Viaturas> Viaturas { get; set; } //tabela Viaturas

        
    }
}