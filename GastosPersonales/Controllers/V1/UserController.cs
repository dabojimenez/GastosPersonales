using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GastosPersonales.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola desde el UserController");
        }
    }
}
