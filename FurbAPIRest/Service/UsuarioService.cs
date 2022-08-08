using FurbAPIRest.DTO.Usuarios;
using FurbAPIRest.Helpers;
using FurbAPIRest.Models;
using System.Data.Entity.Core;

namespace FurbAPIRest.Service
{
    public class UsuarioService
    {

        private readonly DataContext _dataContext;

        public UsuarioService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<UsuariosGetDto> GetUsuarios()
        {
            return _dataContext.Usuarios.Select(u => new UsuariosGetDto(u)).ToList();
        }

        public Usuario GetUsuario(long id)
        {
            var usuario = _dataContext.Usuarios.FirstOrDefault(c => c.Id == id);
            if (usuario == null)
            {
                throw new ObjectNotFoundException($"Não foi possível achar usuario com id {id}");
            }

            return usuario;
        }

        public UsuariosGetDto GetUsuarioDto(long id)
        {
            var usuario = GetUsuario(id);

            return new UsuariosGetDto(usuario);
        }

        public UsuarioPostDto CreateUsuario(string nomeUsuario, string telefoneUsuario)
        {
            var usuario = new Usuario
            {
                TelefoneUsuario = telefoneUsuario,
                Nome = nomeUsuario
            };
            return CreateUsuario(usuario);
        }

        public UsuarioPostDto CreateUsuario(Usuario usuario)
        {
            ValidarUsuario(usuario);

            var newUsuario = _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();
            return new UsuarioPostDto(newUsuario.Entity);
        }

        private static void ValidarUsuario(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new ArgumentNullException("Usuario não pode ser nulo");
            }

            if(string.IsNullOrWhiteSpace(usuario.Nome))
            {
                throw new ArgumentException("Nome do usuario não pode ser vazio");
            }

            if (string.IsNullOrWhiteSpace(usuario.TelefoneUsuario))
            {
                throw new ArgumentException("Telefone do usuario não pode ser vazio");
            }
        }
    }
}
