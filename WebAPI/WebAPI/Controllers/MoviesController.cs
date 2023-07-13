using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }
        //get all movies method
        /// <summary>
        /// Retrieves all movies from the database.
        /// </summary>
        /// <returns>A list of movies.</returns>
        /// <response code="200">Returns the list of movies.</response>
        /// <response code="404">If no movies are found.</response>
        [HttpGet]
        [Authorize(Roles ="Admin")]

        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            return await _dbContext.Movies.ToListAsync();
        }
        //get movie by id method
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        //post method
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Movie>> CreateMovie( Movie movie)
        {
            if (_dbContext.Movies.Any(m => m.Title == movie.Title))
            {
                return Conflict("A movie with the same title already exists.");
            }
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }
        //update method
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var existingMovie = await _dbContext.Movies.FindAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            // Update the properties of the existing movie
            existingMovie.Title = updatedMovie.Title;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.ReleaseDate = updatedMovie.ReleaseDate;

            _dbContext.Entry(existingMovie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
        //delete method
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
