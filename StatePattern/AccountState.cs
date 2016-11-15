using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public abstract class AccountState
    {
        protected Account Account;

        protected AccountState(Account account)
        {
            Account = account;
        }

        internal abstract void Deposit(decimal amount);
        internal abstract void Open();
        internal abstract void Close();
        internal abstract void HolderVerified();
        internal abstract void Freeze();
        internal abstract void Withdrow(decimal amount);
    }
}
