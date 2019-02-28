using System;
using System.Linq;
using System.Collections.Generic;
using Models.Items;

namespace ConsoleClient.CommandHandlers {
    public class PlayerCommandHandler : ICommandHandler
    {
        public void ExecuteCommand(string command) {
            var commands = command.Split('.');

            if (commands.Length == 1) {
                int index = command.IndexOf(' ');
                if (index != -1) {
                    ExecuteCommand(command.Remove(index), command.Remove(0, index + 1));
                } else {
                    ExecuteCommand(command, "");
                }
            }

            Console.WriteLine();
        }

        private void ExecuteCommand(string command, string arguments) {
            var args = Utilites.CommandUtility.ParseArguments(arguments);

            switch (command) {
                case "help": PrintHelp();
                break;
                case "stats": PrintStats();
                break;
                default: Console.WriteLine("Inventory command not recognized.");
                break;
            }
        }

        private void PrintStats() {

        }

        private void PrintHelp() {
            string helpString = 
@"Player commands:

Print help:                           help     
Show player stats:                    stats";

            Console.WriteLine(helpString);
        }
    }
}