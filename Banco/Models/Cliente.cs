using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public bool Tipo { get; set; }
        public int CpfCnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
