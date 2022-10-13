using Banco.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();

        [HttpPost]
        public void AdicionaCliente([FromBody]Cliente cliente)
        {
            clientes.Add(cliente);
            Console.WriteLine(cliente.Nome);
        }
    }
}
