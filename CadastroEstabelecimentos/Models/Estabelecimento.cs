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
        [StringLength(20,ErrorMessage ="CNPJ inválido!")]
        [RegularExpression(@"\d{2}.\d{3}.\d{3}.\d{4}.\d{2}", ErrorMessage=" Regex CNPJ inválido!")]
        public string CNPJ { get; set; }

        [EmailAddress(ErrorMessage ="Digite um email válido")]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [StringLength(20)]
        public string Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataDeCadastro { get; set; }

        public string Categoria { get; set; }

        public string Status { get; set; }

        [Display(Name = "Agência")]
        [StringLength(5)]
        public string Agencia { get; set; }

        [StringLength(8)]
        public string Conta { get; set; }

    }
}
