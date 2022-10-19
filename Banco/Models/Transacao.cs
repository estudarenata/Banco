using Banco.Models.Enums;
using System;

namespace Banco.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public string ContaOrigem { get; set; }
        public string ContaDestino { get; set; }
        public DateTime DataTransacao { get; set; }
        public double ValorTransacao { get; set; }
        public TransacaoStatus TipoTransacao { get; set; }
        //public Conta Conta { get; set; }

        public Transacao()
        {
        }

        //public Transacao(int id, string contaOrigem, string contaDestino, DateTime dataTransacao, double valorTransacao, TransacaoStatus tipoTransacao, Conta conta)
        //{
        //    Id = id;
        //    ContaOrigem = contaOrigem;
        //    ContaDestino = contaDestino;
        //    DataTransacao = dataTransacao;
        //    ValorTransacao = valorTransacao;
        //    TipoTransacao = tipoTransacao;
        //    Conta = conta;
    }
}

