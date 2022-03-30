using Bank.Application.CommandStack.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Bank.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly IResetAppService _appService;

        public ResetController(IResetAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpPost]
        [Produces("text/plain")]
        public async Task<IActionResult> Post()
        {
            await _appService.ResetAsync();
            return Ok("OK");
        }
    }
}
