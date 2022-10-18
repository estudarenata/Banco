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
    }
}
