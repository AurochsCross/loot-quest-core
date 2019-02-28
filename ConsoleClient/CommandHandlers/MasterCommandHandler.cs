using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleClient.CommandHandlers {
    public class MasterCommandHandler: ICommandHandler {
        Dictionary<String, ICommandHandler> handlers = new Dictionary<string, ICommandHandler>();

        public MasterCommandHandler() {
            handlers.Add("inventory", new InventoryCommandHandler());
        }

        public void ExecuteCommand(string command) {
            string[] commands = command.Split('.');

            if (commands.Length > 1 && handlers.ContainsKey(commands[0])) {
                var subCommand = command.Remove(0, (commands[0].Length + 1));
                handlers[commands[0]].ExecuteCommand(subCommand);
            } else {
                System.Console.WriteLine("Command not recognized.");
            }
        }
    }
}