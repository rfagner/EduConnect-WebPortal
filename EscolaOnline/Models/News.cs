using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        [DisplayName("Conteúdo")]
        public string? Content { get; set; }

        [DisplayName("Data de Publicação")]
        public DateTime PublishDate { get; set; }
    }
}
