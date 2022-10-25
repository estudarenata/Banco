using Banco.Models;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public interface IContaService
    {
        void AddConta(Conta conta);
        IEnumerable<Conta> GetAll();
        Conta GetById(int id);
        IEnumerable<Conta> GetByClientIdAll(int clienteId);
    }
}
