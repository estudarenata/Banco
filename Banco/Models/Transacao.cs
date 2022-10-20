﻿using Banco.Models.Enums;
using System;

namespace Banco.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        public DateTime DataTransacao { get; set; }
        public decimal ValorTransacao { get; set; }
        public TransacaoStatus TipoTransacao { get; set; }
    }
}

