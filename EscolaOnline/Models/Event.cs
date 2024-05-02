using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EscolaOnline.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [DisplayName("Título")]
        public string? Title { get; set; }

        [DisplayName("Descrição")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [DisplayName("Localização")]
        public string? Location { get; set; }

        [DisplayName("Data do Evento")]
        public DateTime EventDate { get; set; }
    }
}
