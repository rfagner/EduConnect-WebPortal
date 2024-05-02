using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel; 

namespace EscolaOnline.Models
{
    public class Assignment
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "O assunto é obrigatório.")]
        [DisplayName("Assunto")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [DisplayName("Nome do Aluno")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "O nome do professor é obrigatório.")]
        [DisplayName("Nome do Professor")]
        public string? TeacherName { get; set; }

        [Required(ErrorMessage = "A nota é obrigatória.")]
        [DisplayName("Nota")]
        public string? Grade { get; set; }

        [Required(ErrorMessage = "A classe é obrigatória.")]
        [DisplayName("Classe")]
        public string? Class { get; set; }

        [NotMapped]
        [DisplayName("Upload de Arquivo")]
        public IFormFile? FileUpload { get; set; }

        [DisplayName("Caminho do Arquivo")]
        public string? FilePath { get; set; }
    }
}
