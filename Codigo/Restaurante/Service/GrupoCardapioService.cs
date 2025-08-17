using Core;
using Core.Service;

namespace Service
{
    public class GrupoCardapioService : IGrupoCardapioService
    {
        private readonly RestauranteContext _context;

        public GrupoCardapioService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Grupocardapio grupocardapio)
        {
            _context.Add(grupocardapio);
            _context.SaveChanges();

            return grupocardapio.Id;
        }

        public Grupocardapio Get(uint id)
        {
            return _context.Grupocardapios.FirstOrDefault(g => g.Id == id) 
                   ?? throw new KeyNotFoundException($"Grupo de cardápio não encontrado.");
        }

        public IEnumerable<Grupocardapio> GetAll()
        {
            return _context.Grupocardapios.ToList();
        }

        public void Edit(Grupocardapio grupocardapio)
        {
            var existingGroup = _context.Grupocardapios.Find(grupocardapio.Id);

            if (existingGroup != null)
            {
                existingGroup.Nome = grupocardapio.Nome;
                _context.SaveChanges();
            }
        }

        public void Delete(uint id)
        {
            var grupocardapio = _context.Grupocardapios.Find(id);
            if (grupocardapio != null)
            {
                _context.Grupocardapios.Remove(grupocardapio);
                _context.SaveChanges();
            }
        }
    }
}
