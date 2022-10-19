using Banco.Models;
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

        public Cliente GetById(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            return cliente;
        }
    }
}
