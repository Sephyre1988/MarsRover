using repo.sephyre.MarsRoverMovementControl.Helpers;
using repo.sephyre.MarsRoverMovementControl.Models;

namespace repo.sephyre.MarsRoverMovementControl.Tasks
{
    public static class Move
    {
        private static void TurnLeft(this Rover rover)
        {
            switch (rover.Orientation)
            {
                case Orientation.East:
                    {
                        rover.Orientation = Orientation.North;
                        break;
                    }
                case Orientation.North:
                    {
                        rover.Orientation = Orientation.West;
                        break;
                    }
                case Orientation.West:
                    {
                        rover.Orientation = Orientation.South;
                        break;
                    }
                case Orientation.South:
                    {
                        rover.Orientation = Orientation.East;
                        break;
                    }
            }
        }

        private static void TurnRight(this Rover rover)
        {
            switch (rover.Orientation)
            {
                case Orientation.East:
                    {
                        rover.Orientation = Orientation.South;
                        break;
                    }
                case Orientation.South:
                    {
                        rover.Orientation = Orientation.West;
                        break;
                    }
                case Orientation.West:
                    {
                        rover.Orientation = Orientation.North;
                        break;
                    }
                case Orientation.North:
                    {
                        rover.Orientation = Orientation.East;
                        break;
                    }
            }
        }

        private static bool Advance(this Rover rover)
        {
            switch (rover.Orientation)
            {
                case Orientation.East:
                    {
                        if (rover.RoverGrid.Width - rover.RoverPosition.XPosition == 0)
                        {
                            return false;
                        }
                        rover.RoverPosition.XPosition += 1;
                        break;
                    }

                case Orientation.West:
                    {
                        if (rover.RoverPosition.XPosition == 0)
                        {
                            return false;
                        }
                        rover.RoverPosition.XPosition -= 1;
                        break;
                    }

                case Orientation.North:
                    {
                        if (rover.RoverGrid.Height - rover.RoverPosition.YPosition == 0)
                        {
                            return false;
                        }
                        rover.RoverPosition.YPosition += 1;
                        break;
                    }

                case Orientation.South:
                    {
                        if (rover.RoverPosition.YPosition == 0)
                        {
                            return false;
                        }
                        rover.RoverPosition.YPosition -= 1;
                        break;
                    }

            }

            return true;
        }

        public static Status ExecuteCommand(this Rover rover, string command)
        {
            var isCommandValid = command.ValidateCommandInput();
            if (isCommandValid)
            {
                foreach (var commandChar in command)
                {
                    switch (commandChar)
                    {
                        case (char)Command.Advance:
                            {
                                isCommandValid = rover.Advance();
                                break;
                            }
                        case (char)Command.TurnLeft:
                            {
                                rover.TurnLeft();
                                break;
                            }
                        case (char)Command.TurnRight:
                            {
                                rover.TurnRight();
                                break;
                            }
                    }

                }

            }
            return new Status()
            {
                IsCommandValid = isCommandValid,
                FinalOrientation = rover.Orientation,
                FinalPosition = rover.RoverPosition
            };

        }
    }

    public class Status
    {
        public bool IsCommandValid { get; set; }
        public Orientation FinalOrientation { get; set; }
        public Position FinalPosition { get; set; }
    }
}
