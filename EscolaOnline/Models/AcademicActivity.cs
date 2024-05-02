using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.Models
{
    public class AcademicActivity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [DisplayName("Data de Publicação")]
        public DateTime PublishDate { get; set; }

        [DisplayName("ID do Autor")]
        public string? AuthorId { get; set; }

        [DisplayName("Autor")]
        public ApplicationUser? Author { get; set; }
    }
}
