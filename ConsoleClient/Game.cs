namespace ConsoleClient {
    class Game {

        private CommandHandlers.MasterCommandHandler _commandHandler = new CommandHandlers.MasterCommandHandler();

        public Game() {
            System.Console.WriteLine("Game started");
        }

        public void ExecuteCommand(string command) {
            _commandHandler.ExecuteCommand(command);
        }
    }
}