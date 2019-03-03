using System.Collections.Generic;
using Models.Action;
using Models.Common;

namespace Logic.NPC.Commanders {
    public class BattleCommander : Logic.Bases.Commanders.BattleCommander
    {
        public BattleCommander(string name, Attributes baseAttributes, List<ActionRoot> actions) : base(name, baseAttributes, actions) {
            
        }
    }
}