using System;

namespace LootQuest.Models.Items {
    public class Item {
        public int Id;
        public String itemName;
        public Models.Common.Attributes attributes = new Models.Common.Attributes();

        public Models.Action.ActionRoot action;

        private Models.Action.ActionRoot actionCache;

        public Item(int id, string name) {
            this.Id = id;
            this.itemName = name;
        }
    }
}