using System;
using System.Linq;
using BasicUtils;
using Moq;
using Xunit;

namespace Tests
{
    public class BusinessRuleSetTests
    {
        private BusinessRule<IValidatedObject> rule1 = new BusinessRule<IValidatedObject>("Rule1", "Description1", (obj) => true);
        private BusinessRule<IValidatedObject> rule2 = new BusinessRule<IValidatedObject>("Rule2", "Description2", (obj) => true);
        private BusinessRule<IValidatedObject> rule3 = new BusinessRule<IValidatedObject>("Rule3", "Description3", (obj) => false);

        public BusinessRuleSetTests()
        {

        }

        [Fact]
        public void ContainsShouldReturnTrue()
        {
            var set = new BusinessRuleSet<IValidatedObject>(rule1, rule2);

            var contains = set.Contains(rule1);
            Assert.True(contains);
        }

        [Fact]
        public void ContainsShouldReturnFalse()
        {
            var set = new BusinessRuleSet<IValidatedObject>(rule1, rule2);

            var contains = set.Contains(rule3);
            Assert.False(contains);
        }

        [Fact]
        public void BrokenByShouldReturnEmptyList()
        {
            var mockValidatedObject = new Mock<IValidatedObject>();
            var set = new BusinessRuleSet<IValidatedObject>(rule1, rule2);

            var brokenBy = set.BrokenBy(mockValidatedObject.Object);
            Assert.Empty(brokenBy);
        }

        [Fact]
        public void BrokenByShouldReturnCorrectRule()
        {
            var mockValidatedObject = new Mock<IValidatedObject>();
            var set = new BusinessRuleSet<IValidatedObject>(rule1, rule2, rule3);

            var brokenBy = set.BrokenBy(mockValidatedObject.Object);
            var brokenRule = brokenBy.ToList().FirstOrDefault();
            Assert.True(brokenRule.Equals(rule3));
        }
    }
}

