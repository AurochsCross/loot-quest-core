using System.Collections.Generic;
using System.Linq;
using Logic.Actions;
using org.mariuszgromada.math.mxparser;

namespace Logic.Game.Commanders {
    public class BattleCommander {

        public Battle.Battlefield Battlefield { get; private set; }
        public Logic.Bases.Commanders.BattleCommander[] Commanders { get; private set; }

        public void SetupBattle(Logic.Bases.Commanders.BattleCommander[] battleCommanders) {
            Commanders = battleCommanders;
            Battlefield = new Battle.Battlefield(Commanders);
        }

        public Logic.Pawns.BattlePawn GetOtherPawn(Logic.Pawns.BattlePawn pawn) {
            return Commanders.First(x => x.battlePawn != pawn).battlePawn;
        }

        public void ExecuteAction(Models.Action.ActionRoot action, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target) {
            action.Reset();
            foreach (var actionEffect in action.effects) {
                ExecuteActionEffect(action, actionEffect, source, target);
            }
        }

        private void ExecuteActionEffect(Models.Action.ActionRoot action, Models.Action.ActionEffect effect, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target) {
            if (Actions.Helpers.ActionCalculationHelper.CalculateDidHit(effect.hitCalculation, action, source, target)) {
                effect.didHit = true;

                var value = Actions.Helpers.ActionCalculationHelper.CalculateValue(effect.valueCalculation, action, source, target);
                effect.calculatedValue = value;

                if (effect.type == 0) {
                    target.TakeDamage((int)value);
                } else if (effect.type == 1) {
                    source.TakeHealing((int)value);
                }  
            }
        }
    }
}