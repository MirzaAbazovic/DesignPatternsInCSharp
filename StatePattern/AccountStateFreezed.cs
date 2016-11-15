using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class AccountStateFreezed : AccountState
    {
        public AccountStateFreezed(Account account) : base(account)
        {
            
        }

        internal override void Deposit(decimal amount)
        {
            Account.Balance += amount;
            Account.OnUfreezeAction();
            Account.State= new AccountStateOpened(Account);

        }

        internal override void Open()
        {

        }

        internal override void Close()
        {

        }

        internal override void HolderVerified()
        {

        }

        internal override void Freeze()
        {
        }

        internal override void Withdrow(decimal amount)
        {
            Account.Balance -= amount;
            Account.OnUfreezeAction();
            Account.State = new AccountStateOpened(Account);
        }
    }
}
