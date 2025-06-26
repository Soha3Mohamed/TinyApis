namespace BookApi.Models
{
    public class UpdateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }public int Id { get; set; }
    }
}
