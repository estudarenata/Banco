using Banco.Data;
using Banco.Data.Repository;
using Banco.Models;
using Banco.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Banco.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransacaoController : ControllerBase
    {
        private BancoContext _context;
        private readonly IContaRepository _contaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoController(BancoContext context, ITransacaoRepository transacaoRepository, IContaRepository contaRepository)
        {
            _context = context;
            _transacaoRepository = transacaoRepository;
            _contaRepository = contaRepository;
        }

        [HttpPost]
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

            var verificaContaOrigem = _contaRepository.GetByContaOrigem(transacao.ContaOrigem);
            var verificaContaDestino = _contaRepository.GetByContaDestino(transacao.ContaDestino);

            if (verificaContaOrigem == null || verificaContaDestino == null || transacao.ValorTransacao == 0)
            {
                return NotFound();
            }


            _context.Transacoes.Add(transacao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaTransacaoPorId), new { Id = transacao.Id }, transacao);
        }

        [HttpGet]
        public IEnumerable<Transacao> RecuperaTransacao()
        {
            return _context.Transacoes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaTransacaoPorId(int id)
        {
            Transacao transacao = _transacaoRepository.GetById(id);

            if (transacao != null)
            {
                return Ok(transacao);
            }
            return NotFound();
        }
    }
}
