using Banco.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Models.Dto
{
    public class CriaTransacaoDto
    {
        public DateTime DataTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public TransacaoStatus TipoTransacao { get; set; }
    }
}
