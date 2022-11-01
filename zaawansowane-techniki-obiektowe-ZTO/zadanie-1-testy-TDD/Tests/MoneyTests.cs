using System;
using TDDLab.Core.InvoiceMgmt;
using Xunit;

namespace Tests
{
    public class MoneyTests
    {
        public MoneyTests()
        {
        }

        [Fact]
        public void MinusOperatorShouldWork()
        {
            var money1 = new Money(5);
            var money2 = new Money(1);

            var resultMoney = money1 - money2;

            Assert.Equal((ulong)4, resultMoney.Amount);
        }

        [Fact]
        public void PlusOperatorShouldWork()
        {
            var money1 = new Money(5);
            var money2 = new Money(1);

            var resultMoney = money1 + money2;

            Assert.Equal((ulong)6, resultMoney.Amount);
        }

        [Fact]
        public void EqualsOperatorShouldWork()
        {
            var money1 = new Money(3);
            var money2 = new Money(3);

            Assert.True(money1 == money2);
        }

        [Fact]
        public void NotEqualsOperatorShouldWork()
        {
            var money1 = new Money(4);
            var money2 = new Money(3);

            Assert.True(money1 != money2);
        }
    }
}

