using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Business.Abstract
{
    public interface IPlateau
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        ILogger Logger { get; set; }
        void SetPlateauSize(string plateauPosition);
    }
}
