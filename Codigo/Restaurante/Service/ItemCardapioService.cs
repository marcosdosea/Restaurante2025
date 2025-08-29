using Core;
using Core.Service;

namespace Service
{
    public class ItemCardapioService : IItemCardapioService
    {
        private readonly RestauranteContext _context;

        public ItemCardapioService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Itemcardapio itemCardapio)
        {
            itemCardapio.IdGrupoCardapio = 1;
            itemCardapio.IdRestaurante = 1;
            _context.Add(itemCardapio);
            _context.SaveChanges();

            return itemCardapio.Id;
        }

        public void Edit(Itemcardapio itemCardapio)
        {
            var existingItem = _context.Itemcardapios.Find(itemCardapio.Id);
            if (existingItem != null)
            {
                existingItem.Nome = itemCardapio.Nome;
                existingItem.Preco = itemCardapio.Preco;
                existingItem.Detalhes = itemCardapio.Detalhes;
                existingItem.Ativo = itemCardapio.Ativo;
                existingItem.Disponivel = itemCardapio.Disponivel;
                existingItem.IdRestaurante = itemCardapio.IdRestaurante;
                existingItem.IdGrupoCardapio = itemCardapio.IdGrupoCardapio;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var itemCardapio = _context.Itemcardapios.Find(id);
            if (itemCardapio != null)
            {
                _context.Itemcardapios.Remove(itemCardapio);
                _context.SaveChanges();
            }
        }

        public Itemcardapio Get(int id)
        {
            return _context.Itemcardapios.FirstOrDefault(i => i.Id == id) 
                   ?? throw new KeyNotFoundException($"Item de cardápio não encontrado.");
        }

        public IEnumerable<Itemcardapio> GetAll()
        {
            return _context.Itemcardapios.ToList();
        }
    }
}
