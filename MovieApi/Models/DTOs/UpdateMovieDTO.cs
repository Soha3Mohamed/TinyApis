namespace MovieApi.Models.DTOs
{
    public class UpdateMovieDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string YearOfRelease { get; set; }
        public int GenreId { get; set; }
    }
}
