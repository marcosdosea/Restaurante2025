using Core;
using Core.Service;


namespace Service
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly RestauranteContext _context;

        public FormaPagamentoService(RestauranteContext context)
        {
            _context = context;
        }

        public uint Create(Formapagamento formaPagamento)
        {
            _context.Add(formaPagamento);
            _context.SaveChanges();
            
            return formaPagamento.Id;
        }

        public Formapagamento Get(uint id)
        {
            return _context.Formapagamentos.FirstOrDefault(f => f.Id == id)
                   ?? throw new KeyNotFoundException($"Forma de pagamento não encontrada.");
        }
        public IEnumerable<Formapagamento> GetAll()
        {
            return _context.Formapagamentos.ToList();
        }

        public void Edit(Formapagamento formaPagamento)
        {
            var existingForma = _context.Formapagamentos.Find(formaPagamento.Id);
            if (existingForma != null)
            {
                existingForma.Nome = formaPagamento.Nome;
                _context.SaveChanges();
            }
        }

        public void Delete(uint id)
        {
            var formaPagamento = _context.Formapagamentos.Find(id);
            if (formaPagamento != null)
            {
                _context.Formapagamentos.Remove(formaPagamento);
                _context.SaveChanges();
            }
        }
    }
}
