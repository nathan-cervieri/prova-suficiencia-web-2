using FurbAPIRest.Contracts.Produto;
using FurbAPIRest.DTO.Produtos;
using FurbAPIRest.Helpers;
using FurbAPIRest.Models;
using System.Data.Entity.Core;

namespace FurbAPIRest.Service
{
    public class ProdutoService
    {
        private readonly DataContext _dataContext;

        public ProdutoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<ProdutoRetornoDto> GetProdutos()
        {
            return _dataContext.Produtos.Select(p => new ProdutoRetornoDto(p)).ToList();
        }

        public Produto GetProduto(long id)
        {
            var produto = _dataContext.Produtos.FirstOrDefault(p => p.Id == id);
            if (produto == null)
            {
                throw new ObjectNotFoundException($"Não foi possível achar produto com id {id}");
            }

            return produto;
        }

        public ProdutoRetornoDto GetProdutoDto(long id)
        {
            var produto = GetProduto(id);

            return new ProdutoRetornoDto(produto);
        }

        public ProdutoRetornoDto CreateProduto(string nomeProduto, int precoProduto)
        {
            Produto produto = new()
            {
                Nome = nomeProduto,
                Preco = precoProduto,
            };
            return CreateProduto(produto);
        }

        public ProdutoRetornoDto CreateProduto(Produto produto)
        {
            var novoProduto = _dataContext.Produtos.Add(produto);
            _dataContext.SaveChanges();
            return new ProdutoRetornoDto(novoProduto.Entity);
        }

        public ProdutoRetornoDto UpdateProduto(ProdutoPutContract produtoAtualizado)
        {
            var produtoBase = GetProduto(produtoAtualizado.Id);
            produtoBase.Nome = produtoAtualizado.Nome;
            produtoBase.Preco = produtoAtualizado.Preco;

            ValidarProduto(produtoBase);

            var produtoAlterado = _dataContext.Produtos.Update(produtoBase);
            _dataContext.SaveChanges();

            return new ProdutoRetornoDto(produtoAlterado.Entity);
        }

        private static void ValidarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException("Produto não pode ser nulo");
            }

            if (string.IsNullOrWhiteSpace(produto.Nome))
            {
                throw new ArgumentException("Nome do produto não pode ser vazio");
            }

            if (produto.Preco <= 0)
            {
                throw new ArgumentException("Preço do produto não pode ser igual ou menor do que 0");
            }
        }
    }
}
