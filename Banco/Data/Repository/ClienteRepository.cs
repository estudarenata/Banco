using Banco.Models;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BancoContext _context;

        public ClienteRepository(BancoContext context)
        {
            _context = context;
        }

        public void AddClienteRepository(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll() 
        {
            return _context.Clientes;
        }

        public Cliente GetById(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            return cliente;
        }

        public void PutClientRepository(Cliente clienteNovo) 
        {
            _context.SaveChanges();
        }
    }
}
