using Banco.Models;
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

        public Conta GetById(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            return conta;
        }

        public Conta GetByContaOrigem(int contaOrigem)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.NumeroDaConta == contaOrigem);
            return conta;
        }

        public Conta GetByContaDestino(int contaDestino)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.NumeroDaConta == contaDestino);
            return conta;
        }
    }
}
