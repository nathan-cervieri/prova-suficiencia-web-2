namespace FurbAPIRest.DTO
{
    public class ComandaGetProduto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }
    }
}
