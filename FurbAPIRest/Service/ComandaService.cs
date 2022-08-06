using FurbAPIRest.Model;

namespace FurbAPIRest.Service
{
    public class ComandaService
    {
        private DataContext _dataContext;

        public ComandaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Comanda> GetComandas()
        {
            return _dataContext.Comandas.ToList();
        }

        public Comanda? GetComanda(long id)
        {
            var comanda = _dataContext.Comandas.FirstOrDefault(c => c.Id == id);
            if (comanda == null)
            {
                throw A();
            }

            return comanda;
        }
    }
}
