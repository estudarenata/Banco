using Banco.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banco.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required]
        //[StringLength(2, ErrorMessage = "O tipo é obrigatório")]
        public TipoStatus Tipo { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O CPF / CNPJ é obrigatório")]
        public string CpfCnpj { get; set; }

        public string Endereco { get; set; }

        [StringLength(11, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

        //public ICollection<Conta> Contas { get; set; } = new List<Conta>();


        //public Cliente(int id, string nome, TipoStatus tipo, string cpfCnpj, string endereco, string telefone)
        //{
        //    Id = id;
        //    Nome = nome;
        //    Tipo = tipo;
        //    CpfCnpj = cpfCnpj;
        //    Endereco = endereco;
        //    Telefone = telefone;
        //}
    }
}
