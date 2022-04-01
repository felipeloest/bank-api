using Bank.ApiModels.QueryModels.Balance;
using Bank.Application.CommandStack.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountAppService _appService;

        public BalanceController(IAccountAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpGet()]
        public async Task<IActionResult> Get(int? account_id)
        {
            if (account_id == null)
                return BadRequest();

            var response = await _appService.GetBalanceAsync(new GetAccountBalance.Request { Id = account_id.Value });
            if (response.Success)
                return Ok(response.Balance);

            return NotFound(0);
        }
    }
}
