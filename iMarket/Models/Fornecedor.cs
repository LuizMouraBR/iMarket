using System;
using System.Collections.Generic;

namespace iMarket.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Produto = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public double Reputacao { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<Produto> Produto { get; set; }
    }
}
