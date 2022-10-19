using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Models.Dto
{
    public class CriaContaDto
    {
        public string NumeroDaConta { get; set; }
        public Double DepositoInicial { get; set; }
        public DateTime DataAbertura { get; set; }
        public Double Saldo { get; set; }
    }
}
