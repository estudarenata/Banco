using Banco.Data;
using Banco.Data.Repository;
using Banco.Models;
using Banco.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContaController : ControllerBase
    {
        private BancoContext _context;
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;

        public ContaController(BancoContext context, IClienteRepository clienteRepository, IContaRepository contaRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
        }

        [HttpPost]
        public IActionResult AdicionaConta(int clienteId,[FromBody] CriaContaDto contaDto)
        {
            Conta conta = new Conta()
            {
            };

            if (contaDto != null)
            {
                conta.NumeroDaConta  = contaDto.NumeroDaConta;
                conta.DepositoInicial = contaDto.DepositoInicial;
                conta.DataAbertura = contaDto.DataAbertura;
                conta.Saldo = contaDto.DepositoInicial;
                conta.ClienteId = clienteId;
            }

            var verificaCliente = _clienteRepository.GetById(conta.ClienteId);

            if (verificaCliente != null)
            {
                _context.Contas.Add(conta);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaContasPorId), new { Id = conta.Id }, conta);
            }
            return NotFound();
        }

        [HttpGet]
        public IEnumerable<Conta> RecuperaContas()
        {
            return _context.Contas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaContasPorId(int id)
        {
            Conta conta = _contaRepository.GetById(id);

            if (conta != null)
            {
                return Ok(conta);
            }

            return NotFound();
        }

        [HttpGet("pesquisaPorCliente/{clienteId}")]
        public IEnumerable<Conta> RecuperaContasPorClienteId(int clienteId)
        {
            return _context.Contas.Where(contas => contas.ClienteId == clienteId);
        }
    }
}
