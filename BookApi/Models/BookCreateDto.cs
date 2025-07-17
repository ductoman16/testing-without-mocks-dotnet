namespace BookApi.Models
{
    public class BookCreateDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int PublishedYear { get; set; }
        public string? Description { get; set; }
    }
}