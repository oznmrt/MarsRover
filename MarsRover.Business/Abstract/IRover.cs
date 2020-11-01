using MarsRover.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IRover
    {
        int XPosition { get;set; }
        int YPosition { get;set; }
        Direction Direction { get; set; }
        IPlateau Plateau { get; set; }
        ILogger Logger { get; set; }
        void SetRoverInitialPosition(string roverPosition);
        void ProcessCommands(string commands);
        void Move();
        void TurnRight();
        void TurnLeft();
    }
}
