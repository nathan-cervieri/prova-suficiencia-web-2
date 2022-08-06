using FurbAPIRest.Contracts;
using FurbAPIRest.Models;

namespace FurbAPIRest.DTO.Comandas
{
    public class ComandaPostRetornoDto
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ProdutoContractItem> Produtos { get; set; }

        public ComandaPostRetornoDto(Comanda comanda)
        {
            Id = comanda.Id;
            IdUsuario = comanda.Usuario.Id;
            NomeUsuario = comanda.Usuario.Nome;
            TelefoneUsuario = comanda.Usuario.TelefoneUsuario;
            Produtos = comanda.ProdutosComanda.Select(p =>
            {
                return new ProdutoContractItem
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco,
                };
            }).ToList();
        }
    }
}
