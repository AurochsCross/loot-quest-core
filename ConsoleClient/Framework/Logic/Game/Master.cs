namespace LootQuest.Logic.Game {
    public class Master {

        #region Events 

        public delegate void EncounterHandler(object myObject, Models.Events.EncounterArgs args);
        public event EncounterHandler OnEncounterStarted;

        #endregion

        public Player.Master playerMaster { get; private set; }
        
        public Commanders.BattleCommander currentBattleCommander { get; private set; }

        public Commanders.ExploreCommander ExploreCommander { get; private set; }

        public Master() {
            playerMaster = new Player.Master();
            ExploreCommander = new Commanders.ExploreCommander(this);
            ExploreCommander.Player = playerMaster.ExplorePawn;
        }

        // public void StartEncounter(LootQuest.Logic.Bases.Commanders.BattleCommander npcBattleCommander) {
        //     currentBattleCommander = new Commanders.BattleCommander();
        //     currentBattleCommander.SetupBattle(new Bases.Commanders.BattleCommander[]{ playerMaster.CreateBattleCommander(), npcBattleCommander });

        //     OnEncounterStarted(this, new Models.Events.EncounterArgs(npcBattleCommander));
        // }

        public void StartEncounter(LootQuest.Logic.Pawns.ExplorePawn npc) {
            currentBattleCommander = new Commanders.BattleCommander();
            currentBattleCommander.SetupBattle(new Bases.Commanders.BattleCommander[]{ playerMaster.CreateBattleCommander(), npc.BattleCommander });

            OnEncounterStarted(this, new Models.Events.EncounterArgs(npc.InstanceId, npc.BattleCommander));
        }
    }
}