using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PedidoService : IPedidoService
    {
        private readonly RestauranteContext _context;

        public PedidoService(RestauranteContext context)
        {
            _context = context;
        }

        public int Create(Pedido pedido)
        {
            
            if (!AtendimentoPodeReceberPedidos((int)pedido.IdAtendimento))
                throw new InvalidOperationException("Atendimento não está ativo ou não pode receber pedidos");

            pedido.DataHoraSolicitacao = DateTime.Now;
            pedido.Status = "S"; 

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return (int)pedido.Id;
        }

        public void Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Pedidos.Find((uint)id);
            if (entity != null)
            {
                _context.Pedidos.Remove(entity);
                _context.SaveChanges();
            }
        }

        public Pedido Get(int id)
        {
            return _context.Pedidos
                .Include(p => p.IdAtendimentoNavigation)
                    .ThenInclude(a => a.IdMesaNavigation)
                .Include(p => p.IdGarcomNavigation)
                .Include(p => p.Pedidoitemcardapios)
                    .ThenInclude(pic => pic.IdItemCardapioNavigation)
                .FirstOrDefault(p => p.Id == (uint)id)
                ?? throw new KeyNotFoundException($"Pedido com ID {id} não encontrado.");
        }

        public IEnumerable<Pedido> GetAll()
        {
            return _context.Pedidos
                .Include(p => p.IdAtendimentoNavigation)
                .Include(p => p.IdGarcomNavigation)
                .Include(p => p.Pedidoitemcardapios)
                .ToList();
        }

        public IEnumerable<Pedido> GetByAtendimento(int idAtendimento)
        {
            return _context.Pedidos
                .Where(p => p.IdAtendimento == (uint)idAtendimento)
                .Include(p => p.IdGarcomNavigation)
                .Include(p => p.Pedidoitemcardapios)
                    .ThenInclude(pic => pic.IdItemCardapioNavigation)
                .ToList();
        }

        public IEnumerable<Pedido> GetByStatus(string status)
        {
            return _context.Pedidos
                .Where(p => p.Status == status)
                .Include(p => p.IdAtendimentoNavigation)
                .Include(p => p.IdGarcomNavigation)
                .ToList();
        }

        public bool AtendimentoPodeReceberPedidos(int idAtendimento)
        {
            var atendimento = _context.Atendimentos
                .FirstOrDefault(a => a.Id == (uint)idAtendimento);

            return atendimento != null && atendimento.Status == "I";
        }
    }
}