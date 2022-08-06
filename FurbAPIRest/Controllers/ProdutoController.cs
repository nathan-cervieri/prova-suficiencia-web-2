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
        public ActionResult PostProduto([FromBody] Produto produto)
        {
            _produtoService.CreateProduto(produto);
            return Ok();
        }

        [HttpPut("Produtos")]
        public ActionResult UpdateProduto([FromBody] Produto produto)
        {
            _produtoService.UpdateProduto(produto);
            return Ok();
        }
    }
}
