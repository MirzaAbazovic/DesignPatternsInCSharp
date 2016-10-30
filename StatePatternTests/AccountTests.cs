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


        [Test]
        public void ShouldNotDepositOnNotVerifiedAccount()
        {
            Account account = new Account(() => { });
            account.Open();
            account.Deposit(10.4m);
            NUnit.Framework.Assert.AreEqual(account.Balance, 10.4m);
        }
        [Test]
        public void ShouldDepositOnOpenAndVerifiedAccount()
        {
            Account account = new Account(() => { });
            account.Open();
            account.HolderVerified();
            account.Deposit(10.4m);
            NUnit.Framework.Assert.AreEqual(account.Balance, 10.4m);
        }
        [Test]
        public void ShouldNotDepositOnClosedAccount()
        {
            Account account = new Account(() => { });
            account.Open();
            account.HolderVerified();
            account.Close();
            account.Deposit(10.4m);
            NUnit.Framework.Assert.AreEqual(account.Balance, 0m);
        }

        [Test]
        public void ShouldFreezeAccount()
        {
            //Arange
            Account account = new Account(() => { });
            account.Open();
            account.HolderVerified();
            //Act
            account.Freeze();
            //Asert
            NUnit.Framework.Assert.AreEqual(account.IsFrozen,true);
        }
        [Test]
        public void ShouldUnfreezeOnDeposit()
        {
            //Arange
            Account account = new Account(()=> { });
            account.Open();
            account.HolderVerified();
            account.Freeze();
            //Act
            account.Deposit(10.4m);
            //Asert
            NUnit.Framework.Assert.AreEqual(account.IsFrozen,false);
        }

    }
}
