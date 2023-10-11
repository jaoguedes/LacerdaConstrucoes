using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class CadCompras
    {
        public Guid CadComprasId { get; set; }
        public int NotaDaCompra { get; set; }
        public DateTime DataDaCompra { get; set; }

        [DisplayName("Fornecedor")]
        public Guid? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }

        [DisplayName("Item da compra")]
        public IEnumerable<Compra>? Compras { get; set; }
    }
}
