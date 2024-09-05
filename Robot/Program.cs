//What's missing: LINQ, EF, Automated Tests, etc.
//Let me know if you want me to add samples for these. Thank you

using Robot.CommandHandlers;
using Robot.Exceptions;
using Robot.Interfaces;
using Robot.Models;

namespace Robot
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICommandHandler commandHandler = new CommandHandler(new ToyRobot());

            Console.WriteLine("Enter command: ");

            while (true)
            {
                try
                {
                    string? command = Console.ReadLine()?.ToUpper().Trim();

                    if (command != null)
                    {
                        commandHandler.Handle(command);
                    }
                }
                catch (CommandInvalidException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (PlacementInvalidException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    Console.WriteLine("An error has occured. Please retry.");
                }
            }
        }
        
    }
}