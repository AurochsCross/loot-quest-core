using System.Collections.Generic;
using Models.Action;
using Models.Common;

namespace Logic.Player.Commanders {
    public class BattleCommander : Logic.Bases.Commanders.BattleCommander
    {
        public BattleCommander(Attributes baseAttributes, List<ActionRoot> actions) : base(baseAttributes, actions)
        {
        }
    }
}