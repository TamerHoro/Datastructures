using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class Node 
    {
        protected int intValue;
        public int IntValue
        {
            get { return intValue; }
            set { intValue = value; }
        }
        
        public Node() { }
        public Node(int intValue)
        {
            this.intValue = intValue;
        }
    }
}
