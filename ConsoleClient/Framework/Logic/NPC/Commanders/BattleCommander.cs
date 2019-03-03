using System.Collections.Generic;
using LootQuest.Models.Action;
using LootQuest.Models.Common;

namespace LootQuest.Logic.NPC.Commanders {
    public class BattleCommander : Logic.Bases.Commanders.BattleCommander
    {
        public BattleCommander(string name, Attributes baseAttributes, List<ActionRoot> actions) : base(name, baseAttributes, actions) {
            
        }
    }
}