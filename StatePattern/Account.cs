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
