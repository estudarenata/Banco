using Banco.Models;

namespace Banco.Data.Repository
{
    public interface IContaRepository
    {
        public Conta GetById(int id);
        public Conta GetByContaOrigem(int contaOrigem);
        public Conta GetByContaDestino(int contaDestino);
    }
}
