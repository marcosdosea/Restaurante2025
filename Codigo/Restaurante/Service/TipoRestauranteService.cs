using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class TipoRestauranteService : ITipoRestauranteService
    {
        private readonly RestauranteContext _context;

        public TipoRestauranteService(RestauranteContext context)
        {
            _context = context;
        }

        public int Create(Tiporestaurante tiporestaurante)
        {
            _context.Add(tiporestaurante);
            _context.SaveChanges();
            return (int)tiporestaurante.Id;
        }

        public void Edit(Tiporestaurante tiporestaurante)
        {
            _context.Tiporestaurantes.Update(tiporestaurante);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Tiporestaurantes.Find((uint)id);
            if (entity != null)
            {
                _context.Tiporestaurantes.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Tiporestaurante Get(int id)
        {
            return _context.Tiporestaurantes.FirstOrDefault(t => t.Id == (uint)id)
                   ?? throw new KeyNotFoundException($"Tipo de restaurante com ID {id} não encontrado.");
        }

        public IEnumerable<Tiporestaurante> GetAll()
        {
            return _context.Tiporestaurantes.ToList();
        }
    }
}