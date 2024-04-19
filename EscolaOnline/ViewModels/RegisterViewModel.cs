using System;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CEP deve ter 8 caracteres.")]
        public string CEP { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Bairro { get; set; }
        

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Tipo { get; set; } 
    }
}
