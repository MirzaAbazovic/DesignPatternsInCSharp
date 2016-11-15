using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class AccountStateClosed : AccountState
    {
        public AccountStateClosed(Account account) : base(account)
        {
            
        }

        internal override void Deposit(decimal amount)
        {
            //do nothing
        }

        internal override void Open()
        {
            Account.State = new AccountStateOpened(Account);
        }

        internal override void Close()
        {
            //do nothing
        }

        internal override void HolderVerified()
        {
            
        }

        internal override void Freeze()
        {
            
        }

        internal override void Withdrow(decimal amount)
        {
        }
    }
}
