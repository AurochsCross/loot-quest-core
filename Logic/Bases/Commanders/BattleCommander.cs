using System.Collections.Generic;

namespace Logic.Bases.Commanders {
    public class BattleCommander {
        public Logic.Pawns.BattlePawn battlePawn { get; private set; }
        public Logic.Battle.Battlefield battlefield;

        public BattleCommander(Models.Common.Attributes baseAttributes, List<Models.Action.ActionRoot> actions) {
            battlePawn = new Logic.Pawns.BattlePawn(baseAttributes, actions);
        }
    }
}