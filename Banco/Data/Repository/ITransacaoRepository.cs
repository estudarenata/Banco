using Banco.Models;

namespace Banco.Data.Repository
{
    public interface ITransacaoRepository
    {
        public Transacao GetById(int id);
    }
}
