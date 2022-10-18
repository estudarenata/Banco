using Banco.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> opt) : base (opt)
        {
            
        }

        public  DbSet<Cliente> Clientes { get; set; }

        public  DbSet<Conta> Contas { get; set; }
    }
}
