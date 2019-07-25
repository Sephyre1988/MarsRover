using repo.sephyre.MarsRoverMovementControl.Models;

namespace repo.sephyre.MarsRoverMovementControl.Helpers
{
    public static class Validations

    {
        public static bool ValidateCommandInput(this string commandInput)
        {
            if (commandInput == string.Empty)
            {
                return false;
            }

            var result = false;

            foreach (var command in commandInput)
            {
                if (command.Equals((char)Command.Advance) ||
                    command.Equals((char)Command.TurnLeft) ||
                    command.Equals((char)Command.TurnRight))
                {
                    result = true;
                }
                else
                {
                    return false;
                }
            }

            return result;
        }

        public static double ValidateNumberInput(this string numberInput)
        {
            double.TryParse(numberInput, out double result);
            return result;
        }

        public static bool ValidateOrientationInput(this char orientationInput)
        {

            return orientationInput.Equals((char)Orientation.East) || orientationInput.Equals((char)Orientation.West) ||
                   orientationInput.Equals((char)Orientation.North) || orientationInput.Equals((char)Orientation.South) || orientationInput.Equals(null);
        }

        public static char ToUppercase(this char toUpper)
        {
            return toUpper.ToString().ToUpper().ToCharArray()[0];
        }
    }
}
