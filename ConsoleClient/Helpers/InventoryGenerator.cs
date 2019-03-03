using Models.Items;
using Models.Action;
using System.Collections.Generic;

namespace ConsoleClient.Helpers {
    public class InventoryGenerator {
        
        private System.Random _random = new System.Random();
        public List<ArmorItem> GenerateItems(int count) {
            List<ArmorItem> result = new List<ArmorItem>();

            for (int i = 0; i < count; i++) {
                result.Add(GenerateRandomItem());
            }
            
            return result;
        }

        private ArmorItem SimplePants() {

            ArmorItem item = new ArmorItem("Simple Pants", ArmorType.legs);
            item.attributes = new Models.Common.Attributes(5, 7, 3);
            return null;
        }

        private ArmorItem GenerateRandomItem() {

            string[] names = new string[] { "Broken", "New", "Stolen", "Green", "Metal", "Bronze", "Weird", "Colorful", "Skimpy", "Funny looking", "Uncanny", "Sportish", "Shiny", "Quirky" };

            ArmorType armorType = (ArmorType)(_random.Next(3) + 1);
            string name = names[_random.Next(names.Length)] + " " + GetTypeName(armorType);

            ArmorItem item = new ArmorItem(name, armorType);
            item.attributes = new Models.Common.Attributes(_random.Next(20), _random.Next(20), _random.Next(20));
            item.action = _random.Next(2) == 0 ? ActionBasicAttack() : ActionBasicHeal();

            return item;
        }

        private string GetTypeName(ArmorType armorType) {
            switch (armorType) {
                case ArmorType.body: return "Body";
                case ArmorType.helmet: return "Helmet";
                case ArmorType.legs: return "Legs";
            }

            return "Unidentified";
        }

        private ActionRoot ActionBasicHeal() {
            ActionEffect effect = new ActionEffect(0, null, "([s:intelligence] * 0.1)", EffectType.Heal, EffectSubject.Source);
            ActionRoot root = new ActionRoot();
            root.id = 0;
            root.name = "Basic Heal";
            root.description = "Heals user based on it's intelligence.";
            root.effects = new ActionEffect[] { effect };

            return root;
        }

        private ActionRoot ActionBasicAttack() {
            ActionEffect effect = new ActionEffect(0, null, "([s:strength] * 0.1)", EffectType.Damage, EffectSubject.Target);
            ActionRoot root = new ActionRoot();
            root.id = 0;
            root.name = "Basic Attack";
            root.description = "Attacks target based on users strength.";
            root.effects = new ActionEffect[] { effect };

            return root;
        }
    }
}