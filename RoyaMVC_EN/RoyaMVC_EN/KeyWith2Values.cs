using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN
{
    public class KeyWith2Values<KeyType, Pair1Type, Pair2Type>
    {
        public KeyType Key { get; set; }
        public Pair1Type Value1 { get; set; }
        public Pair2Type Value2 { get; set; }

        public KeyWith2Values(KeyType key, Pair1Type value1, Pair2Type value2) {
            this.Key = key;
            this.Value1 = value1;
            this.Value2 = value2;
        }

    }
}
