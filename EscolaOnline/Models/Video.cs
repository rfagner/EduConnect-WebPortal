using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.Models
{
    public class Video
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "A URL é obrigatória.")]
        [DisplayName("URL")]
        [Url(ErrorMessage = "A URL fornecida não é válida.")]
        public string? URL { get; set; }

        [DisplayName("Data de Adição")]
        public DateTime DateAdded { get; set; }
    }
}
