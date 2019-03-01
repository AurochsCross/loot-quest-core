using System.Collections.Generic;

namespace Logic.Player {
    public class Master {
        public Commanders.BattleCommander battleCommander { get; private set; } 
        public Commanders.EquipmentCommander equipmentCommander { get; private set; } 

        public Models.Common.Attributes Attributes { 
            get {
                return equipmentCommander.GetAttributes();
            }
        }

        public List<Models.Action.ActionRoot> Actions {
            get {
                return equipmentCommander.GetActions();
            }
        }

        public Master() {
            equipmentCommander = new Commanders.EquipmentCommander();
        }

        public Commanders.BattleCommander CreateBattleCommander() {
            battleCommander = new Commanders.BattleCommander(equipmentCommander.GetAttributes(), equipmentCommander.GetActions());
            return battleCommander;
        }
    }
}