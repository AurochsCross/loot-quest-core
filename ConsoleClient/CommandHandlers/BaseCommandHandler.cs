using System;
using System.Linq;
using System.Collections.Generic;
using Models.Items;

namespace ConsoleClient.CommandHandlers {
    public class BaseCommandHandler {
        public void ExecuteCommand(string command) {
            var commands = command.Split('.');

            if (commands.Length == 1) {
                int index = command.IndexOf(' ');
                if (index != -1) {
                    ExecuteCommand(command.Remove(index), Utilites.CommandUtility.ParseArguments(command.Remove(0, index + 1)));
                } else {
                    ExecuteCommand(command, null);
                }
            }

            Console.WriteLine();
        }

        protected virtual void ExecuteCommand(string command, Dictionary<string, string> arguments) {

        }


        private void PrintErrorBadArguments() {
            Console.WriteLine("Error: Bad arguments.");
        }

        public virtual void PrintHelp() {
            string helpString = "No help found.";

            Console.WriteLine(helpString);
        }
    }
}