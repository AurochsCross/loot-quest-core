using System;
using System.Linq;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            while (true) {
                var command = Console.ReadLine();
                game.ExecuteCommand(command);
            }
        }
    }
}
