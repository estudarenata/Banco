using Banco.Models;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public interface IClienteService
    {
        void AddClienteService(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void PutClient(Cliente clienteNovo);
    }
}
