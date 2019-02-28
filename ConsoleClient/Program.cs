using System;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Game game = new Game();
            Console.WriteLine();

            while (true) {
                var command = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(command)) {
                    Console.WriteLine();
                } else if (command == "clear") { 
                    Console.Clear();
                } else {
                    game.ExecuteCommand(command);
                }
            }
        }
            // ConsoleClient.CommandHandlers.Utilites.CommandUtility.ParseArguments("-name Hello World -id 5 -description This is a description").ToList().ForEach( x => Console.WriteLine(x.Key + ": " + x.Value));
//            Console.WriteLine(ConsoleClient.CommandHandlers.Utilites.CommandUtility.ParseArguments("-name Hello World"));
        
    }
}
