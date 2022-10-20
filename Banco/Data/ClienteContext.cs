using Banco.Models;
using Microsoft.EntityFrameworkCore;

namespace Banco.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> opt) : base (opt)
        {
            
        }

        public  DbSet<Cliente> Clientes { get; set; }

        public  DbSet<Conta> Contas { get; set; }

        public DbSet<Transacao> Transacoes { get; set; }
    }
}
