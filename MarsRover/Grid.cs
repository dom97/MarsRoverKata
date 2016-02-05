using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        public Int32 Rows { get; private set; }
        public Int32 Columns { get; private set; }
        private IEnumerable<Coordinate> obstacles;

        public Grid(Int32 rows, Int32 columns, IEnumerable<Coordinate> obstacles)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.obstacles = obstacles;
        }

        public Coordinate GetNextSpaceInFront(Coordinate coordinate, Direction direction)
        {
            var nextSpaceCandidate = GetSpaceInFrontCandidate(coordinate, direction);

            if (obstacles.Contains(nextSpaceCandidate))
                return coordinate;

            return nextSpaceCandidate;
        }

        public Coordinate GetNextSpaceBehind(Coordinate coordinate, Direction direction)
        {
            var nextSpaceCandidate = GetSpaceBehindCandidate(coordinate, direction);

            if (obstacles.Contains(nextSpaceCandidate))
                return coordinate;

            return nextSpaceCandidate;
        }

        private Coordinate GetSpaceInFrontCandidate(Coordinate coordinate, Direction direction)
        {
            if (direction == Direction.North)
                return new Coordinate(coordinate.X, (coordinate.Y + 1) % 10);
            else if (direction == Direction.East)
                return new Coordinate((coordinate.X + 1) % 10, coordinate.Y);
            else if (direction == Direction.South)
            {
                if (coordinate.Y == 0)
                    return new Coordinate(coordinate.X, Rows - 1);

                return new Coordinate(coordinate.X, (coordinate.Y - 1) % 10);
            }
            else if (coordinate.X == 0)
                return new Coordinate(Columns - 1, coordinate.Y);
            else
                return new Coordinate((coordinate.X - 1) % 10, coordinate.Y);
        }

        private Coordinate GetSpaceBehindCandidate(Coordinate coordinate, Direction direction)
        {
            if (direction == Direction.North)
            {
                if (coordinate.Y == 0)
                    return new Coordinate(coordinate.X, Rows - 1);

                return new Coordinate(coordinate.X, coordinate.Y - 1);
            }
            else if (direction == Direction.East)
            {
                if (coordinate.X == 0)
                    return new Coordinate(Columns - 1, coordinate.Y);

                return new Coordinate(coordinate.X - 1, coordinate.Y);
            }
            else if (direction == Direction.South)
            {
                if (coordinate.Y == Rows - 1)
                    return new Coordinate(coordinate.X, 0);

                return new Coordinate(coordinate.X, coordinate.Y + 1);
            }
            else if (coordinate.X == Columns - 1)
                return new Coordinate(0, coordinate.Y);
            else
                return new Coordinate(coordinate.X + 1, coordinate.Y);
        }
    }
}
