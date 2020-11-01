using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Entities.Abstract
{
    public interface IPlateau
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        void InitPlateau(string plateauPosition);
    }
}
