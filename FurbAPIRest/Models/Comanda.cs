namespace FurbAPIRest.Models
{
#nullable disable
    public class Comanda : IEntity
    {
        public long Id { get; set; }

        public long UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<Produto> ProdutosComanda { get; set; }
    }
}
