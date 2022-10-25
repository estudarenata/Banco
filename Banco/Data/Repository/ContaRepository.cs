using Banco.Models;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private BancoContext _context;
        
        public ContaRepository(BancoContext context)
        {
            _context = context;
        }

        public void AddContaRepository(Conta conta) 
        {
            _context.Contas.Add(conta);
            _context.SaveChanges();
        }

        public IEnumerable<Conta> GetAll() 
        {
            return _context.Contas;
        }

        public Conta GetById(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            return conta;
        }

        public Conta GetByNumeroDaConta(int numeroDaConta)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.NumeroDaConta == numeroDaConta);
            return conta;
        }

        public void Atualiza(Conta conta)
        {
            _context.Contas.Update(conta);
            _context.SaveChanges();
        }

        public IEnumerable<Conta> GetByClientIdAll(int clienteId) 
        {
            var conta = _context.Contas.Where(contas => contas.ClienteId == clienteId);
            return conta;
        }
    }
}
