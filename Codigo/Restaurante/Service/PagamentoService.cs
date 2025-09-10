using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PagamentoService : IPagamentoService
    {
        private readonly RestauranteContext _context;

        public PagamentoService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
            return pagamento.Id;
        }

        public IEnumerable<Pagamento> GetByAtendimento(uint idAtendimento)
        {
            return _context.Pagamentos.Where(p => p.IdAtendimento == idAtendimento).ToList();
        }

        public decimal GetTotalPago(uint idAtendimento)
        {
            return _context.Pagamentos.Where(p => p.IdAtendimento == idAtendimento).Sum(p => p.Valor);
        }
    }
}
