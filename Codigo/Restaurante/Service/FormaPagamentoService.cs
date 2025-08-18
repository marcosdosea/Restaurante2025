using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly RestauranteContext _context;

        public FormaPagamentoService(RestauranteContext context)
        {
            _context = context;
        }

        public int Create(Formapagamento formaPagamento)
        {
            _context.Add(formaPagamento);
            _context.SaveChanges();
            return (int)formaPagamento.Id;
        }

        public void Delete(int id)
        {
            var formaPagamento = _context.Formapagamentos.Find(id);
            if (formaPagamento != null)
            {
                _context.Formapagamentos.Remove(formaPagamento);
                _context.SaveChanges();
            }
        }

        public void Edit(Formapagamento formaPagamento)
        {
            _context.Formapagamentos.Update(formaPagamento);
            _context.SaveChanges();
        }

        public Formapagamento Get(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(uint id)
        {
            return _context.Formapagamentos.FirstOrDefault(f => f.Id == id) 
                ?? throw new KeyNotFoundException($"Forma de pagamento com ID {id} não encontrada.");
        }

        public IEnumerable<Formapagamento> GetAll()
        {
            return _context.Formapagamentos.ToList();
        }
    }
}
