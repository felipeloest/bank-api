using Bank.ApiModels.CommandModels.Event;
using Bank.Application.CommandStack.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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

            var response = await _appService.DepositAsync(new InsertBalance.Request { Id = request.Destination, Amount = request.Amount });
            if (response.Success)
            {
                return StatusCode(201, new { destination = new { Id = response.Id.ToString(), Balance = response.Balance } });
            }

            return Forbid();
        }
    }
}
