using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models.Data;
using MovieApi.Models.DTOs;
using MovieApi.Models.Entities;
using System.Reflection;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public GenreController( ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var allGenres = dbContext.Genres
        .Include(g => g.Movies)
        .Select(g => new GetGenreDTOs
        {
            Name = g.Name,
            Movies = g.Movies.Select(m => new MovieInGenreDTO
            {
                Title = m.Title,
                YearOfRelease = m.YearOfRelease
            }).ToList()
        }).ToList();

            return Ok(allGenres);
        }

        [HttpPost]
        public IActionResult AddGenre(AddGenreDTO addGenreDTO)
        {
            //should i write something to make sure the genre doesn't exist first, id is not a good idea it should be name
            var genre = new Genre
            {
                Name = addGenreDTO.Name,
            };
            dbContext.Genres.Add(genre);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id , UpdateGenreDTO updateGenreDTO)
        {
            var genre = dbContext.Genres.Find(id);
            if (genre ==null)
            {
                return NotFound();
            }
            genre.Name = updateGenreDTO.Name;
            dbContext.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int id)
        {
            var genre = dbContext.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
