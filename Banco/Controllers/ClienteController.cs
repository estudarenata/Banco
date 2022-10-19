﻿using Banco.Data;
using Banco.Data.Repository;
using Banco.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {
        private BancoContext _context;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(BancoContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public IActionResult AdicionaCliente([FromBody]Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaClientesPorId), new { Id = cliente.Id }, cliente);
        }

        [HttpGet]
        public IEnumerable<Cliente> RecuperaClientes()
        {
            return _context.Clientes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaClientesPorId(int id)
        {
            Cliente cliente = _clienteRepository.GetById(id);
            
            if(cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] Cliente clienteNovo)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) 
            {
                return NotFound("Cliente não existe");
            }
            cliente.Nome = clienteNovo.Nome;
            cliente.Tipo = clienteNovo.Tipo;
            cliente.CpfCnpj = clienteNovo.CpfCnpj;
            cliente.Endereco = clienteNovo.Endereco;
            cliente.Telefone = clienteNovo.Telefone;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
