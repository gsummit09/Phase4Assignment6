using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Movie_Assignment.Models;

namespace WebApi_Movie_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        static List<Movies> Movie = new List<Movies>()
        {
            new Movies{Id=1,Mname="Jawan",Starcast="Sharukhan",Director="Atlee"},
            new Movies{Id=2,Mname="Jawan1",Starcast="Sharukhan1",Director="Atlee1"},
            new Movies{Id=3,Mname="Jawan2",Starcast="Sharukhan2",Director="Atlee2"},
            new Movies{Id=4,Mname="Jawan3",Starcast="Sharukhan3",Director="Atlee3"},
        };
        [HttpGet(Name ="Get Movies")]
        public IEnumerable<Movies>GetMovies()
        {
            return Movie;
        }
        [HttpGet("{id}")]
        public ActionResult<Movies>GetMovie(int id)
        {
            Movies movie = Movie.SingleOrDefault(m=>m.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }
        [HttpPost]
        public ActionResult<Movies> Post(Movies newmovie)
        {
            Movie.Add(newmovie);
            return CreatedAtAction(nameof(GetMovie),newmovie);
        }
        [HttpPut("{id}")]
        public ActionResult<Movies> put(int id, Movies upmovie)
        {
            Movies mv = Movie.SingleOrDefault(m => m.Id == id);
            if(mv == null)
            {
                return NotFound();
            }
            else
            {
                mv.Mname = upmovie.Mname;
                mv.Starcast = upmovie.Starcast;
                mv.Director = upmovie.Director;
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Movies> Delete(int id)
        {
            Movies movies = Movie.SingleOrDefault(m => m.Id == id);
            if(movies == null)
            {
                return NotFound();
            }
            else
            {
                Movie.Remove(movies);
                return NoContent();
            }
        }
    }
}
