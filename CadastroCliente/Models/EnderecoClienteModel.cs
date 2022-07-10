using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroCliente.Models
{
    [Table("Endereco_Cliente")]
    public class EnderecoClienteModel
    {
        [Key]
        public int Id_EndCli { get; set; }
        [ForeignKey("Clientes")]
        public int Id_Cliente { get; set; }
        public ClienteModel Clientes { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}