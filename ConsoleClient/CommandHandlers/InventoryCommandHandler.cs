using System;
using System.Linq;
using System.Collections.Generic;
using LootQuest.Models.Items;

namespace ConsoleClient.CommandHandlers {
    public class InventoryCommandHandler: BaseCommandHandler {

        private LootQuest.Logic.Player.Commanders.EquipmentCommander _equipment;

        public InventoryCommandHandler() {
            _equipment = Game.Shared.PlayerMaster.equipmentCommander;
        }

        protected override void ExecuteCommand(string command, Dictionary<string, string> arguments) {
            switch (command) {
                case "help": PrintHelp();
                break;
                case "show": PrintInventory();
                break;
                case "equip": EquipItem(arguments);
                break;
                case "itemInfo": PrintItemInfo(arguments);
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

        private void PrintItemInfo(Dictionary<string, string> args) {
            string name;
            if (args.TryGetValue("name", out name) || args.TryGetValue("arg", out name)) {
                ArmorItem item = (ArmorItem)_equipment.inventory.Where(x => x.itemName == name)?.FirstOrDefault();
                if (item != null) {
                    Console.WriteLine(GetItemInfo(item));
                } else {
                    Console.WriteLine("Item not in inventory.");
                }
            } else {
                PrintErrorBadArguments();
            }
        }

        private string GetItemInfo(ArmorItem item) {
            string result = "";

            result += String.Format("Name: {0}\n", item.itemName);
            result += "Attributes:\n";
            result += String.Format("* Srength: {0}\n", item.attributes.strength);
            result += String.Format("* Intelligence: {0}\n", item.attributes.intelligence);
            result += String.Format("* Dexterity: {0}\n", item.attributes.dexterity);

            var action = item.action; 

            if (action != null) {
                result += "Action: \n";
                result += String.Format("* Name: {0}\n", action.name);
                result += String.Format("* Description: {0}\n", action.description);
            }
            
            return result;
        }

        private void PrintErrorBadArguments() {
            Console.WriteLine("Error: Bad arguments.");
        }

        public override void PrintHelp() {
            string helpString = 
@"Inventory commands:

Print help:                           help     
Lists equiped armor and inventory:    show     
Equip item:                           equip ([item name] | -name [item name])
Show item info:                       itemInfo ([item name] | -name [item name])";

            Console.WriteLine(helpString);
        }
    }
}