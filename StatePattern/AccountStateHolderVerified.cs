using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class AccountStateHolderVerified : AccountState
    {
        public AccountStateHolderVerified(Account account) : base(account)
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
        }

        internal override void Freeze()
        {
            Account.State = new AccountStateFreezed(Account);
        }

        internal override void Withdrow(decimal amount)
        {
            Account.Balance -= amount;
        }
    }
}
