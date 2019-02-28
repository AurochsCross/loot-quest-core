using System.Collections.Generic;
using System.Linq;

namespace ConsoleClient {
    class Game {

        public static Game Shared;

        public Logic.Game.Master Master { get { return _gameMaster; } } 
        public Logic.Player.Master PlayerMaster { get { return _playerMaster; } }

        Logic.Game.Master _gameMaster;
        Logic.Player.Master _playerMaster;

        private CommandHandlers.MasterCommandHandler _commandHandler;

        public Game() {
            Shared = this;
            _gameMaster = new Logic.Game.Master();
            _playerMaster = _gameMaster.playerMaster;
            
            PrepareGame();

            _commandHandler = new CommandHandlers.MasterCommandHandler();

            System.Console.WriteLine("Game started");

        }

        public void ExecuteCommand(string command) {
            _commandHandler.ExecuteCommand(command);
        }

        private void PrepareGame() {
            List<Models.Items.ArmorItem> items = new ConsoleClient.Helpers.InventoryGenerator().GenerateItems(10);

            items.ForEach( x => _playerMaster.equipmentCommander.AddItemToInventory(x) );
        }
    }
}