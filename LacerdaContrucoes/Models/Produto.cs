using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        public int qnt {  get; set; }
        public int PrecoUni {  get; set; }

        [DisplayName("Categoria")]
        public Guid? CategoriaDeProdutosId { get; set; }
        public CategoriaDeProdutos? CategoriaDeProdutos { get; set; }

        [DisplayName("Fornecedor")]
        public Guid? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }



    }
}
