using FurbAPIRest.Models;

namespace FurbAPIRest.DTO.Comandas
{
    public class ComandaGetDto
    {
        public long IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ComandaGetProdutoDto> Produtos { get; set; }

        public ComandaGetDto(Comanda comanda)
        {
            IdUsuario = comanda.UsuarioId;
            NomeUsuario = comanda.Usuario.Nome;
            TelefoneUsuario = comanda.Usuario.TelefoneUsuario;

            Produtos = comanda.ProdutosComanda.Select(p => new ComandaGetProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco
            }).ToList();
        }
    }
}
