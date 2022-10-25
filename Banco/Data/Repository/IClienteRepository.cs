using Banco.Models;
using System.Collections.Generic;

namespace Banco.Data.Repository
{
    public interface IClienteRepository
    {
        public void AddClienteRepository(Cliente cliente);
        public Cliente GetById(int id);
        public IEnumerable<Cliente> GetAll();
        public void PutClientRepository(Cliente clienteNovo);
    }
}