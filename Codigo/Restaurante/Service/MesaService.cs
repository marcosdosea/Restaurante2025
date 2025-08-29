using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class MesaService : IMesaService
    {
        private readonly RestauranteContext _context;

        public MesaService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Mesa mesa)
        {
            mesa.IdRestaurante = 1;
            _context.Add(mesa);
            _context.SaveChanges();
            return (uint)mesa.Id;
        }

        public void Delete(int id) 
            {
            var existingMesa = _context.Mesas.Find(id);
            if (existingMesa != null)
            {
                _context.Mesas.Remove(existingMesa);
                _context.SaveChanges();
            }
        }

        public void Edit(Mesa mesa)
        {
            var existingMesa = _context.Mesas.Find(mesa.Id);
            if (existingMesa != null)
            {
                existingMesa.Numero = mesa.Numero;
                existingMesa.Capacidade = mesa.Capacidade;
                existingMesa.IdRestaurante = mesa.IdRestaurante;
                _context.SaveChanges();
            }
        }

        public Mesa Get(int id)
        {
            return _context.Mesas.FirstOrDefault(m => m.Id == id)
                   ?? throw new KeyNotFoundException($"Mesa não encontrada.");
        }

        public IEnumerable<Mesa> GetAll()
        {
            return _context.Mesas.ToList();
        }



    }
}
