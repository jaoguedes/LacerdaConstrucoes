using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class CadVendas
    {
        public Guid CadVendasId { get; set; }
        public int NotaDaVenda { get; set; }
        public DateTime DataDaVenda { get; set; }

        [DisplayName("Cliente")]
        public Guid? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [DisplayName("Item da venda")]
        public IEnumerable<Venda>? Vendas { get; set; }

    }
}
