using System;
using repo.sephyre.MarsRoverMovementControl.Helpers;
using repo.sephyre.MarsRoverMovementControl.Models;
using repo.sephyre.MarsRoverMovementControl.Tasks;
using Console = System.Console;

namespace MarsRoverMovementControl
{
    class Program
    {
        static void Main(string[] args)
        {
            //to limit any possibility to run injection in EXE
            if (args.Length != 0)
            {
                throw new ArgumentException("Invalid Arguments set, there is to many arguments... \n\nThis program does not require Arguments to run!");
            }

            Rover carRover = UserInputs.StartUp();
            do
            {
                Console.Write("Command Input: ");
                var command = Console.ReadLine()?.ToUpper();

                if (command.ValidateCommandInput())
                {
                    var finalStatus = carRover.ExecuteCommand(command);
                    Console.WriteLine($"{finalStatus.IsCommandValid}, {(char)finalStatus.FinalOrientation}, ({finalStatus.FinalPosition.XPosition},{finalStatus.FinalPosition.YPosition})");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Command not valid, try again....\n");
                }


            } while (true);

            


        }
    }
}
