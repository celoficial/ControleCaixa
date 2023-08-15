using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.Presentation.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/error")]
    public class ErrorsController : ControllerBase
    {
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
