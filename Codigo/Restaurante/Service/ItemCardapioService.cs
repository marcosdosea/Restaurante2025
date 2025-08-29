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

        /// <summary>
        /// Função para criar um novo item de cardápio.
        /// </summary>
        /// <param name="itemCardapio"></param>
        /// <returns></returns>
        public uint Create(Itemcardapio itemCardapio)
        {
            _context.Add(itemCardapio);
            _context.SaveChanges();

            return itemCardapio.Id;
        }

        /// <summary>
        /// Função para editar um item de cardápio existente.
        /// </summary>
        /// <param name="itemCardapio"></param>
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

        /// <summary>
        /// Função para deletar um item de cardápio pelo ID.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var itemCardapio = _context.Itemcardapios.Find(id);
            if (itemCardapio != null)
            {
                _context.Itemcardapios.Remove(itemCardapio);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Função para obter um item de cardápio pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Itemcardapio Get(int id)
        {
            return _context.Itemcardapios.FirstOrDefault(i => i.Id == id) 
                   ?? throw new KeyNotFoundException($"Item de cardápio não encontrado.");
        }

        /// <summary>
        /// Função para obter todos os itens de cardápio.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Itemcardapio> GetAll()
        {
            return _context.Itemcardapios.ToList();
        }
    }
}
