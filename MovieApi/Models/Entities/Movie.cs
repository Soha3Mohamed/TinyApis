namespace MovieApi.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string YearOfRelease { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
   
    }
}
