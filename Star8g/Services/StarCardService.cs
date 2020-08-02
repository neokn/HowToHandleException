using System;
using System.Net.Http;
using Star8g.Exceptions;

namespace Star8g.Services
{
    public class StarCardService
    {
        private int _balance = 50;

        public int Balance => _balance;
        
        public int DeductMoney(int total)
        {
            if (total > _balance)
            {
                throw new BalanceNotEnoughException(_balance);
            }
            
            _balance -= total;
            return _balance;
        }
        
        public void Deposit(int total)
        {
            try
            {
                CreditCardApi(total);
                _balance += total;
            }
            catch (Exception ex)
            {
                throw new DepositException(_balance, $"Credit Card API Fail, try to deposit ${total}", ex);
            }
        }

        private void CreditCardApi(int total)
        {
            var networkFail = new Random().Next()  % 2 == 0;
            if (networkFail)
            {
                throw new HttpRequestException();
            }
            // credit card api deduct {total} success
        }
    }
}