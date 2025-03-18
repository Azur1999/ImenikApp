using Microsoft.AspNetCore.Mvc;
using ImenikApp.Models;
using ImenikApp.Services;
using ImenikApp.DTO;

namespace ImenikApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobeController : ControllerBase
    {
        private readonly IOsobaService _osobaService;

        public OsobeController(IOsobaService osobaService)
        {
            _osobaService = osobaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Osoba>>> GetAllOsobe() {
            return Ok(await _osobaService.GetAllOsobe());  
        }


        // GET: api/Osobe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Osoba>> GetOsoba(int id) {
            return Ok (await _osobaService.GetOsobaById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Osoba>> PostOsoba(OsobaDTO osoba) {
            await _osobaService.CreateOsoba(osoba);
            return StatusCode(201);
        }

        // PUT: api/Osober/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, OsobaDTO osoba){  
            await _osobaService.UpdateOsoba(id,osoba);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba(int id) {
           await _osobaService.DeleteOsoba(id);
           return StatusCode(201);
        }
    }
}
