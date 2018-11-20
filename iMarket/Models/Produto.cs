using System;
using System.Collections.Generic;

namespace iMarket.Models
{
    public partial class Produto
    {
        public Produto()
        {
            CarrinhoDeCompra = new HashSet<CarrinhoDeCompra>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public double Preco { get; set; }
        public string Imagem { get; set; }
        public int? Desconto { get; set; }
        public int CategoriaId { get; set; }
        public int FornecedorId { get; set; }

        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public ICollection<CarrinhoDeCompra> CarrinhoDeCompra { get; set; }
    }
}
