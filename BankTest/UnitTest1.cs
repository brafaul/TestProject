using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        //unit test method  
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert is handled by ExpectedException  
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown");  
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AccountFrozen_ShouldThrowArguementOutofRange()
        {
            BankAccount account = new BankAccount("Mr.John Smith", 100);
            account.FreezeAccount();
            account.Credit(100.00);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AmountIsNegative()
        {
            BankAccount account = new BankAccount("Mr.John Smith", 100.00);
            double creditAmount = -100.00;
            account.Credit(creditAmount);
        }
        [TestMethod]
        public void CreditBalanceUpdated()
        {
            double balance = 10.00;
            double creditAmount = 5.50;
            double amountExpected = 15.50;
            BankAccount account = new BankAccount("Mr.John Smith", balance);
            account.Credit(creditAmount);
            double actual = account.Balance;
            Assert.AreEqual(amountExpected, actual, 0.001, "Account not credited correctly");
        }
    }
}
