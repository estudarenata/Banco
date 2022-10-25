using Banco.Application.Services;
using Banco.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult AdicionaCliente([FromBody]Cliente cliente)
        {
            _clienteService.AddClienteService(cliente);

            return CreatedAtAction(nameof(GetById), new { Id = cliente.Id }, cliente);
        }

        [HttpGet]
        public IActionResult GetClient()
        {
            return Ok(_clienteService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteService.GetById(id);
            
            if(cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] Cliente clienteNovo)
        {
            var cliente = _clienteService.GetById(id);

            if (cliente == null) 
            {
                return NotFound("Cliente não existe");
            }
            cliente.Nome = clienteNovo.Nome;
            cliente.Tipo = clienteNovo.Tipo;
            cliente.CpfCnpj = clienteNovo.CpfCnpj;
            cliente.Endereco = clienteNovo.Endereco;
            cliente.Telefone = clienteNovo.Telefone;

            _clienteService.PutClient(clienteNovo);
            
            return Ok(clienteNovo);
        }
    }
}
