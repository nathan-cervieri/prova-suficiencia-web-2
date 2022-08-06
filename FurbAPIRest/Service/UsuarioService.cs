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

        public List<Usuario> GetUsuarios()
        {
            return _dataContext.Usuarios.ToList();
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

        public Usuario CreateUsuario(string nomeUsuario, string telefoneUsuario)
        {
            var usuario = new Usuario
            {
                TelefoneUsuario = telefoneUsuario,
                Nome = nomeUsuario
            };
            return CreateUsuario(usuario);
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            var newUsuario = _dataContext.Usuarios.Add(usuario);
            _dataContext.SaveChanges();
            return newUsuario.Entity;
        }
    }
}
