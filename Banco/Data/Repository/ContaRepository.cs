using Banco.Models;
using System.Linq;

namespace Banco.Data.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly BancoContext _context;

        public ContaRepository(BancoContext context)
        {
            _context = context;
        }

        public Conta GetById(int id)
        {
            var conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            return conta;
        }
    }
}
