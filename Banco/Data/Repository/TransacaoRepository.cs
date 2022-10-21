using Banco.Models;
using System.Linq;

namespace Banco.Data.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly BancoContext _context;

        public TransacaoRepository(BancoContext context)
        {
            _context = context;
        }

        public Transacao GetById(int id)
        {
            var transacao = _context.Transacoes.FirstOrDefault(transacao => transacao.Id == id);
            return transacao;
        }

        public void Adiciona(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
        }
    }
}