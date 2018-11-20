using System;
using System.Collections.Generic;

namespace iMarket.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produto = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Produto> Produto { get; set; }
    }
}
