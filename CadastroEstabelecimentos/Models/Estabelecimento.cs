using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroEstabelecimentos.Models
{
    public class Estabelecimento
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Razão Social")]

        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        public string Categoria { get; set; }

        public string Status { get; set; }

        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        public string Conta { get; set; }

    }
}
