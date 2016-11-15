using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Account
    {
        public decimal Balance { get;  set; }
        public AccountState State  { get; set; }
        public Action OnUfreezeAction  { get; set; }


        public Account(Action onUnfreezeAction)
        {
               OnUfreezeAction = onUnfreezeAction;
               //initial state
               State = new AccountStateOpened(this);
        }
        // 1#: Deposit 10; Close; Deposit 1 => Balance == 10
        // 2#: Deposit 10; Deposit 1 => Balance == 11
        // 6#: Deposit 10; Freeze , Deposit 1 => OnUnfreeze was called
        // 7#: Deposit 10; Freeze , Deposit 1 => IsFrozen == false
        // 8#: Deposit 10; Deposit 1 => OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            State.Deposit(amount);
        }

        // 3#: Deposit 10; Withdrow 1 => Balance == 9
        // 4#: Deposit 10; Verify; Close; Withdrow 1 => Balance == 10
        // 5#: Deposit 10; Verify; Withdrow 1 => Balance == 9
        // 9#: Deposit 10; Verify; Freeze; Withdrow 1 => OnUnfreeze was called
        // 10#: Deposit 10; Verify; Freeze; Withdrow 1 => IsFrozen == false
        // 11#: Deposit 10; Verify; Withdrow 1 => OnUnfreeze was not called
        public void Withdrow(decimal amount)
        {
            State.Withdrow(amount);
        }
        public void Open()
        {
            State.Open();
        }
        public void Close()
        {
            State.Close();
        }

        public void HolderVerified()
        {
            State.HolderVerified();
        }
        public void Freeze()
        {
            State.Freeze();
        }
    }
}
