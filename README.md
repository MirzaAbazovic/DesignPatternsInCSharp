# Design patterns in C&#35;
State pattern is behavioral software design pattern that helps You to avoid a lot of if else and/or swich statements by changing state of object (and thus his behaviour) by changing his property (into different state objects) and delegating actions(method) that change state to that objects.
![state pattern image](https://raw.githubusercontent.com/MirzaAbazovic/DesignPatternsInCSharp/master/StatePattern/statePattern.PNG "Class diagram from code example")
 Class Account has flags and has to check their values in methods to fulfil business logic (user requirements) 
 * Before state pattern [tag v1.0](https://github.com/MirzaAbazovic/DesignPatternsInCSharp/tree/v1.0/StatePattern/Account.cs)
 ```cs
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
```
* Class Account after state pattern is applied is readable and maintainable. As You can see methods are delegated to current state of Account and in those method change of state might happen.
After state pattern [tag v2.0](https://github.com/MirzaAbazovic/DesignPatternsInCSharp/tree/v2.0/StatePattern/Account.cs)
```cs
public class Account
    {
        public decimal Balance { get;  set; }
        public AccountState State  { get; set; }
        public Action OnUfreezeAction  { get; set; }


        public Account(Action onUnfreezeAction)
        {
               OnUfreezeAction = onUnfreezeAction;
               State = new AccountStateOpened(this);
        }
     
	 public void Deposit(decimal amount)
        {
            State.Deposit(amount);
        }

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
```