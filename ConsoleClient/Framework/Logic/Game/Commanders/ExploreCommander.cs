using System.Collections.Generic;
using LootQuest.Models.Exploring;
using System.Linq;

namespace LootQuest.Logic.Game.Commanders {
    public class ExploreCommander {
        public List<Pawns.ExplorePawn> Hostiles { get; private set; } = new List<Pawns.ExplorePawn>();
        public LootQuest.Logic.Pawns.ExplorePawn Player;
        private Master _master;

        public ExploreCommander(Master master) {
            _master = master;
        }

        public void RegisterHostile(LootQuest.Logic.Pawns.ExplorePawn pawn) {
            Hostiles.Add(pawn);
        }

        public void MovePlayer(Position position) {
            Player.CurrentPosition = position;
            var hostile = HostileAtPosition(position);
            if (hostile != null) {
                _master.StartEncounter(hostile);
            }
        }

        private LootQuest.Logic.Pawns.ExplorePawn HostileAtPosition(Position position) {
            return Hostiles.Where( x => x.CurrentPosition == position).FirstOrDefault();
        }

    }
}