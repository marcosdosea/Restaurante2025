namespace Core.Service
{
    public interface IFormaPagamentoService
    {
        int Create(Formapagamento formaPagamento);
        void Edit(Formapagamento formaPagamento);
        void Delete(int id);
        Formapagamento Get(int id);
        IEnumerable<Formapagamento> GetAll();
        object Get(uint id);
    }
}
