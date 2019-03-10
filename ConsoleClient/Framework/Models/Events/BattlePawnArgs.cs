using System;

namespace LootQuest.Models.Events {
    public class BattlePawnArgs: EventArgs {
        public LootQuest.Logic.Pawns.BattlePawn Pawn { get; private set; }
        public int Amount { get; private set; }

        public BattlePawnArgs(LootQuest.Logic.Pawns.BattlePawn pawn, int amount) {
            Pawn = pawn;
            Amount = amount;
        }
    }
}