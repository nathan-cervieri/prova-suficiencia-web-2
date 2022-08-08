using FurbAPIRest.Models;

namespace FurbAPIRest.DTO.Produtos
{
    public class ProdutoRetornoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Preco { get; set; }

        public ProdutoRetornoDto(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Preco = produto.Preco;
        }
    }
}
