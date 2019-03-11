using System;
using System.Collections.Generic;
using System.Linq;
using LootQuest;

namespace ConsoleClient.CommandHandlers {
    public class BattleCommandHandler: BaseCommandHandler {

        protected override void ExecuteCommand(string command, Dictionary<string, string> arguments) {
            switch (command) {
                case "help": PrintHelp();
                break;
                case "startDummyBattle" : StartDummyBattle();
                break;
                case "state": PrintBattleState();
                break;
                case "useAction": UseAction();
                break;
                default: Console.WriteLine("Inventory command not recognized.");
                break;
            }
        }

        private void PrintBattleState() {
            Game.Shared.Master.CurrentBattleCommander.Commanders.ToList().ForEach( x => {
                Console.WriteLine(x.Name);
                Console.WriteLine(String.Format("Hp: {0}/{1}", x.BattlePawn.currentHitPoints, x.BattlePawn.maxHitPoints));
                Console.WriteLine();
            } );
        }

        private void StartDummyBattle() {
            // LootQuest.Models.Common.Attributes attributes = new LootQuest.Models.Common.Attributes(30, 5, 7);
            // LootQuest.Logic.NPC.Commanders.BattleCommander npcCommander = new LootQuest.Logic.NPC.Commanders.BattleCommander("Dummy", attributes, null);
            // Game.Shared.Master.StartEncounter(npcCommander);
            // Console.WriteLine("Battle started");
        }

        private void UseAction() {
            // var actions = Game.Shared.PlayerMaster.Actions;
            
            // int id = 0;

            // actions.ForEach( x =>  { 
            //     Console.WriteLine(id + ": " + x.name + " - " + x.description);
            //     id++; 
            // });

            // Console.WriteLine();
            // Console.Write("Action to use: ");
            // int actionUsed = int.Parse(Console.ReadLine());

            // Game.Shared.Master.currentBattleCommander.ExecuteAction(actions[actionUsed], Game.Shared.PlayerMaster.battleCommander.battlePawn);

            // Console.WriteLine("Action used: " + actions[actionUsed].name);
        }

        public override void PrintHelp() {
            string helpString = 
@"Battle commands:

Print help:                           help     
Start dummy battle:                   startDummyBattle
Show current battle state             state";

            Console.WriteLine(helpString);
        }
    }
}