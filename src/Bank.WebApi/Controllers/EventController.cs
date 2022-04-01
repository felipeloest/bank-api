using Bank.ApiModels.CommandModels.Event;
using Bank.Application.CommandStack.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bank.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IAccountAppService _appService;

        public EventController(IAccountAppService appService)
        {
            _appService = appService ?? throw new ArgumentNullException(nameof(appService));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Event request)
        {
            if (request == null)
                return BadRequest();

            switch (request.Type)
            {
                case "deposit":
                    {
                        var response = await _appService.DepositAsync(new Deposit.Request { Id = request.Destination, Amount = request.Amount });
                        if (!response.Success)
                            return NotFound(0);

                        return StatusCode(201, new { destination = new { Id = response.Id.ToString(), Balance = response.Balance } });

                    }
                case "withdraw":
                    {
                        var response = await _appService.WithdrawAsync(new Withdraw.Request { Id = request.Origin, Amount = request.Amount });
                        if (!response.Success)
                            return NotFound(0);

                        return StatusCode(201, new { origin = new { Id = response.Id.ToString(), Balance = response.Balance } });
                    }
                case "transfer":
                    {
                        var response = await _appService.TransferAsync(new Transfer.Request { SourceId = request.Origin, Amount = request.Amount, TargetId = request.Destination });
                        if (!response.Success)
                            return NotFound(0);

                        return StatusCode(201, new { origin = new { Id = response.SourceId.ToString(), Balance = response.SourceBalance }, destination = new { Id = response.TargetId.ToString(), Balance = response.TargetBalance } });
                    }
                default:
                    return NotFound(0);
            }
        }
    }
}
