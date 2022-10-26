using Banco.Models;
using System.Collections.Generic;
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

        public IEnumerable<Transacao> GetAll()
        {
            return _context.Transacoes;
        }

        public IEnumerable<Transacao> ExtractByContaRepository(int contaId) 
        {
            var extrato = _context.Transacoes.Where(extrato => extrato.ContaOrigem == contaId);
            return extrato;
        }
    }
}