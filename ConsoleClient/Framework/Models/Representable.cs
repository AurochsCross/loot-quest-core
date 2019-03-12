namespace LootQuest.Models {
    public class Representable {
        public object Representor { get; private set; }
        public string TypeIdentifier { get; private set; }

        public void RegisterRepresentator(object representor, string identifier = "") {
            Representor = representor;
            TypeIdentifier = identifier;
        }

        public T GetRepresentor<T>() {
            return (T)Representor;
        }
    }
}