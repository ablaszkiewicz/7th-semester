using System;
using Xunit;
using Moq;
using BasicUtils;

namespace Tests
{
    public class BusinessRuleTests
    {
        public BusinessRuleTests()
        {
            
        }

        [Fact]
        public void ShouldBeSatisfiedBy()
        {
            var mockValidatedItem = new Mock<IValidatedObject>();
            var rule = new BusinessRule<IValidatedObject>("", "", (obj) => true);
            var result = rule.IsSatisfiedBy(mockValidatedItem.Object);

            Assert.True(result);
        }

        [Fact]
        public void ShouldNotBeSatisfiedBy()
        {
            var mockValidatedItem = new Mock<IValidatedObject>();
            var rule = new BusinessRule<IValidatedObject>("", "", (obj) => false);
            var result = rule.IsSatisfiedBy(mockValidatedItem.Object);

            Assert.False(result);
        }

        [Fact]
        public void ShouldEqualToOtherRule()
        {
            var rule = new BusinessRule<IValidatedObject>("Name1", "", (obj) => true);
            var rule2 = new BusinessRule<IValidatedObject>("Name1", "", (obj) => true);

            var result = rule.Equals(rule2);
            Assert.True(result);
        }

        [Fact]
        public void ShouldNotEqualToOtherRule()
        {
            var rule = new BusinessRule<IValidatedObject>("Name1", "", (obj) => true);
            var rule2 = new BusinessRule<IValidatedObject>("Name2", "", (obj) => true);

            var result = rule.Equals(rule2);
            Assert.False(result);
        }

        [Fact]
        public void FieldsShouldBeSet()
        {
            var rule = new BusinessRule<IValidatedObject>("Name", "Description", (obj) => true);

            var name = rule.Name;
            var description = rule.Description;

            Assert.Equal("Name", rule.Name);
            Assert.Equal("Description", rule.Description);
        }
    }
}

