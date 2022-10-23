
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Unity;

namespace kalkulatory
{
    public class FileContainer: IContainer
    {
        public IUnityContainer GetContainer()
        {
            UnityContainer cont = new UnityContainer();

            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = @"kalkulatory.dll.config"

            };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection("unity");
            section.Configure(cont);


            //cont.RegisterInstance<ICalculator>("Worker2PlusCalc", new PlusCalc());
            //cont.RegisterInstance<ICalculator>("Worker2PlusCalc", new PlusCalc());
            //cont.RegisterInstance<ICalculator>("Worker2PlusCalc", new PlusCalc());


            return cont;
        }
    }
}
