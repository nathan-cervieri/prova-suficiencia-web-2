using FurbAPIRest.Contracts.Comanda;
using FurbAPIRest.Service;
using Microsoft.AspNetCore.Mvc;

namespace FurbAPIRest.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    public class ComandaController : Controller
    {
        private ComandaService _comandaService { get; set; }

        public ComandaController(ComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet("Comandas")]
        public ActionResult GetComandas()
        {
            var comandas = _comandaService.GetComandas();
            return Ok(comandas);
        }

        [HttpGet("Comandas/{id}")]
        public ActionResult GetComandaDetails(long id)
        {
            var comanda = _comandaService.GetComandaDto(id);
            return Ok(comanda);
        }

        [HttpPost("Comandas")]
        public ActionResult PostComanda([FromBody] ComandaPostContract comanda)
        {
            var newComanda = _comandaService.PostComanda(comanda);
            return Ok(newComanda);
        }

        [HttpPut("Comandas/{id}")]
        public ActionResult EditComanda(long id, [FromBody] ComandaPutContract comandaAtualizar)
        {
            var comanda = _comandaService.UpdateComanda(id, comandaAtualizar);
            return Ok(comanda);
        }

        [HttpDelete("Comandas/{id}")]
        public ActionResult DeleteComanda(long id)
        {
            _comandaService.DeleteComanda(id);
            return Ok(new
            {
                success = new
                {
                    text = "Comanda Removida"
                }
            });
        }
    }
}
