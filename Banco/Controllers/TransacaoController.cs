using Banco.Application.Services;
using Banco.Data.Repository;
using Banco.Models;
using Banco.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoRepository transacaoRepository, ITransacaoService transacaoService)
        {
            _transacaoRepository = transacaoRepository;
            _transacaoService = transacaoService;
        }

        [HttpPost("TransferenciaDepositoSaque")]
        public IActionResult AdicionaTransacao(int contaOrigem, int contaDestino, [FromBody] CriaTransacaoDto transacaoDto)
        {
            Transacao transacao = new Transacao()
            {
            };

            if (transacaoDto != null)
            {
                transacao.DataTransacao = transacaoDto.DataTransacao;
                transacao.ValorTransacao = transacaoDto.ValorTransacao;
                transacao.TipoTransacao = transacaoDto.TipoTransacao;
                transacao.ContaOrigem = contaOrigem;
                transacao.ContaDestino = contaDestino;
            }

            _transacaoService.Transacao(transacao);
            
            return CreatedAtAction(nameof(GetById), new { Id = transacao.Id }, transacao);
        }
                
        [HttpGet]
        public IActionResult RecuperaTransacao()
        {
            return Ok(_transacaoService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var transacao = _transacaoService.GetById(id);

            if (transacao != null)
            {
                return Ok(transacao);
            }
            return NotFound();
        }

        [HttpGet("ExtractByConta/{contaId}")]
        public IActionResult ExtractByConta(int contaId)
        {
            return Ok(_transacaoService.ExtractByConta(contaId));
        }
    }
}
