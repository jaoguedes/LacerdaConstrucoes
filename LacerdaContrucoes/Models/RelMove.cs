namespace LacerdaContrucoes.Models
{
    public class RelMove
    {
        public Guid RelMoveId { get; set; }

        public Guid? CadComprasId { get; set; }        
        public CadCompras? CadCompras { get; set;}
        public Guid? CadVendasId { get; set; }
        public CadVendas? Vendas { get; set; }

    }
}
