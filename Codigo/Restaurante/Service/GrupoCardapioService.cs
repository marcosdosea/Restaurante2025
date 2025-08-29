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

        /// <summary>
        /// Função para criar um novo grupo de cardápio.
        /// </summary>
        /// <param name="grupocardapio"></param>
        /// <returns></returns>
        public uint Create(Grupocardapio grupocardapio)
        {
            _context.Add(grupocardapio);
            _context.SaveChanges();

            return grupocardapio.Id;
        }

        /// <summary>
        /// Função para obter um grupo de cardápio pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Grupocardapio Get(uint id)
        {
            return _context.Grupocardapios.FirstOrDefault(g => g.Id == id) 
                   ?? throw new KeyNotFoundException($"Grupo de cardápio não encontrado.");
        }

        /// <summary>
        /// Função para obter todos os grupos de cardápio.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Grupocardapio> GetAll()
        {
            return _context.Grupocardapios.ToList();
        }

        /// <summary>
        /// Função para editar um grupo de cardápio existente.
        /// </summary>
        /// <param name="grupocardapio"></param>
        public void Edit(Grupocardapio grupocardapio)
        {
            var existingGroup = _context.Grupocardapios.Find(grupocardapio.Id);

            if (existingGroup != null)
            {
                existingGroup.Nome = grupocardapio.Nome;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Função para deletar um grupo de cardápio pelo ID.
        /// </summary>
        /// <param name="id"></param>
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
