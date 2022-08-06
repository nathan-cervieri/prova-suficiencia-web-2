namespace FurbAPIRest.DTO.Comandas
{
    public class ComandaGetProdutoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Preco { get; set; }
    }
}
