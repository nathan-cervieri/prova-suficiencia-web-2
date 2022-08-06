using FurbAPIRest.Models;
using FurbAPIRest.Service;
using Microsoft.AspNetCore.Mvc;

namespace FurbAPIRest.Controllers
{
    [ApiController]
    [Route("RestAPIFurb")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("Usuarios")]
        public ActionResult GetUsuarios()
        {
            var usuarios = _usuarioService.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("Usuarios/{id}")]
        public ActionResult GetUsuario(long id)
        {
            var usuario = _usuarioService.GetUsuario(id);
            return Ok(usuario);
        }

        [HttpPost("Usuarios")]
        public ActionResult CreateUsuario([FromBody] Usuario usuario)
        {
            var novoUsuario = _usuarioService.CreateUsuario(usuario);
            return Ok(novoUsuario);
        }
    }
}
