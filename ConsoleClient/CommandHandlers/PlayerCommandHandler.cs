using System;
using System.Linq;
using System.Collections.Generic;
using LootQuest.Models.Items;


namespace ConsoleClient.CommandHandlers {
    public class PlayerCommandHandler : BaseCommandHandler
    {
        private LootQuest.Logic.Player.Master _player;

        public PlayerCommandHandler() {
            _player = Game.Shared.PlayerMaster;
        }

        protected override void ExecuteCommand(string command, Dictionary<string, string> arguments) {
            switch (command) {
                case "help": PrintHelp();
                break;
                case "stats": PrintStats();
                break;
                case "actions": PrintActions();
                break;
                default: Console.WriteLine("Inventory command not recognized.");
                break;
            }
        }

        private void PrintStats() {
            var stats = _player.Attributes;

            Console.WriteLine(String.Format("Strength: {0}", stats.strength));
            Console.WriteLine(String.Format("Dexterity: {0}", stats.dexterity));
            Console.WriteLine(String.Format("Intelligence: {0}", stats.intelligence));
        }

        private void PrintActions() {
            var actions = _player.Actions;

            actions.ForEach( x => Console.WriteLine(x.name + ": " + x.description));
        }

        public override void PrintHelp() {
            string helpString = 
@"Player commands:

Print help:                           help
Show player stats:                    stats
Show player actions:                  actions";

            Console.WriteLine(helpString);
        }
    }
}