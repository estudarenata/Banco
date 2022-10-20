using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Models.Dto
{
    public class CriaContaDto
    {
        public int NumeroDaConta { get; set; }
        public decimal DepositoInicial { get; set; }
        public DateTime DataAbertura { get; set; }
        public decimal Saldo { get; set; }
    }
}
