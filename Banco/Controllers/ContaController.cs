using Banco.Data;
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

    public class ContaController : ControllerBase
    {
        private BancoContext _context;

        public ContaController(BancoContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult AdicionaConta([FromBody] Conta conta)
        {
            if (conta != null)
            {
                conta.Saldo = conta.DepositoInicial;
            }
                      
            _context.Contas.Add(conta);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaContasPorId), new { Id = conta.Id }, conta);
        }

        [HttpGet]
        public IEnumerable<Conta> RecuperaContas()
        {
            return _context.Contas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaContasPorId(int id)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);
            if (conta != null)
            {
                return Ok(conta);
            }

            return NotFound();
        }

    }
}
