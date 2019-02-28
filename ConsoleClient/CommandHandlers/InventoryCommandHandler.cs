using System;

namespace ConsoleClient.CommandHandlers {
    public class InventoryCommandHandler: ICommandHandler {
        public void ExecuteCommand(string command) {
            Console.WriteLine(String.Format("Executing inventory command: {0}", command));
        }
    }
}