using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstabelecimentos.Models
{
    public class Estabelecimento
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }


        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(14,ErrorMessage ="CNPJ inválido!")]
        
        public string CNPJ { get; set; }

        [EmailAddress(ErrorMessage ="Digite um email válido")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [StringLength(11)]
        [Phone]
        public string Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime)]

        public DateTime DataDeCadastro { get; set; }

        public string Categoria { get; set; }

        public string Status { get; set; }

        [Display(Name = "Agência")]
        [StringLength(4)]
        public string Agencia { get; set; }

        [StringLength(6)]
        public string Conta { get; set; }

    }
}
