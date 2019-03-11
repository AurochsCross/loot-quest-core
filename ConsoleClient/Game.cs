using System.Collections.Generic;
using System.Linq;
using LootQuest.Logic;

namespace ConsoleClient {
    class Game {

        public static Game Shared;

        public LootQuest.Logic.Game.Master Master { get { return _gameMaster; } } 
        LootQuest.Logic.Game.Master _gameMaster;

        private CommandHandlers.MasterCommandHandler _commandHandler;

        public Game() {
            Shared = this;
            _gameMaster = new LootQuest.Logic.Game.Master();
            
            PrepareGame();

            _commandHandler = new CommandHandlers.MasterCommandHandler();

            System.Console.WriteLine("Game started");

        }

        public void ExecuteCommand(string command) {
            _commandHandler.ExecuteCommand(command);
        }

        private void PrepareGame() {
            List<LootQuest.Models.Items.ArmorItem> items = new ConsoleClient.Helpers.InventoryGenerator().GenerateItems(10);

            items.ForEach( x => _gameMaster.PlayerMaster.EquipmentCommander.AddItemToInventory(x) );

            _gameMaster.PlayerMaster.EquipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.helmet ));
            _gameMaster.PlayerMaster.EquipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.body ));
            _gameMaster.PlayerMaster.EquipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.legs ));
        }
    }
}