using MarsRover.Business.Abstract;
using MarsRover.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var plateau = InstanceFactory.GetInstance<IPlateau>();
                plateau.SetPlateauSize("5 5");

                var firstRover = InstanceFactory.GetInstance<IRover>();
                firstRover.Plateau = plateau;
                firstRover.SetRoverInitialPosition("1 2 N");
                firstRover.ProcessCommands("LMLMLMLMM");

                var secondRover = InstanceFactory.GetInstance<IRover>();
                secondRover.Plateau = plateau;
                secondRover.SetRoverInitialPosition("3 3 E");
                secondRover.ProcessCommands("MMRMMRMRRM");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
