using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests.cs
{
    [TestClass]
    public class RoverTests
    {
        private Rover rover;
        private Grid grid;

        [TestInitialize]
        public void Setup()
        {
            grid = new Grid(10, 10, new List<Coordinate>());
        }

        [TestMethod]
        public void RoverTakesInStartingPositionAndDirections()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.North, grid);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesForwardFacingNorth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.North, grid);
            var commands = new char[] { Command.Forward };

            rover.Move(commands);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesBackwardFacingNorth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.North, grid);
            var commands = new char[] { Command.Backward };

            rover.Move(commands);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesForwardFacingEast()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.East, grid);
            var commands = new char[] { Command.Forward };

            rover.Move(commands);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesBackwardFacingEast()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.East, grid);
            var commands = new char[] { Command.Backward };

            rover.Move(commands);

            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesForwardFacingSouth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.South, grid);
            var commands = new char[] { Command.Forward };

            rover.Move(commands);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(1, rover.Position.Y);
            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesBackwardFacingSouth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.South, grid);
            var commands = new char[] { Command.Backward };

            rover.Move(commands);

            Assert.AreEqual(1, rover.Position.X);
            Assert.AreEqual(3, rover.Position.Y);
            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesForwardFacingWest()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.West, grid);
            var commands = new char[] { Command.Forward };

            rover.Move(commands);

            Assert.AreEqual(0, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void RoverMovesBackwardFacingWest()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.West, grid);
            var commands = new char[] { Command.Backward };

            rover.Move(commands);

            Assert.AreEqual(2, rover.Position.X);
            Assert.AreEqual(2, rover.Position.Y);
            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsLeftFacingNorth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.North, grid);
            var commands = new char[] { Command.TurnLeft };

            rover.Move(commands);

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsLeftFacingWest()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.West, grid);
            var commands = new char[] { Command.TurnLeft };

            rover.Move(commands);

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsLeftFacingSouth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.South, grid);
            var commands = new char[] { Command.TurnLeft };

            rover.Move(commands);

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsLeftFacingEast()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.East, grid);
            var commands = new char[] { Command.TurnLeft };

            rover.Move(commands);

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsRightFacingNorth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.North, grid);
            var commands = new char[] { Command.TurnRight };

            rover.Move(commands);

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsRightFacingWest()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.West, grid);
            var commands = new char[] { Command.TurnRight };

            rover.Move(commands);

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsRightFacingSouth()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.South, grid);
            var commands = new char[] { Command.TurnRight };

            rover.Move(commands);

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void RoverTurnsRightFacingEast()
        {
            rover = new Rover(new Coordinate(1, 2), Direction.East, grid);
            var commands = new char[] { Command.TurnRight };

            rover.Move(commands);

            Assert.AreEqual(Direction.South, rover.Direction);
        }
    }
}
