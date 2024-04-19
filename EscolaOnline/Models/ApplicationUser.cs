using Microsoft.AspNetCore.Identity;
using System;

namespace EscolaOnline.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }        
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; } // Aluno, Professor, Pai
    }
}
