using Core;
using Core.Service;

namespace Service
{
    public class TipoFuncionarioService : ITipoFuncionario
    {
        private readonly RestauranteContext _context;

        public TipoFuncionarioService(RestauranteContext context)
        {
            _context = context;
        }

        public int Create(Tipofuncionario tipoFuncionario)
        {
            _context.Add(tipoFuncionario);
            _context.SaveChanges();
            return (int)tipoFuncionario.Id;
        }

        public void Edit(Tipofuncionario tipoFuncionario)
        {
            _context.Tipofuncionarios.Update(tipoFuncionario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Tipofuncionarios.Find((uint)id);
            if (entity != null)
            {
                _context.Tipofuncionarios.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Tipofuncionario Get(int id)
        {
            return _context.Tipofuncionarios.FirstOrDefault(t => t.Id == (uint)id)
                   ?? throw new KeyNotFoundException($"Tipo de funcionário com ID {id} não encontrado.");
        }

        public IEnumerable<Tipofuncionario> GetAll()
        {
            return _context.Tipofuncionarios.ToList();
        }
    }
}