using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Models.Action {
    [DataContract]
    public class ActionRoot
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public string description;
        [DataMember]
        public ActionEffect[] effects;

        public void Reset() {
            effects.ToList().ForEach( x => x.Reset() );
        }
    }
}