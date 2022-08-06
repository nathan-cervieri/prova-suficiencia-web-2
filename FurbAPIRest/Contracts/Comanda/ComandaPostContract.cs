
namespace FurbAPIRest.Contracts.Comanda
{
    public class ComandaPostContract
    {
        public long IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ProdutoContractItem> Produtos { get; set; }
    }
}
