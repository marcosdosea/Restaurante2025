using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class RestauranteService : IRestauranteService
    {
        private readonly RestauranteContext _context;

        public RestauranteService(RestauranteContext context)
        {
            _context = context;
        }

        public int Create(Restaurante restaurante)
        {
            _context.Add(restaurante);
            _context.SaveChanges();
            return (int)restaurante.Id;
        }

        public void Edit(Restaurante restaurante)
        {
            _context.Restaurantes.Update(restaurante);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Restaurantes.Find((uint)id);
            if (entity != null)
            {
                _context.Restaurantes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Restaurante Get(int id)
        {
            return _context.Restaurantes
                .Include(r => r.IdTipoRestauranteNavigation)
                .FirstOrDefault(r => r.Id == (uint)id)
                ?? throw new KeyNotFoundException($"Restaurante com ID {id} não encontrado.");
        }

        public IEnumerable<Restaurante> GetAll()
        {
            return _context.Restaurantes
                .Include(r => r.IdTipoRestauranteNavigation)
                .ToList();
        }
    }
}