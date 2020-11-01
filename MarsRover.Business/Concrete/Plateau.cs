using MarsRover.Business.Abstract;
using MarsRover.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class Plateau : IPlateau
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public ILogger Logger { get; set; }
        public Plateau()
        {
            this.Logger = InstanceFactory.GetInstance<ILogger>();
        }
        public Plateau(ILogger _logger)
        {
            this.Logger = _logger;
        }
        public void SetPlateauSize(string plateauPosition)
        {
            if (!string.IsNullOrWhiteSpace(plateauPosition))
            {
                var splittedPosition = plateauPosition.Split(' ');
                if (splittedPosition.Length == 2)
                {
                    this.XPosition = Convert.ToInt32(splittedPosition[0]);
                    this.YPosition = Convert.ToInt32(splittedPosition[1]);
                    this.Logger.Log($"Plateau Size : {this.XPosition} {this.YPosition}");
                }
            }
        }
    }
}
