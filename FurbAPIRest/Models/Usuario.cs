namespace FurbAPIRest.Models
{
    public class Usuario : IEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string TelefoneUsuario { get; set; }
    }
}
