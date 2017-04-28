using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class BankAccountTestClass
    {
        //NUnit Tests against Bank Account

        public static int initialAmount = 3000;
        public static int withdrawSum1 = 700;
        public static int withdrawSum2 = 1200;

        public static int expectedAmount;

        public static BankAcount account = null;

        [SetUp]
        public void BankAccountInitializer()
        {
            account = new BankAcount(initialAmount);
            expectedAmount =  initialAmount - (int)(withdrawSum1 * 1.05);
        }


        [Test]
        public void BankAccountNegativeTest()
        {
            // Write a test that check that exception is thrown when you instantiate BankAccount with negative money
            Assert.Throws(typeof(ArgumentException), () => { BankAcount aaa = new BankAcount(-111); });
        }

        //NUnit Tests against Bank Account
        [Test]
        public void WithdrawTest()
        {
            account.Withdraw(withdrawSum1);
            Assert.AreEqual(expectedAmount, account.Amount);

            account.Withdraw(withdrawSum2);
            expectedAmount = expectedAmount - (int)(withdrawSum2 * 1.02);
            Assert.AreEqual(expectedAmount, account.Amount);
        }

        [Test]
        public void IsNotNullAssert()
        {
            Assert.IsNotNull(account);
        }

        [Test]
        public void GreaterOrEqual()
        {
            Assert.GreaterOrEqual(initialAmount, expectedAmount);
        }

        [Test]
        public void Equals()
        {
            BankAcount otherAccount = new BankAcount(initialAmount);
            Assert.AreNotSame(account, otherAccount);
        }

        [Test]
        public void Less()
        {
            Assert.Less(withdrawSum1, initialAmount);
        }

        [Test]
        public void AreNotEqual()
        {
            Assert.AreNotEqual(withdrawSum1, withdrawSum2);
        }

        [Test]
        public void LessOrEqual()
        {
            Assert.LessOrEqual(withdrawSum1, initialAmount);
        }
    }
}
