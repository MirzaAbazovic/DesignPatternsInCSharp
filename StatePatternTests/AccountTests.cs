using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using StatePattern;
using System;

namespace StatePatternTests
{
    [TestFixture]
    public class AccountTests
    {
        //private Account account=null;

        [OneTimeSetUp]
        public void TestSetup() {
            //account = new Account(null);
            //account.Open();
            //account.HolderVerified();
        }


        // 1#: Deposit 10; Close; Deposit 1 => Balance == 10
        [Test]
        public void ShouldNotDepositOnClosedAccount()
        {
            //Arange
            Account account = new Account(() => { });
            account.Deposit(10m);
            account.Close();
            //Act
            account.Deposit(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.Balance, 10m);
        }
        // 2#: Deposit 10; Deposit 1 => Balance == 11
        [Test]
        public void ShuldDepositOnOpenAccount()
        {

            //Arange
            Account account = new Account(() => { });
            account.Deposit(10m);
            //Act
            account.Deposit(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.Balance, 11m);
        }
        // 3#: Deposit 10; Withdrow 1 => Balance == 9
        [Test]
        public void ShuldNotWithdrowAsUnverifiedAccount()
        {
            //Arange
            Account account = new Account(() => { });
            account.Deposit(10m);
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.Balance, 10m);
        }
        // 4#: Deposit 10; Verify; Close; Withdrow 1 => Balance == 10
        [Test]
        public void ShuldNotWithdrowOnClosedAccount()
        {
            //Arange
            Account account = new Account(() => { });
            account.Deposit(10m);
            account.HolderVerified();
            account.Close();
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.Balance, 10m);
        }
        // 5#: Deposit 10; Verify; Withdrow 1 => Balance == 9
        [Test]
        public void ShuldWithdrowOnVerifiedAccount()
        {
            //Arange
            Account account = new Account(() => { });
            account.Deposit(10m);
            account.HolderVerified();
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.Balance, 9m);
        }
        // 6#: Deposit 10; Freeze , Deposit 1 => OnUnfreeze was called
        [Test]
        public void ShuldInvokeOnUnfeezeOnDepositWhenFrozen()
        {
            //Arange
            bool invoked = false;
            Account account = new Account(() => {
                invoked = true;
            });
            account.Open();
            account.HolderVerified();
            account.Freeze();
            //Act
            account.Deposit(10m);
            //Assert
            NUnit.Framework.Assert.AreEqual(invoked, true);
        }
        // 7#: Deposit 10; Freeze , Deposit 1 => IsFrozen == false
        [Test]
        public void ShuldUnfeezeOnDeposit()
        {
            //Arange
            Account account = new Account(() => { });
            account.Open();
            account.HolderVerified();
            account.Freeze();
            //Act
            account.Deposit(10m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.IsFrozen,false);
        }
        // 8#: Deposit 10; Deposit 1 => OnUnfreeze was not called
        [Test]
        public void ShuldInvokeOnUnfeezeOnDepositWhenNotFrozen()
        {
            //Arange
            bool invoked = false;
            Account account = new Account(() => {
                invoked = true;
            });
            account.Open();
            account.HolderVerified();
            //Act
            account.Deposit(10m);
            //Assert
            NUnit.Framework.Assert.AreEqual(invoked, false);
        }
        // 9#: Deposit 10; Verify; Freeze; Withdrow 1 => OnUnfreeze was called
        [Test]
        public void ShuldInvokeOnUnfeezeOnWithdrowWhenNotFrozen()
        {
            //Arange
            bool invoked = false;
            Account account = new Account(() => {
                invoked = true;
            });
            account.Open();
            account.HolderVerified();
            account.Deposit(10m);
            account.Freeze();
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(invoked, true);
        }
        // 10#: Deposit 10; Verify; Freeze; Withdrow 1 => IsFrozen == false
        [Test]
        public void ShuldUnfeezeOnWithdrowWhenFrozen()
        {
            //Arange
            Account account = new Account(() => { });
            account.Open();
            account.HolderVerified();
            account.Deposit(10m);
            account.Freeze();
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(account.IsFrozen, false);
        }
        // 11#: Deposit 10; Verify; Withdrow 1 => OnUnfreeze was not called
        [Test]
        public void ShuldNotInvokeOnUnfeezeOnWithdrowWhenNotFrozen()
        {
            //Arange
            bool invoked = false;
            Account account = new Account(() => {
                invoked = true;
            });
            account.Open();
            account.HolderVerified();
            account.Deposit(10m);
            //Act
            account.Withdrow(1m);
            //Assert
            NUnit.Framework.Assert.AreEqual(invoked, false);
        }



    }
}
