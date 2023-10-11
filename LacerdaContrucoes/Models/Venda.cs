using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class Venda
    {
        public Guid VendaId { get; set; }

        [DisplayName("Venda")]
        public Guid? CadVendasId { get; set; }
        public CadVendas? CadVendas { get; set; }
        public int qtdVendas { get; set; }

        [DisplayName("Produto")]
        public Guid? ProdutoId { get; set; }
        public Produto? Produto { get; set; }

    }
}
