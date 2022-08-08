using FurbAPIRest.Contracts.Produto;
using FurbAPIRest.Models;
using FurbAPIRest.Service;
using Microsoft.AspNetCore.Mvc;

namespace FurbAPIRest.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    public class ProdutoController : Controller
    {
        private ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("Produtos")]
        public ActionResult GetProdutos()
        {
            var produtos = _produtoService.GetProdutos();
            return Ok(produtos);
        }

        [HttpGet("Produtos/{id}")]
        public ActionResult GetProduto(long id)
        {
            var produto = _produtoService.GetProdutoDto(id);
            return Ok(produto);
        }

        [HttpPost("Produtos")]
        public ActionResult PostProduto([FromBody] ProdutoPostContract produto)
        {
            var produtoInserido = _produtoService.CreateProduto(produto.Nome, produto.Preco);
            return Ok(produtoInserido);
        }

        [HttpPut("Produtos")]
        public ActionResult UpdateProduto([FromBody] ProdutoPutContract produto)
        {
            var produtoAtualizado = _produtoService.UpdateProduto(produto);
            return Ok(produtoAtualizado);
        }
    }
}
