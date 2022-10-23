

using System;
using System.Collections.Generic;
using Unity;
using Xunit;

namespace kalkulatory
{
    public class Tests
    {
        public static IEnumerable<object[]> Configs => new List<object[]>()
        {
            new object[] {new FileContainer().GetContainer()},
            new object[] {new CodeContainer().GetContainer()}
        };

        [Theory]
        [MemberData(nameof(Configs))]
        public void WorkerShouldUseCatCalc(UnityContainer container)
        {
            var worker = container.Resolve<Worker>();
            const string expectedResult = "ab";

            var result = worker.Work("a", "b");
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(Configs))]
        public void Worker2ShouldUsePlusCalc(UnityContainer container)
        {
            var worker = container.Resolve<Worker2>();
            const string expectedResult = "17";

            var result = worker.Work("13", "4");

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(Configs))]
        public void Worker3ShouldUseCatCalc(UnityContainer container)
        {
            var worker = container.Resolve<Worker3>();
            const string expectedResult = "ab";

            var result = worker.Work("a", "b");

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(Configs))]
        public void WorkersShouldUseStateCalculatorsCalledWhenCalledWithState(UnityContainer container)
        {
            var worker = container.Resolve<Worker>("state");
            var worker2 = container.Resolve<Worker2>("state");
            var worker3 = container.Resolve<Worker3>("state");

            const string expectedResult = "ab. Counter: 1";
            const string expectedResult2 = "ab. Counter: 2";
            const string expectedResult3 = "ab. Counter: 3";

            var result = worker.Work("a", "b");
            var result2 = worker2.Work("a", "b");
            var result3 = worker3.Work("a", "b");

            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedResult2, result2);
            Assert.Equal(expectedResult3, result3);
        }

        [Theory]
        [MemberData(nameof(Configs))]
        public void ObjectsReturnedByContainerShouldBeTheSameInstance(UnityContainer container)
        {
            var instance1 = container.Resolve<ICalculator>("state");
            var instance2 = container.Resolve<ICalculator>("state");

            Assert.True(ReferenceEquals(instance1, instance2));
        }
    }
}
