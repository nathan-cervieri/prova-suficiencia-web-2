namespace FurbAPIRest.Models
{

#nullable disable
    public class Produto : IEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }

        public virtual ICollection<Comanda> ComandasProduto { get; set; }
    }
}
