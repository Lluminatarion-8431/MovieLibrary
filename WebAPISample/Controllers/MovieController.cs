using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ApplicationContext _context;
        public MovieController(ApplicationContext context)
        {
            _context = context;
        }
        // GET api/movie
        [HttpGet]
        public IActionResult Get()
        {
            // Retrieve all movies from db logic
            var movies = _context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/movie/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            // return Ok(movie);
            var selectedMovieId = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            return Ok(selectedMovieId);
        }

        // POST api/movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            // Create movie in db logic
            Movie movie = new Movie();
            movie.Title = value.Title;
            movie.Genre = value.Genre;
            movie.Director = value.Director;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie);
        }

        // PUT api/movie
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            // Update movie in db logic
           var moviesInDb = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            moviesInDb.Title = movie.Title;
            moviesInDb.Director = movie.Director;
            moviesInDb.Genre = movie.Genre;
            _context.Movies.Update(moviesInDb);
            _context.SaveChanges();
            return Ok(moviesInDb);
        }

        // DELETE api/movie/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete movie from db logic
            var movie = _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
    }
}