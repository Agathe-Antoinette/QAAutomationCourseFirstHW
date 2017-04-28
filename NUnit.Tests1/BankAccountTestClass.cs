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
            int initialAmount = 3000;
            int withdrawSum1 = 700;
            int withdrawSum2 = 1200;

            int expectedAmount = initialAmount - (int)(withdrawSum1 * 1.05);
            BankAcount account = new BankAcount(initialAmount);
            account.Withdraw(withdrawSum1);
            Assert.AreEqual(expectedAmount, account.Amount);

            account.Withdraw(withdrawSum2);
            expectedAmount = expectedAmount - (int)(withdrawSum2 * 1.02);
            Assert.AreEqual(expectedAmount, account.Amount);

            Assert.IsNotNull(expectedAmount);
            Assert.GreaterOrEqual(initialAmount, expectedAmount);
            Assert.True(withdrawSum1 < initialAmount);
            Assert.AreNotEqual(withdrawSum1, withdrawSum2);
            Assert.LessOrEqual(withdrawSum1, initialAmount);

        }

        [Test]
        public void BankAccountAssertingTest()
        {
            /*
              Write five more tests against BankAccount that test its functionality.Use five different
                type of asserts for these tests.
            */
            // TODO Create Implementation
            throw new NotImplementedException();
        }



    
    }
}
