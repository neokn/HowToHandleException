using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Star8g.Exceptions;

namespace Star8g.Attributes
{
    public class StarCardExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BalanceNotEnoughException balanceNotEnough)
            {
                context.Result = new JsonResult(new
                {
                    Status = false,
                    Balance = balanceNotEnough.RemainingBalance
                });
            }
        }
    }
}