using System.Collections.Generic;
using System.Linq;
using LootQuest.Logic.Actions;

namespace LootQuest.Logic.Game.Commanders {
    public class BattleCommander {

        #region Event

        public delegate void BattleHandler(object myObject, Models.Events.BattlePawnArgs args);
        public event BattleHandler OnDamageTaken;
        public event BattleHandler OnHealingTaken;

        public delegate void EffectHandler(object myObject, Models.Events.EffectExecutionArgs args);

        public event EffectHandler BeganEffectExecution;
        public event EffectHandler FinishedEffectExecution;

        #endregion

        public Battle.Battlefield Battlefield { get; private set; }
        public Logic.Bases.Commanders.BattleCommander[] Commanders { get; private set; }

        private Logic.Game.Master _master;

        public BattleCommander(Master master) {
            _master = master;
        }

        public void SetupBattle(Logic.Bases.Commanders.BattleCommander[] battleCommanders) {
            Commanders = battleCommanders;
            Battlefield = new Battle.Battlefield(this, Commanders);
        }

        public Logic.Pawns.BattlePawn GetOtherPawn(Logic.Pawns.BattlePawn pawn) {
            return Commanders.First(x => x.battlePawn != pawn).battlePawn;
        }

        public void ExecuteAction(LootQuest.Models.Action.ActionRoot action, Logic.Pawns.BattlePawn source) {
            ExecuteAction(action, source, GetOtherPawn(source));
        }

        public void ExecuteAction(LootQuest.Models.Action.ActionRoot action, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target) {
            action.Reset();
            ExecuteNextAction(action.effects[0].Delay, action, source, target, 0);
        }

        private async void ExecuteNextAction(float delay, LootQuest.Models.Action.ActionRoot action, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target, int effectIndex) {
            var args = new Models.Events.EffectExecutionArgs(action, source, target, effectIndex);
            // EffectHandler effectBegan = BeganEffectExecution;
            // if (effectBegan != null) {
            //     effectBegan(this, args);
            // }

            if (BeganEffectExecution != null) {
                BeganEffectExecution(this, args);
            }
            
            await System.Threading.Tasks.Task.Delay((int)(delay * 1000));

            ExecuteActionEffect(action, action.effects[effectIndex], source, target);

            // EffectHandler effectFinished = FinishedEffectExecution;
            // if (effectFinished != null) {
            //     effectFinished(this, args);
            // }
            if (FinishedEffectExecution != null) {
                FinishedEffectExecution(this, args);
            }

            int nextEffectIndex = effectIndex + 1;
            if (nextEffectIndex < action.effects.Length) {
                ExecuteNextAction(action.effects[nextEffectIndex].Delay, action, source, target, nextEffectIndex);
            }
        }

        private bool ExecuteActionEffect(LootQuest.Models.Action.ActionRoot action, LootQuest.Models.Action.ActionEffect effect, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target) {
            if (Actions.Helpers.ActionCalculationHelper.CalculateDidHit(effect.hitCalculation, action, source, target)) {
                effect.didHit = true;

                var value = Actions.Helpers.ActionCalculationHelper.CalculateValue(effect.valueCalculation, action, source, target);
                effect.calculatedValue = value;

                var subject = effect.subject == LootQuest.Models.Action.EffectSubject.Source ? source : target;

                if (effect.type == LootQuest.Models.Action.EffectType.Damage) {
                    subject.TakeDamage((int)value);
                    this.OnDamageTaken(this, new Models.Events.BattlePawnArgs(subject, (int)value));
                } else if (effect.type == LootQuest.Models.Action.EffectType.Heal) {
                    subject.TakeHealing((int)value);
                    this.OnHealingTaken(this, new Models.Events.BattlePawnArgs(subject, (int)value));
                }

                return true;
            }

            return false;
        }
    }
}