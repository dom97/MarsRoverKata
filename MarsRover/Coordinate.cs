using System;

namespace MarsRover
{
    public class Coordinate
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Coordinate(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            if (obj is Coordinate == false)
                return false;

            var otherCoordinate = obj as Coordinate;

            if (this.GetHashCode() != otherCoordinate.GetHashCode())
                return false;

            if (this.X != otherCoordinate.X || this.Y != otherCoordinate.Y)
                return false;

            return true;
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}", X, Y);
        }
    }
}
