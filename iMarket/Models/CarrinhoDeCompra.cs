using System;
using System.Collections.Generic;

namespace iMarket.Models
{
    public partial class CarrinhoDeCompra
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int UsuarioId { get; set; }

        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }
    }
}
