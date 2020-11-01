using MarsRover.Business.Abstract;
using MarsRover.Business.DependencyResolvers.Ninject;
using MarsRover.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Concrete
{
    public class Rover : IRover
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public Direction Direction { get; set; }
        public IPlateau Plateau { get; set; }
        public ILogger Logger { get; set; }

        public Rover(IPlateau _plateau)
        {
            this.Plateau = _plateau;
            this.Logger = InstanceFactory.GetInstance<ILogger>();
        }
        public Rover(IPlateau _plateau, ILogger _logger)
        {
            this.Plateau = _plateau;
            this.Logger = _logger;
        }

        public void SetRoverInitialPosition(string roverPosition)
        {
            var splittedPosition = roverPosition.Split(' ');
            if (splittedPosition.Length == 3)
            {
                int xP = Convert.ToInt32(splittedPosition[0]);
                int yP = Convert.ToInt32(splittedPosition[1]);
                string Direction = splittedPosition[2].ToUpper();
                if (Direction == "N" || Direction == "S" || Direction == "E" || Direction == "W")
                {
                    this.Direction = (Direction)Enum.Parse(typeof(Direction), Direction);
                    this.XPosition = xP;
                    this.YPosition = yP;
                    this.Logger.Log($"Rover Initial Position : {this.XPosition} {this.YPosition} {this.Direction.ToString()}");
                }
            }
        }

        public void ProcessCommands(string commands)
        {
            try
            {
                foreach (var item in commands.ToCharArray())
                {
                    switch (char.ToUpper(item))
                    {
                        case 'L':
                            this.TurnLeft();
                            break;
                        case 'R':
                            this.TurnRight();
                            break;
                        case 'M':
                            this.Move();
                            break;
                        default:
                            throw new Exception($"Invalid command {item}");
                    }
                }
                this.Logger.Log($"Rover Final Position : {this.XPosition} {this.YPosition} {this.Direction.ToString()}");
            }
            catch (Exception ex)
            {
                this.Logger.Log(ex.Message);
            }
        }

        public void Move()
        {
            this.CheckRoverPosition();
            switch (this.Direction)
            {
                case Direction.N:
                    this.YPosition += 1;
                    break;
                case Direction.S:
                    this.YPosition -= 1;
                    break;
                case Direction.W:
                    this.XPosition -= 1;
                    break;
                case Direction.E:
                    this.XPosition += 1;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        public void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                default:
                    break;
            }
        }

        private void CheckRoverPosition()
        {
            var pX = this.Plateau.XPosition;
            var pY = this.Plateau.YPosition;

            if (this.XPosition > pX || this.XPosition < 0 || this.YPosition > pY || this.YPosition < 0)
            {
                throw new Exception($"Position must be between (0 , 0) and ({pX} , {pY})");
            }
        }
    }
}
