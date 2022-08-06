
namespace FurbAPIRest.Model
{
#nullable disable
    public class Comanda : IEntity
    {
        public long Id { get; set; }

        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();

        public virtual ICollection<Produto> ProdutosComanda { get; set; }
    }
}
