using System;
using Microsoft.AspNetCore.Mvc;
using Star8g.Attributes;
using Star8g.Exceptions;
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
            int remainingBalance;

            try
            {
                remainingBalance = _starCardService.DeductMoney(total);
            }
            catch (BalanceNotEnoughException ex)
            {
                var difference = total - ex.RemainingBalance;
                var depositTotal = CalculateDepositTotal(difference);
                _starCardService.Deposit(depositTotal);
                remainingBalance = _starCardService.DeductMoney(total);
            }

            return new
            {
                Status = true,
                Balance = remainingBalance
            };
        }
        
        private static int CalculateDepositTotal(int difference)
        {
            return (int)Math.Ceiling(difference / 500.0) * 500;
        }
    }
}