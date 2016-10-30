using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class Account
    {
        public decimal Balance { get; private set; }
        public bool IsVerified { get; private set; }
        public bool IsClosed { get; private set; }
        public bool IsFrozen { get; private set; }
        private Action OnUnfreeze { get; }
        public Account(Action onUnfreeze=null)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        // 1#: Deposit 10; Close; Deposit 1 => Balance == 10
        // 2#: Deposit 10; Deposit 1 => Balance == 11
        // 6#: Deposit 10; Freeze , Deposit 1 => OnUnfreeze was called
        // 7#: Deposit 10; Freeze , Deposit 1 => IsFrozen == false
        // 8#: Deposit 10; Deposit 1 => OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            if (IsClosed)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            Balance += amount;
        }

        // 3#: Deposit 10; Withdrow 1 => Balance == 9
        // 4#: Deposit 10; Verify; Close; Withdrow 1 => Balance == 10
        // 5#: Deposit 10; Verify; Withdrow 1 => Balance == 9
        // 9#: Deposit 10; Verify; Freeze; Withdrow 1 => OnUnfreeze was called
        // 10#: Deposit 10; Verify; Freeze; Withdrow 1 => IsFrozen == false
        // 11#: Deposit 10; Verify; Withdrow 1 => OnUnfreeze was not called
        public void Withdrow(decimal amount)
        {
            if (!IsVerified)
                return;
            if (IsClosed)
                return;
            if (amount > Balance)
                return;
            if (this.IsFrozen)
            {
                this.IsFrozen = false;
                this.OnUnfreeze();
            }
            Balance -= amount;
        }
        public void Open()
        {
            this.IsClosed = false;
        }
        public void Close()
        {
            this.IsClosed = true;
        }

        public void HolderVerified()
        {
            IsVerified = true;
        }
        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.IsFrozen = true;
        }
    }
}
