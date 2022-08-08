using FurbAPIRest.Models;

namespace FurbAPIRest.DTO.Usuarios
{
    public class UsuarioPostDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string TelefoneUsuario { get; set; }

        public UsuarioPostDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            TelefoneUsuario = usuario.TelefoneUsuario;
        }
    }
}
