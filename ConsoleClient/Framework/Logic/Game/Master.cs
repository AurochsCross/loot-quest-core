namespace Logic.Game {
    public class Master {

        public Player.Master playerMaster { get; private set; }
        public Commanders.BattleCommander currentBattleCommander { get; private set; }

        public Master() {
            playerMaster = new Player.Master();
        }

        public void StartEncounter(NPC.Commanders.BattleCommander npcBattleCommander) {
            currentBattleCommander = new Commanders.BattleCommander();
            currentBattleCommander.SetupBattle(new Bases.Commanders.BattleCommander[]{ playerMaster.battleCommander, npcBattleCommander });
        } 
    }
}