using Banco.Models;

namespace Banco.Data.Repository
{
    public interface IContaRepository
    {
        public Conta GetById(int id);
        public Conta GetByNumeroDaConta(int numeroDaConta);
        public void Atualiza(Conta conta);
    }
}
