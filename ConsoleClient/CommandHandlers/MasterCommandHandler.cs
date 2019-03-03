using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleClient.CommandHandlers {
    public class MasterCommandHandler: BaseCommandHandler {
        Dictionary<String, BaseCommandHandler> handlers = new Dictionary<string, BaseCommandHandler>();

        public MasterCommandHandler() {
            handlers.Add("inventory", new InventoryCommandHandler());
            handlers.Add("player", new PlayerCommandHandler());
            handlers.Add("battle", new BattleCommandHandler());
        }

        public new void ExecuteCommand(string command) {

            if (command == "help") {
                PrintHelp();
                return;
            }

            string[] commands = command.Split('.');

            if (commands.Length > 1 && handlers.ContainsKey(commands[0])) {
                var subCommand = command.Remove(0, (commands[0].Length + 1));
                handlers[commands[0]].ExecuteCommand(subCommand);
            } else {
                System.Console.WriteLine("Command not recognized.");
            }
        }

        public override void PrintHelp() {
            string help = @"Loot Quest help:

Available objects:
* player
* inventory

";
            Console.WriteLine(help);
            handlers.ToList().ForEach(x => {
                x.Value.PrintHelp(); 
                Console.WriteLine("\n");
            } );
        }
    }
}