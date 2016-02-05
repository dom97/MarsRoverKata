
namespace MarsRover
{
    public class Rover
    {
        public Coordinate Position { get; private set; }
        public Direction Direction { get; private set; }
        public Grid Grid { get; private set; }

        public Rover(Coordinate position, Direction direction, Grid grid)
        {
            this.Position = position;
            this.Direction = direction;
            this.Grid = grid;
        }

        public void Move(char[] commands)
        {
            foreach (var command in commands)
            {
                if (command == Command.Forward)
                    MoveForward();
                if (command == Command.Backward)
                    MoveBackward();
                if (command == Command.TurnLeft)
                    TurnLeft();
                if (command == Command.TurnRight)
                    TurnRight();
            }
        }

        private void MoveForward()
        {
            Position = Grid.GetNextSpaceInFront(Position, Direction);
        }

        private void MoveBackward()
        {
            Position = Grid.GetNextSpaceBehind(Position, Direction);
        }

        private void TurnLeft()
        {
            if (Direction == Direction.North)
                Direction = Direction.West;
            else if (Direction == Direction.West)
                Direction = Direction.South;
            else if (Direction == Direction.South)
                Direction = Direction.East;
            else if (Direction == Direction.East)
                Direction = Direction.North;
        }

        private void TurnRight()
        {
            if (Direction == Direction.North)
                Direction = Direction.East;
            else if (Direction == Direction.West)
                Direction = Direction.North;
            else if (Direction == Direction.South)
                Direction = Direction.West;
            else if (Direction == Direction.East)
                Direction = Direction.South;
        }

    }
}
