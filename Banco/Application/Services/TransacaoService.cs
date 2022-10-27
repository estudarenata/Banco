using Banco.Data.Repository;
using Banco.Models;
using Banco.Models.Enums;
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

        public void Transacao(Transacao transacao) 
        {
            if (transacao.TipoTransacao == TransacaoStatus.Transferencia)
            {
                Transferencia(transacao);
            }
            else
            {                
                DepositoSaque(transacao);
            }
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

            transacao.ValorTaxaTransferencia();
            contaDestino.CreditaDoSaldo(transacao.ValorTransacao);
            contaOrigem.DebitaDoSaldo(transacao.ValorTransacao + transacao.ValorTaxaTransacao);
            
            _contaRepository.AtualizaSaldo(contaOrigem);
            _contaRepository.AtualizaSaldo(contaDestino);

            _transacaoRepository.Adiciona(transacao);
        }

        public void DepositoSaque(Transacao transacao) 
        {
            var contaOrigem = _contaRepository.GetByNumeroDaConta(transacao.ContaOrigem);
            
            if (contaOrigem == null || transacao.ValorTransacao == 0)
            {
                throw new Exception("Transacao Inválida!");
            }

            if (transacao.TipoTransacao == TransacaoStatus.Deposito) 
            {
                transacao.ValorTaxaDeposito(transacao.ValorTransacao);
                contaOrigem.DebitaDoSaldo(transacao.ValorTaxaTransacao);
                contaOrigem.CreditaDoSaldo(transacao.ValorTransacao);
            }
            else
            {
                transacao.ValorTaxaSaque();
                contaOrigem.DebitaDoSaldo(transacao.ValorTransacao + transacao.ValorTaxaTransacao);
            }
            
            transacao.ContaDestino = 0;
            
            _contaRepository.AtualizaSaldo(contaOrigem);
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

        public IEnumerable<Transacao> ExtractByConta(int contaId) 
        {
            return _transacaoRepository.ExtractByContaRepository(contaId);
        }
            
    }
}
