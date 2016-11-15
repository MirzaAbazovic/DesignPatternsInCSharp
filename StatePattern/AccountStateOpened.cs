using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class AccountStateOpened : AccountState
    {
        
        public AccountStateOpened(Account account) : base(account)
        {
            
        }

        internal override void Deposit(decimal amount)
        {
            Account.Balance += amount;
        }

        internal override void Open()
        {

        }

        internal override void Close()
        {
            Account.State = new AccountStateClosed(Account);
        }

        internal override void HolderVerified()
        {

            Account.State = new AccountStateHolderVerified(Account);
        }

        internal override void Freeze()
        {
            Account.State = new AccountStateFreezed(Account);
        }

        internal override void Withdrow(decimal amount)
        {
            throw new UnauthorizedAccessException("Account holder is not verified");    
        }
    }
}
