using Microsoft.AspNetCore.Mvc;
using ImenikApp.Models;
using ImenikApp.Services;
using ImenikApp.DTO;
using FluentValidation;

namespace ImenikApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OsobeController : ControllerBase {
        private readonly IOsobaService _osobaService;
        private readonly IValidator<OsobaPostRequestDTO> _osobaValidator;

        public OsobeController(IOsobaService osobaService,IValidator<OsobaPostRequestDTO> osobaValidator) {
            _osobaService = osobaService;
            _osobaValidator = osobaValidator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OsobaResponseDTO>>> GetAllOsobe() {
            return Ok(await _osobaService.GetAllOsobe());   
        }

        // GET: api/Osobe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OsobaResponseDTO>> GetOsoba(int id) {
            return Ok (await _osobaService.GetOsobaById(id));
        }

        [HttpPost]
        public async Task<ActionResult<OsobaPostResponseDTO>> PostOsoba(OsobaPostRequestDTO osoba) {
            var validationResult = await _osobaValidator.ValidateAsync(osoba);
            if ((!ModelState.IsValid) || (!validationResult.IsValid))  
                return BadRequest(ModelState);
            
            var response = await _osobaService.CreateOsoba(osoba);
            return CreatedAtAction(nameof(GetOsoba), new { id = response.OsobaId }, response);
        }

        // PUT: api/Osober/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOsoba(int id, OsobaPutRequestDTO osoba){  
            await _osobaService.UpdateOsoba(id,osoba);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOsoba(int id) {
           await _osobaService.DeleteOsoba(id);
           return NoContent();
        }
    }
}
