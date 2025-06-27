using MovieApi.Models.Entities;

namespace MovieApi.Models.DTOs
{
    public class GetGenreDTOs
    {
        public string Name { get; set; }
        public List<MovieInGenreDTO> Movies { get; set; }
        
    }
}
