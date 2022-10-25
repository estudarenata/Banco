using Banco.Data.Repository;
using Banco.Models;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void AddClienteService(Cliente cliente) 
        {
            _clienteRepository.AddClienteRepository(cliente);
        }

        public IEnumerable<Cliente> GetAll() 
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(int id) 
        {
            return _clienteRepository.GetById(id);
        }

        public void PutClient(Cliente clienteNovo)
        {
            _clienteRepository.PutClientRepository(clienteNovo);
        }
    }
}
