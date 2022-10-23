
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace kalkulatory
{
    public class CodeContainer: IContainer
    {
        public IUnityContainer GetContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<ICalculator, PlusCalc>(
                "plus",
                new ContainerControlledLifetimeManager());

            container.RegisterType<ICalculator, CatCalc>(
                "cat",
                new ContainerControlledLifetimeManager());

            container.RegisterType<ICalculator, StateCalc>(
                "state",
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(1));



            container.RegisterType<Worker>(
                new InjectionConstructor(
                    new ResolvedParameter<ICalculator>("cat")));

            container.RegisterType<Worker2>(
                new InjectionMethod(
                    "Initialize",
                    new ResolvedParameter<ICalculator>("plus")));

            container.RegisterType<Worker3>(
                new InjectionProperty(
                    "Calculator",
                    new ResolvedParameter<ICalculator>("cat")));


            container.RegisterType<Worker>(
                "state",
                new InjectionConstructor(
                    new ResolvedParameter<ICalculator>("state")));

            container.RegisterType<Worker2>(
                "state",
                new InjectionMethod(
                    "Initialize",
                    new ResolvedParameter<ICalculator>("state")));

            container.RegisterType<Worker3>(
                "state",
                new InjectionProperty(
                    "Calculator",
                    new ResolvedParameter<ICalculator>("state")));

            return container;
        }
    }
}
