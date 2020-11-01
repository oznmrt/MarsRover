using MarsRover.Business.Concrete;
using MarsRover.Business.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRover>().To<Rover>();
            Bind<IPlateau>().To<Plateau>();
            Bind<ILogger>().To<ConsoleLogger>().InSingletonScope();
        }
    }
}
