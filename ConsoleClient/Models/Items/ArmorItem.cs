
namespace Models.Items {
    public class ArmorItem : Item 
    {
        public ArmorType type;
        public ArmorItem(string name, ArmorType type) : base(name) {
            this.type = type;
        }
    }
}