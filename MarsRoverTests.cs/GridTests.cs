using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests.cs
{
    [TestClass]
    public class GridTests
    {
        private Grid grid;
        private List<Coordinate> obstacles;

        [TestInitialize]
        public void Setup()
        {
            obstacles = new List<Coordinate>();
            obstacles.Add(new Coordinate(5, 5));
            grid = new Grid(10, 10, obstacles);
        }

        [TestMethod]
        public void GridIsCreated()
        {
            Assert.AreEqual(10, grid.Columns);
            Assert.AreEqual(10, grid.Rows);
        }

        [TestMethod]
        public void WrapsSouthMovingBackwards()
        {
            var nextSpace = grid.GetNextSpaceBehind(new Coordinate(0, 0), Direction.North);

            Assert.AreEqual(new Coordinate(0, 9), nextSpace);
        }

        [TestMethod]
        public void WrapsSouthMovingForwards()
        {
            var nextSpace = grid.GetNextSpaceInFront(new Coordinate(0, 0), Direction.South);

            Assert.AreEqual(new Coordinate(0, 9), nextSpace);
        }

        [TestMethod]
        public void WrapsNorthMovingForwards()
        {
            var nextSpace = grid.GetNextSpaceInFront(new Coordinate(0, 9), Direction.North);

            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapsNorthMovingBackwards()
        {
            var nextSpace = grid.GetNextSpaceBehind(new Coordinate(0, 9), Direction.South);

            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapsEastMovingForwards()
        {
            var nextSpace = grid.GetNextSpaceInFront(new Coordinate(9, 0), Direction.East);

            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapsEastMovingBackwards()
        {
            var nextSpace = grid.GetNextSpaceBehind(new Coordinate(9, 0), Direction.West);

            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapsWestMovingForwards()
        {
            var nextSpace = grid.GetNextSpaceInFront(new Coordinate(0, 0), Direction.West);

            Assert.AreEqual(new Coordinate(9, 0), nextSpace);
        }

        [TestMethod]
        public void WrapsWestMovingBackwards()
        {
            var nextSpace = grid.GetNextSpaceBehind(new Coordinate(0, 0), Direction.East);

            Assert.AreEqual(new Coordinate(9, 0), nextSpace);
        }

        [TestMethod]
        public void CannotMoveForwardWhenObstructed()
        {
            var currentLocation = new Coordinate(5, 4);
            var nextSpace = grid.GetNextSpaceInFront(currentLocation, Direction.North);

            Assert.AreEqual(currentLocation, nextSpace);
        }

        [TestMethod]
        public void CannotMoveBackwardWhenObstructed()
        {
            var currentLocation = new Coordinate(5, 6);
            var nextSpace = grid.GetNextSpaceBehind(currentLocation, Direction.North);

            Assert.AreEqual(currentLocation, nextSpace);
        }
    }
}
