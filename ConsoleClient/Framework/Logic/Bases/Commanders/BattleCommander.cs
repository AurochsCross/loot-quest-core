using System.Collections.Generic;

namespace Logic.Bases.Commanders {
    public class BattleCommander {
        public string Name { get; private set; }
        public Logic.Pawns.BattlePawn battlePawn { get; private set; }
        public Logic.Battle.Battlefield battlefield;

        public BattleCommander(string name, Models.Common.Attributes baseAttributes, List<Models.Action.ActionRoot> actions) {
            Name = name;
            battlePawn = new Logic.Pawns.BattlePawn(baseAttributes, actions);
        }
    }
}