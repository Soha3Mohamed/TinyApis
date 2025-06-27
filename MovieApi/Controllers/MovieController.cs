using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using MovieApi.Models.Data;
using MovieApi.Models.DTOs;
using MovieApi.Models.Entities;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public MovieController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var allMovies = dbContext.Movies.Include(m => m.Genre)
                            .Select(m => new GetMovieDTO
                            {
                                Title = m.Title,
                                Description = m.Description,
                                YearOfRelease = m.YearOfRelease,
                                GenreName = m.Genre.Name,
                            }).ToList();
            return Ok(allMovies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = dbContext.Movies
                     .Include(m => m.Genre)
                     .FirstOrDefault(m => m.Id == id);
            

            if (movie == null)
            {
                return NotFound();
            }
            var movieDto = new GetMovieDTO 
            {
                Title = movie.Title,
                Description = movie.Description,
                YearOfRelease = movie.YearOfRelease,
                GenreName = movie.Genre.Name,
            };
            return Ok(movieDto);
        }
        [HttpPost]
        public IActionResult AddMovie(AddMovieDTO addMovieDTO)
        {
            var movie = new Movie
            {
                 Title = addMovieDTO.Title,
                 Description = addMovieDTO.Description,
                 YearOfRelease = addMovieDTO.YearOfRelease,
                 GenreId = addMovieDTO.GenreId,
            };
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            return Ok(movie);
        }

          
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieDTO updateMovieDTO)
        {
            var movie = dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = updateMovieDTO.Title;
            movie.Description = updateMovieDTO.Description;
            movie.YearOfRelease = updateMovieDTO.YearOfRelease;
            movie.GenreId = updateMovieDTO.GenreId;

            dbContext.SaveChanges();
            return Ok(movie);
        }

        [HttpDelete]
        public IActionResult DeleteMovie(int id)
        {
            var movie = dbContext.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            dbContext.Movies.Remove(movie);
            dbContext.SaveChanges();
            return Ok(movie);
        }

    }
}
