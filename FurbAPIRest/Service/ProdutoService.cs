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

        public List<Produto> GetProdutos()
        {
            return _dataContext.Produtos.ToList();
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

        public object GetProdutoDto(long id)
        {
            var produto = GetProduto(id);

            return new
            {
                produto.Id,
                produto.Nome,
                produto.Preco
            };
        }

        public Produto CreateProduto(string nomeProduto, int precoProduto)
        {
            Produto produto = new()
            {
                Nome = nomeProduto,
                Preco = precoProduto,
            };
            return CreateProduto(produto);
        }

        public Produto CreateProduto(Produto produto)
        {
            var novoProduto = _dataContext.Produtos.Add(produto);
            _dataContext.SaveChanges();
            return novoProduto.Entity;
        }

        public Produto UpdateProduto(Produto produtoAtualizado)
        {
            var produtoBase = GetProduto(produtoAtualizado.Id);
            produtoBase.Nome = produtoAtualizado.Nome;
            produtoBase.Preco = produtoAtualizado.Preco;

            var produtoAlterado = _dataContext.Produtos.Update(produtoBase);
            _dataContext.SaveChanges();

            return produtoAlterado.Entity;
        }
    }
}
