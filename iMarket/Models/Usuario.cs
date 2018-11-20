using System;
using System.Collections.Generic;

namespace iMarket.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CarrinhoDeCompra = new HashSet<CarrinhoDeCompra>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public double Saldo { get; set; }

        public ICollection<CarrinhoDeCompra> CarrinhoDeCompra { get; set; }
    }
}
