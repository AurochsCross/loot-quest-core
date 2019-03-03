using System.Collections.Generic;
using System.Linq;
using LootQuest.Logic;

namespace ConsoleClient {
    class Game {

        public static Game Shared;

        public LootQuest.Logic.Game.Master Master { get { return _gameMaster; } } 
        public LootQuest.Logic.Player.Master PlayerMaster { get { return _playerMaster; } }

        LootQuest.Logic.Game.Master _gameMaster;
        LootQuest.Logic.Player.Master _playerMaster;

        private CommandHandlers.MasterCommandHandler _commandHandler;

        public Game() {
            Shared = this;
            _gameMaster = new LootQuest.Logic.Game.Master();
            _playerMaster = _gameMaster.playerMaster;
            
            PrepareGame();

            _commandHandler = new CommandHandlers.MasterCommandHandler();

            System.Console.WriteLine("Game started");

        }

        public void ExecuteCommand(string command) {
            _commandHandler.ExecuteCommand(command);
        }

        private void PrepareGame() {
            List<LootQuest.Models.Items.ArmorItem> items = new ConsoleClient.Helpers.InventoryGenerator().GenerateItems(10);

            items.ForEach( x => _playerMaster.equipmentCommander.AddItemToInventory(x) );

            _playerMaster.equipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.helmet ));
            _playerMaster.equipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.body ));
            _playerMaster.equipmentCommander.Equip(items.First(x => x.type == LootQuest.Models.Items.ArmorType.legs ));
        }
    }
}