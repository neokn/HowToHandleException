using Microsoft.AspNetCore.Mvc;
using Star8g.Exceptions;
using Star8g.Services;

namespace Star8g.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StarCardController : ControllerBase
    {
        private readonly StarCardService _starCardService;

        public StarCardController(StarCardService starCardService)
        {
            _starCardService = starCardService;
        }

        [HttpGet]
        public dynamic Wallet()
        {
            return new
            {
                Status = true,
                _starCardService.Balance
            };
        }

        [HttpPost]
        public dynamic Pay([FromForm] int total)
        {
            try
            {
                var remainingBalance = _starCardService.DeductMoney(total);

                return new
                {
                    Status = true,
                    Balance = remainingBalance
                };
            }
            catch (BalanceNotEnoughException ex)
            {
                return new
                {
                    Status = false,
                    Balance = ex.RemainingBalance
                };
            }
        }
    }
}