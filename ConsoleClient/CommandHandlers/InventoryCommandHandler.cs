using System;
using System.Linq;
using System.Collections.Generic;
using Models.Items;

namespace ConsoleClient.CommandHandlers {
    public class InventoryCommandHandler: ICommandHandler {

        private Logic.Player.Commanders.EquipmentCommander _equipment;

        public InventoryCommandHandler() {
            _equipment = Game.Shared.PlayerMaster.equipmentCommander;
        }
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
                case "show": PrintInventory();
                break;
                case "equip": EquipItem(args);
                break;
                default: Console.WriteLine("Inventory command not recognized.");
                break;
            }
        }

        private void PrintInventory() {
            Console.WriteLine("Equiped: ");
            _equipment.armor.Where(x => x.Value != null).ToList().ForEach( x => Console.WriteLine(String.Format("{0}: {1}", x.Key, x.Value.itemName)) );

            Console.WriteLine("\nInventory: ");
            _equipment.inventory.ForEach( x => Console.WriteLine(String.Format("{0}", x.itemName)));
        }

        private void EquipItem(Dictionary<string, string> args) {
            string name;
            if (args.TryGetValue("name", out name) || args.TryGetValue("arg", out name)) {
                ArmorItem item = (ArmorItem)_equipment.inventory.Where(x => x.itemName == name)?.FirstOrDefault();
                if (item != null) {
                    _equipment.Equip(item);
                    Console.WriteLine(item.itemName + " equiped.");
                } else {
                    Console.WriteLine("Item not in inventory.");
                }
            } else {
                PrintErrorBadArguments();
            }
        }

        private void PrintErrorBadArguments() {
            Console.WriteLine("Error: Bad arguments.");
        }

        private void PrintHelp() {
            string helpString = 
@"Inventory commands:

help     Prints available commands";

            Console.WriteLine(helpString);
        }
    }
}