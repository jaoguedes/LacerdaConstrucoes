using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LacerdaContrucoes.Models
{
    public class CadVendas
    {
        public Guid CadVendasId { get; set; }
        public Guid NotaDaVenda {  get; set; }
        public DateTime DataDaVenda { get; set; }

        [DisplayName("Produtos")]
        public Guid? VendaId { get; set; }
        public Venda? Venda { get; set; }

    }
}
