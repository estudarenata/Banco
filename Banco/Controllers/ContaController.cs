using Banco.Application.Services;
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
        private readonly IContaService _contaService;

        public ContaController(BancoContext context, IClienteRepository clienteRepository, IContaRepository contaRepository, IContaService contaService)
        {
            _context = context;
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
            _contaService = contaService;
        }

        [HttpPost]
        public IActionResult AdicionaConta(int clienteId, [FromBody] CriaContaDto contaDto)
        {
            Conta conta = new Conta()
            {
            };

            if (contaDto != null)
            {
                conta.NumeroDaConta = contaDto.NumeroDaConta;
                conta.DepositoInicial = contaDto.DepositoInicial;
                conta.DataAbertura = contaDto.DataAbertura;
                conta.Saldo = contaDto.DepositoInicial;
                conta.ClienteId = clienteId;
            }

            _contaService.AddConta(conta);

            return CreatedAtAction(nameof(GetById), new { Id = conta.Id }, conta);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contaService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Conta conta = _contaService.GetById(id);

            if (conta != null)
            {
                return Ok(conta);
            }

            return NotFound();
        }

        [HttpGet("GetByClientId/{clienteId}")]
        public IActionResult GetByClientIdAll(int clienteId)
        {
            return Ok(_contaService.GetByClientIdAll(clienteId));
        }
    }
}
