using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class Compra
    {
        public Guid CompraId { get; set; }

        [DisplayName("Compra")]
        public Guid? CadComprasId { get; set; }
        public CadCompras? CadCompras { get; set; }
        public int qtdCompra { get; set; }

        [DisplayName("Produto")]
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }
    }
}
