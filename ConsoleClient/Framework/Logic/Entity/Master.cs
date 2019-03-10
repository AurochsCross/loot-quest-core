using System.Collections.Generic;

namespace LootQuest.Logic.Entity {
    public class Master {
        public Commanders.BattleCommander BattleCommander { get; private set; } 
        public Commanders.EquipmentCommander EquipmentCommander { get; private set; } 
        public Pawns.ExplorePawn ExplorePawn { get; private set; }

        public LootQuest.Models.Common.Attributes BaseAttributes { get; private set; }

        public Master(LootQuest.Models.Common.Attributes baseAttributes) {
            BaseAttributes = baseAttributes;
        }

        public LootQuest.Models.Common.Attributes Attributes { 
            get {
                return EquipmentCommander.GetAttributes();
            }
        }

        public List<LootQuest.Models.Action.ActionRoot> Actions {
            get {
                return EquipmentCommander.GetActions();
            }
        }
    }
}