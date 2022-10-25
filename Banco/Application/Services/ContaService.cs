using Banco.Data.Repository;
using Banco.Models;
using System;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly IClienteRepository _clienteRepository;

        public ContaService(IContaRepository contaRepository, IClienteRepository clienteRepository) 
        {
            _contaRepository = contaRepository;
            _clienteRepository = clienteRepository;
        }

        public void AddConta(Conta conta)
        {
            var verificaCliente = _clienteRepository.GetById(conta.ClienteId);

            if (verificaCliente == null)
            {
                throw new Exception("Cliente inexistente!");
            }

            _contaRepository.AddContaRepository(conta);
        }

        public IEnumerable<Conta> GetAll() 
        {
            return _contaRepository.GetAll();
        }

        public Conta GetById(int id) 
        {
            return _contaRepository.GetById(id);
        }

        public IEnumerable<Conta> GetByClientIdAll(int clienteId) 
        {
            return _contaRepository.GetByClientIdAll(clienteId);
        }
    }
}
