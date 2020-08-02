using Microsoft.AspNetCore.Mvc;
using Star8g.Attributes;
using Star8g.Services;

namespace Star8g.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [StarCardExceptionFilter]
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
            var remainingBalance = _starCardService.DeductMoneyWithAutoDeposit(total);
            
            return new
            {
                Status = true,
                Balance = remainingBalance
            };
        }
    }
}