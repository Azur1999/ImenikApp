using ImenikApp.DTO;
using ImenikApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ImenikApp.Controllers {

   [Route("api/[controller]")]
   [ApiController]
   public class GradController : ControllerBase {
   private readonly IGradService _gradService;
   public GradController (IGradService gradService) {
        _gradService = gradService;
   }
   [HttpGet]
   public async Task<ActionResult<GradResponseDTO>> getGradovi() {
     return Ok (await _gradService.GetAllGrad());
   }
    
   [HttpGet("{id}")]
   public async Task<ActionResult<GradResponseDTO>> getGrad(int id) {
        return Ok (await _gradService.GetGradById(id));
   }

   }
}