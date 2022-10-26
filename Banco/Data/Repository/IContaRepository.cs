using Banco.Models;
using System.Collections.Generic;

namespace Banco.Data.Repository
{
    public interface IContaRepository
    {
        public void AddContaRepository(Conta conta);
        public IEnumerable<Conta> GetAll();
        public Conta GetById(int id);
        public Conta GetByNumeroDaConta(int numeroDaConta);
        public void AtualizaSaldo(Conta conta);
        public IEnumerable<Conta> GetByClientIdAll(int clienteId);
    }
}
