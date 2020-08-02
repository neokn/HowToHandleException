using System;

namespace Star8g.Exceptions
{
    public class BalanceNotEnoughException : Exception
    {
        public readonly int RemainingBalance;

        public BalanceNotEnoughException(int remainingBalance) : base($"Remaining Balance: {remainingBalance}")
        {
            RemainingBalance = remainingBalance;
        }
    }
}