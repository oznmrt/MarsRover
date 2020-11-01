using System;
using MarsRover.Business.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverTestMove()
        {
            var plateau = new Plateau();
            plateau.SetPlateauSize("5 5");

            var rover = new Rover(plateau);
            rover.SetRoverInitialPosition("1 2 N");
            rover.ProcessCommands("LMLMLMLMM");

            var actualOutput = $"{rover.XPosition} {rover.YPosition} {rover.Direction.ToString()}";
            var expectedOutput = "1 3 N";
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
