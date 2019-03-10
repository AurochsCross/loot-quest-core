using System.Collections.Generic;
using LootQuest.Models.Action;
using LootQuest.Models.Common;

namespace LootQuest.Logic.Entity.Commanders {
    public class BattleCommander {
        public string Name { get; private set; }
        public Logic.Pawns.BattlePawn battlePawn { get; private set; }
        public Logic.Battle.Battlefield battlefield;

        public BattleCommander(string name, LootQuest.Models.Common.Attributes baseAttributes, List<LootQuest.Models.Action.ActionRoot> actions) {
            Name = name;
            battlePawn = new Logic.Pawns.BattlePawn(baseAttributes, actions);
        }

        public void UseAction(LootQuest.Models.Action.ActionRoot action) {
            battlefield.battleManager.ExecuteAction(action, battlePawn);
        }
    }
}