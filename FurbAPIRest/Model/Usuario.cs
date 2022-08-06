namespace FurbAPIRest.Model
{
    public class Usuario : IEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string TelefoneUsuario { get; set; } = string.Empty;
    }
}
