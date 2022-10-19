using Banco.Models;

namespace Banco.Data.Repository
{
    public interface IClienteRepository
    {
        public Cliente GetById(int id);
    }
}