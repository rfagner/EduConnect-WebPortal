namespace EscolaOnline.Models
{
    public class AcademicActivity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string? AuthorId { get; set; }
        public ApplicationUser Author { get; set; }
    }

}
