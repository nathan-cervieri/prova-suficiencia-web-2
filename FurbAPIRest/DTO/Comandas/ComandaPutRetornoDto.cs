using FurbAPIRest.DTO.Produtos;
using FurbAPIRest.Models;

namespace FurbAPIRest.DTO.Comandas
{
    public class ComandaPutRetornoDto
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ProdutoRetornoDto> Produtos { get; set; }

        public ComandaPutRetornoDto(Comanda comanda)
        {
            Id = comanda.Id;
            UsuarioId = comanda.Usuario.Id;
            NomeUsuario = comanda.Usuario.Nome;
            TelefoneUsuario = comanda.Usuario.TelefoneUsuario;
            Produtos = comanda.ProdutosComanda.Select(p => new ProdutoRetornoDto(p)).ToList();
        }
    }
}
