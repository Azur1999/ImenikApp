using ImenikApp.DTO;
using ImenikApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImenikApp.Controllers {

   [Route("api/[controller]")]
   [ApiController]
   public class DrzavaController : ControllerBase {
   private readonly IDrzavaService _drzavaService;

   public DrzavaController (IDrzavaService drzavaService) {
        _drzavaService = drzavaService;
   }

    [HttpGet]
   public async Task<ActionResult<DrzavaDTO>> getDrzave() {
     return Ok (await _drzavaService.GetAllDrzave());
   }
    
   [HttpGet("{id}")]
   public async Task<ActionResult> getDrzava(int id){
        return Ok (await _drzavaService.GetDrzavaById(id));
   }

   [HttpGet("gradovi/{id}")]
   public async Task<ActionResult<GradDTO>> getGradoviByDrzavaId (int drzavaId) {
      return Ok (await _drzavaService.getGradoviByDrzava(drzavaId));
   }
   }
}