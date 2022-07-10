using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models
{
    public class CadastroClienteContext : DbContext
    {
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EnderecoClienteModel> EnderecoCliente { get; set; }

        public CadastroClienteContext() : base("CadastroCliente") { }
    }
}