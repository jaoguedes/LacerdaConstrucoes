using System.ComponentModel;

namespace LacerdaContrucoes.Models
{
    public class Produto
    {
        public Guid ProdutoId { get; set; }
        [DisplayName("Nome do Produto")]
        public string ProdutoName { get; set; }
        [DisplayName("Quantidade")]
        public int qnt { get; set; }
        [DisplayName("Preço")]
        public int PrecoUni { get; set; }

        [DisplayName("Categoria")]
        public Guid? CategoriaDeProdutosId { get; set; }
        [DisplayName("Categoria do Produtos")]
        public CategoriaDeProdutos? CategoriaDeProdutos { get; set; }

        [DisplayName("Fornecedor")]
        public Guid? FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }



    }
}
