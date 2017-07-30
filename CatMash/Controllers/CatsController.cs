using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatMash.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CatMash.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CatsController : Controller
    {
        private readonly CatMashContext _context;

        public CatsController(CatMashContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public IEnumerable<Cat> GetCats()
        {
            return _context.Cats
                .OrderByDescending(x => x.Rating)
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCat([FromRoute] string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cat = await _context.Cats
                .Include(x => x.Histories).ThenInclude(x => x.Match).ThenInclude(x => x.CatB)
                .Include(x => x.Histories).ThenInclude(x => x.Match).ThenInclude(x => x.CatA)
                .SingleOrDefaultAsync(m => m.CatId == id);

            if (cat == null)
                return NotFound();

            return Ok(JsonConvert.SerializeObject(cat, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}