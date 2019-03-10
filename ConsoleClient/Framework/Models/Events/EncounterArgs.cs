using System;

namespace LootQuest.Models.Events {
    public class EncounterArgs: EventArgs {
        
        private LootQuest.Logic.Bases.Commanders.BattleCommander _npcBattleCommander;

        public EncounterArgs(int instanceId, LootQuest.Logic.Bases.Commanders.BattleCommander npcCommander) {
            _npcBattleCommander = npcCommander;
            InstanceId = instanceId;
        }

        public LootQuest.Logic.Bases.Commanders.BattleCommander NpcBattleCommander {
            get {
                return _npcBattleCommander;
            }
        }

        public int InstanceId = 0;
    }
}