using Xunit;
using BasicUtils;
using System.Reflection;
using TDDLab.Core.InvoiceMgmt;
using System.Linq;
using System;
using Xunit.Abstractions;

namespace Tests
{
    public class MockValidatedObject: ValidatedDomainObject
    {
        public MockValidatedObject(string property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public string Property1 { get; private set; }
        public string Property2 { get; private set; }

        public sealed class ValidationRules
        {
            public static IBusinessRule<MockValidatedObject> Property1
            {
                get
                {
                    return new BusinessRule<MockValidatedObject>(MethodBase.GetCurrentMethod().Name, "Property 1 should be set", mock => mock.Property1.IsNotEmpty());
                }
            }
            public static IBusinessRule<MockValidatedObject> Property2
            {
                get
                {
                    return new BusinessRule<MockValidatedObject>(MethodBase.GetCurrentMethod().Name, "Property 2 should be set", mock => mock.Property2.IsNotEmpty());
                }
            }
        }

        protected override IBusinessRuleSet Rules
        {
            get
            {
                return new BusinessRuleSet<MockValidatedObject>(
                    ValidationRules.Property1,
                    ValidationRules.Property2);
            }
        }
    }


    public class ValidationTests
    {
        private readonly ITestOutputHelper output;
            
        public ValidationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldReturnNotIsValid()
        {
            var mock = new MockValidatedObject("", "");
            var isValid = mock.IsValid;

            Assert.False(isValid);
        }

        [Fact]
        public void ShouldReturnBrokenRulesNotIsEmpty()
        {
            var mock = new MockValidatedObject("", "");
            var brokenBy = mock.Validate();
            var rule = brokenBy.ToList().FirstOrDefault();

            Assert.False(brokenBy.IsEmpty());
        }

        [Fact]
        public void ShouldReturnBrokenRule1()
        {
            var mock = new MockValidatedObject("", "Set");
            var brokenBy = mock.Validate();
            var rule = brokenBy.ToList().FirstOrDefault();

            Assert.Equal("get_Property1", rule.Name);
        }

        [Fact]
        public void ShouldReturnBrokenRule2()
        {
            var mock = new MockValidatedObject("Set", "");
            var brokenBy = mock.Validate();
            var rule = brokenBy.ToList().FirstOrDefault();

            Assert.Equal("get_Property2", rule.Name);
        }

        [Fact]
        public void ShouldReturnBrokenRules()
        {
            var mock = new MockValidatedObject("", "");
            var brokenBy = mock.Validate();
            var rule = brokenBy.ToList().FirstOrDefault();

            Assert.Equal("get_Property1", rule.Name);
        }

        [Fact]
        public void ShouldReturnIsValid()
        {
            var mock = new MockValidatedObject("Set", "Set");
            var isValid = mock.IsValid;

            Assert.True(isValid);
        }

        [Fact]
        public void ShouldReturnBrokenRulesIsEmpty()
        {
            var mock = new MockValidatedObject("Set", "Set");
            var brokenBy = mock.Validate();


            Assert.True(brokenBy.IsEmpty());
        }
    }
}
