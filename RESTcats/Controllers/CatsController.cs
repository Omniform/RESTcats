using Microsoft.AspNetCore.Mvc;
using RESTcats.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTcats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private CatsRepositoryList _repo;

        public CatsController(CatsRepositoryList repo)
        {
            _repo = repo;
        }

        // GET: api/<CatsController>
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return _repo.GetAllCats();
        }

        // GET api/<CatsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Cat> Get(int id)
        {
            
            Cat? cat = _repo.GetCatById(id);
            if (cat == null)
            {
                return NotFound();
            }

            return Ok(cat);
        }

        // POST api/<CatsController>
        [HttpPost]
        public Cat Post([FromBody] Cat newCat)
        {
            return _repo.AddCat(newCat);
        }

        // PUT api/<CatsController>/5
        [HttpPut("{id}")]
        public Cat? Put(int id, [FromBody] Cat value)
        {
            return _repo.UpdateCat(id, value);
        }

        // DELETE api/<CatsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public Cat? Delete(int id)
        {
            return _repo.RemoveCat(id);
        }

        [HttpOptions]
        public void Options()
        {
            
        }
    }
}
