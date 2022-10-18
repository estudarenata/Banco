using System;
using System.ComponentModel.DataAnnotations;


namespace Banco.Models
{
    public class Conta
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string NumeroDaConta { get; set; }

        public Double DepositoInicial { get; set; }

        public DateTime DataAbertura { get; set; }

        public Double Saldo { get; set; }
    }
}
