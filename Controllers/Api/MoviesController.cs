using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Vidly.Data;
using Vidly.Models;
using Vidly.Dto;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly VidlyContext _context;
        private readonly IMapper _mapper;

        public MoviesController(VidlyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
          if (_context.Movie == null)
          {
              return NotFound();
          }
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public ActionResult GetMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<MovieDto>(movie));
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Movies
        [HttpPost]
        public ActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movie.Add(movie);
            _context.SaveChanges();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
