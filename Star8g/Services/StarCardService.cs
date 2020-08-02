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
    }
}