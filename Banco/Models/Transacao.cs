using Banco.Models.Enums;
using System;

namespace Banco.Models
{
    public class Transacao
    {
        public Transacao() 
        {
        }
        
        public int Id { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public DateTime DataTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public TransacaoStatus TipoTransacao { get; set; }
        public decimal ValorTaxaTransacao { get; set; }
        

        public decimal ValorTaxaDeposito(decimal valor)
        {
            ValorTaxaTransacao = valor * 0.01M;
            return ValorTaxaTransacao;
        }

        public void ValorTaxaSaque() 
        {
            ValorTaxaTransacao = 4;
        }

        public void ValorTaxaTransferencia() 
        {
            ValorTaxaTransacao = 1;
        }
    }
}

