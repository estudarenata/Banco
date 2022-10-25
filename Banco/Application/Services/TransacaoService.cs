using Banco.Data.Repository;
using Banco.Models;
using System;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ITransacaoRepository _transacaoRepository;


        public TransacaoService(IContaRepository contaRepository, ITransacaoRepository transacaoRepository)
        {
            _contaRepository = contaRepository;
            _transacaoRepository = transacaoRepository;
        }

        public void Transferencia(Transacao transacao) 
        {
            var contaOrigem = _contaRepository.GetByNumeroDaConta(transacao.ContaOrigem);
            var contaDestino = _contaRepository.GetByNumeroDaConta(transacao.ContaDestino);

            if (contaOrigem == null || contaDestino == null || transacao.ValorTransacao == 0)
            {
                throw new Exception("Transacao Inválida!");
            }

            if (!contaOrigem.TemSaldoSuficiente(transacao.ValorTransacao)) 
            {
                throw new Exception("Saldo Insuficiente!");
            }

            contaOrigem.Saque(transacao.ValorTransacao);
            contaDestino.Deposito(transacao.ValorTransacao);

            _contaRepository.Atualiza(contaOrigem);
            _contaRepository.Atualiza(contaDestino);

            _transacaoRepository.Adiciona(transacao);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoRepository.GetAll();
        }

        public Transacao GetById(int id)
        {
            return _transacaoRepository.GetById(id);
        }
    }
}
