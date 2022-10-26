using Banco.Models;
using System.Collections.Generic;

namespace Banco.Data.Repository
{
    public interface ITransacaoRepository
    {
        public Transacao GetById(int id);
        void Adiciona(Transacao transacao);
        public IEnumerable<Transacao> GetAll();
        public IEnumerable<Transacao> ExtractByContaRepository(int contaId);
    }
}
