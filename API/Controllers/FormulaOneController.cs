using FormulaOne.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaOneController : ControllerBase
    {
        private readonly ApiDbContext dbContext;
        public FormulaOneController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<FormulaOneController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> Get()
        {
            return await dbContext.Drivers.ToListAsync();
        }

        // GET api/<FormulaOneController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FormulaOneController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FormulaOneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FormulaOneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
