namespace Core.Service
{
    public interface IGrupoCardapioService
    {
        int Create(Grupocardapio grupoCardapio);
        void Edit(Grupocardapio grupoCardapio);
        void Delete(int id);
        Grupocardapio Get(int id);
        IEnumerable<Grupocardapio> GetAll();
    }
}
