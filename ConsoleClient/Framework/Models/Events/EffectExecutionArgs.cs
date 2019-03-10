using System;

namespace LootQuest.Models.Events {
    public class EffectExecutionArgs: EventArgs {
        public LootQuest.Models.Action.ActionRoot Action { get; private set; }
        public Logic.Pawns.BattlePawn Source { get; private set; }
        public Logic.Pawns.BattlePawn Target { get; private set; }
        public int ExecutedEffectIndex { get; private set; }

        public EffectExecutionArgs(LootQuest.Models.Action.ActionRoot action, Logic.Pawns.BattlePawn source, Logic.Pawns.BattlePawn target, int executedEffectIndex) {
            Action = action;
            Source = source;
            Target = target;
            ExecutedEffectIndex = executedEffectIndex;
        }
    }
}