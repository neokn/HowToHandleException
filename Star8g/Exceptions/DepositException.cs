using System;

namespace Star8g.Exceptions
{
    public class DepositException : Exception
    {
        public readonly int RemainingBalance;
        
        public DepositException(int remainingBalance, string message, Exception innerException) : base(message, innerException)
        {
            RemainingBalance = remainingBalance;
        }
    }
}