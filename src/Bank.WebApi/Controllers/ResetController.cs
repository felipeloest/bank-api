using Bank.Application.CommandStack.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Bank.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly IResetAppService _appService;

        public ResetController(IResetAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        // POST api/<ResetController>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await _appService.ResetAsync();
            return Ok();
        }
    }
}
