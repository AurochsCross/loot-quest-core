using System.Runtime.Serialization;

namespace Models.Action {
    public enum ActionType { Damage, Heal };

    [System.Serializable]
    [DataContract]
    public class ActionEffect {
        [DataMember]
        public int id;
        
        [DataMember]
        public int type;

        [DataMember]
        public string hitCalculation;

        [DataMember]
        public string valueCalculation;

        public bool didHit = false;

        public float calculatedValue = 0f;

        public ActionEffect(int id, string hitCalculation, string valueCalculation, ActionType type) {
            this.id = id;
            this.hitCalculation = hitCalculation;
            this.valueCalculation = valueCalculation;
            this.type = (int)type;
        }

        public void Reset() {
            didHit = false;
            calculatedValue = 0f;
        }
    }
}