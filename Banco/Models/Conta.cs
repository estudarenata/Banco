using System;
using System.ComponentModel.DataAnnotations;

namespace Banco.Models
{
    public class Conta
    {
        public Conta()
        {
        }

        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public int NumeroDaConta { get; set; }
        public decimal DepositoInicial { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Saldo { get; set; }

        public bool TemSaldoSuficiente(decimal valor) 
        {
            return Saldo >= valor;
        }

        public decimal DebitaDoSaldo(decimal valor)
        {
            Saldo -= valor;
            return Saldo;
        }

        public decimal CreditaDoSaldo(decimal valor)
        {
            Saldo += valor;
            return Saldo;
        }
    }
}

