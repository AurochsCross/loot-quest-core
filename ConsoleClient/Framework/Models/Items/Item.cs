using System;

namespace LootQuest.Models.Items {
    public class Item {
         
        public String itemName;
        public Models.Common.Attributes attributes = new Models.Common.Attributes();

        public Models.Action.ActionRoot action;

        private Models.Action.ActionRoot actionCache;

        public Item(string name) {
            this.itemName = name;
        }
    }
}