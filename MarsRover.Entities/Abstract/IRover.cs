using MarsRover.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Abstract
{
    public interface IRover
    {
        int XPosition { get;set; }
        int YPosition { get;set; }
        RoverDirection Direction { get; set; }
        IList<ICommand> Commands { get; set; }
        bool InitRover(string roverPosition);
        void Move();
        void TurnRight();
        void TurnLeft();
    }
}
