using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MBAMODULO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        [HttpGet("mensagem")]
        [Authorize]
        public IActionResult GetMensagemSecreta()
        {
            return Ok("Acesso autorizado");
        }
    }
}
