using System.Collections.Generic;
using LootQuest.Models.Action;
using LootQuest.Models.Common;

namespace Logic.Player.Commanders {
    public class BattleCommander : Logic.Bases.Commanders.BattleCommander
    {
        public BattleCommander(Attributes baseAttributes, List<ActionRoot> actions) : base("Player", baseAttributes, actions) {
            
        }
    }
}