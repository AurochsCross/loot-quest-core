using LootQuest.Models.Exploring;

namespace LootQuest.Logic.Pawns {
    public class ExplorePawn {
        public LootQuest.Logic.Bases.Commanders.BattleCommander BattleCommander;
        public Position CurrentPosition;

        public int InstanceId { get; private set; }

        public ExplorePawn(int instanceId = 0) {
            InstanceId = instanceId;
            CurrentPosition = new Position();
        }

        public ExplorePawn(Position position, int instanceId = 0) {
            InstanceId = instanceId;
            CurrentPosition = position;
        }
    }
}