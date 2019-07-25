using System;
using repo.sephyre.MarsRoverMovementControl.Helpers;
using repo.sephyre.MarsRoverMovementControl.Models;

namespace repo.sephyre.MarsRoverMovementControl.Tasks
{
    public class UserInputs
    {
        public static Rover StartUp()
        {
            Console.WriteLine("Mars Control Operation: Rover Movement control");
            Console.WriteLine("\n\nPlease Enter the grid dimensions to explore:");
            Console.Write("Width: ");
            double width;
            do
            {
                width = Console.ReadLine().ValidateNumberInput();
                if (Math.Abs(width) <= 0 || width < 0)
                {
                    Console.WriteLine("Input not valid, please try again...");
                }

            } while (Math.Abs(width) <= 0 || width < 0);

            Console.Write("High: ");
            double heigh;
            do
            {
                heigh = Console.ReadLine().ValidateNumberInput();
                if (Math.Abs(heigh) <= 0 || heigh < 0)
                {
                    Console.WriteLine("Input not valid, please try again...");
                }

            } while (Math.Abs(heigh) <= 0 || heigh < 0);
            Console.WriteLine("\n\nPlease Enter the Rover initial position:");
            Console.Write("X Position: ");
            double xPosition;
            do
            {
                xPosition = Console.ReadLine().ValidateNumberInput();
                if (xPosition < 0)
                {
                    Console.WriteLine("Input not valid, please try again...");
                }

                if (xPosition > width)
                {
                    Console.WriteLine("Input not valid, exceeds Grid params...");
                    xPosition = -1;
                }

            } while (xPosition < 0);

            Console.Write("Y Position: ");
            double yPosition;
            do
            {
                yPosition = Console.ReadLine().ValidateNumberInput();
                if (yPosition < 0)
                {
                    Console.WriteLine("Input not valid, please try again...");
                }

                if (yPosition > heigh)
                {
                    Console.WriteLine("Input not valid, exceeds Grid params...");
                    yPosition = -1;
                }

            } while (yPosition < 0);

            Console.Write("Car Orientation: ");
            Orientation carOrientation = (Orientation)0;
            char input;
            do
            {
                input = Console.ReadKey().KeyChar.ToUppercase();
                if (input.ValidateOrientationInput())
                {
                    carOrientation = (Orientation) input;
                }
                else
                {
                    Console.WriteLine("\nInput not valid, try: (N)orth, (S)outh, (E)ast, (W)est...");
                }

            } while (!input.ValidateOrientationInput());

            Console.WriteLine("\n\nPlease Input Movement sequence");


            return new Rover()
            {
                RoverPosition = new Position()
                {
                    YPosition = yPosition,
                    XPosition = xPosition
                },
                Orientation = carOrientation,
                RoverGrid = new Grid()
                {
                    Height = heigh,
                    Width = width
                }
            };


        }
    }
}

