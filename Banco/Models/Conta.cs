using System;
using System.ComponentModel.DataAnnotations;

namespace Banco.Models
{
    public class Conta
    {
        [Key]
        //[Required]
        public int Id { get; set; }

        //[ForeignKey(Cliente.Id)]
        //[Required]
        public int ClienteId { get; set; }

        //[Required]
        public string NumeroDaConta { get; set; }

        public Double DepositoInicial { get; set; }

        public DateTime DataAbertura { get; set; }

        public Double Saldo { get; set; }



        //public Cliente Cliente { get; set; }

        //public ICollection<Transacao> Contas { get; set; } = new List<Transacao>();

        public Conta()
        {
        
        }
    }
}

