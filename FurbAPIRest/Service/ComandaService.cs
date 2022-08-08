using FurbAPIRest.Contracts.Comanda;
using FurbAPIRest.DTO.Comandas;
using FurbAPIRest.Helpers;
using FurbAPIRest.Models;
using System.Data.Entity.Core;

namespace FurbAPIRest.Service
{
    public class ComandaService
    {
        private readonly DataContext _dataContext;
        private readonly ProdutoService _produtoService;
        private readonly UsuarioService _usuarioService;

        public ComandaService(DataContext dataContext,
            ProdutoService produtoService,
            UsuarioService usuarioService)
        {
            _dataContext = dataContext;
            _produtoService = produtoService;
            _usuarioService = usuarioService;
        }

        public List<ComandasGetListItem> GetComandas()
        {
            var comandas = _dataContext.Comandas.ToList();
            var comandasGetList = comandas.Select(c =>
            {
                return new ComandasGetListItem
                {
                    IdUsuario = c.UsuarioId,
                    NomeUsuario = c.Usuario.Nome,
                    TelefoneUsuario = c.Usuario.TelefoneUsuario
                };
            }).ToList();
            return comandasGetList;
        }

        public Comanda GetComanda(long id)
        {
            var comanda = _dataContext.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda == null)
            {
                throw new ObjectNotFoundException($"Não foi possível achar comanda com id {id}");
            }

            return comanda;
        }

        public ComandaGetDto GetComandaDto(long id)
        {
            var comanda = GetComanda(id);

            return new ComandaGetDto(comanda);
        }

        public ComandaPostRetornoDto PostComanda(ComandaPostContract comandaNova)
        {
            var comanda = new Comanda();

            var usuario = _usuarioService.GetUsuario(comandaNova.IdUsuario);
            comanda.Usuario = usuario;

            comanda.ProdutosComanda = comandaNova.Produtos.Select(p =>
            {
                return _produtoService.GetProduto(p.Id);
            }).ToList();

            var comandaTracking = _dataContext.Comandas.Add(comanda);
            _dataContext.SaveChanges();
            return new ComandaPostRetornoDto(comandaTracking.Entity);
        }

        public ComandaPutRetornoDto UpdateComanda(long comandaId, ComandaPutContract comandaAtualizar)
        {
            var comanda = GetComanda(comandaId);

            var produtosIdComanda = comanda.ProdutosComanda.Select(p => p.Id);
            var produtoIdAdicionar = comandaAtualizar.produtos.Where(p => !produtosIdComanda.Contains(p.Id)).Select(p => p.Id);

            foreach (var produtoId in produtoIdAdicionar)
            {
                var produto = _produtoService.GetProduto(produtoId);
                comanda.ProdutosComanda.Add(produto);
            }

            _dataContext.Comandas.Update(comanda);
            _dataContext.SaveChanges();
            return new ComandaPutRetornoDto(comanda);
        }

        public void DeleteComanda(long id)
        {
            var comanda = GetComanda(id);
            _dataContext.Comandas.Remove(comanda);
            _dataContext.SaveChanges();
        }

        public void ValidarComanda(Comanda comanda)
        {
            if(comanda == null)
            {
                throw new ArgumentNullException("Comanda não pode ser nula");
            }
        }
    }
}
