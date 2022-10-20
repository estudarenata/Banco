using Banco.Models.Enums;
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
        public TipoStatus Tipo { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O CPF / CNPJ é obrigatório")]
        public string CpfCnpj { get; set; }

        public string Endereco { get; set; }

        [StringLength(11, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
    }
}
