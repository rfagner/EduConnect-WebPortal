using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail não é um endereço de e-mail válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação da senha não correspondem.")]
        [Display(Name = "Confirmar Senha")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP deve ter 8 caracteres.")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }
    }
}