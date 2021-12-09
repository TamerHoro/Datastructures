using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class TNode : BTNode 
    {
        int prio;
        public new TNode left, right;
        public TNode(int elem, int prio) : base(elem)
        {
            this.prio = prio;
        }
        public int Prio
        {
            get { return prio; }
            set { prio = value; }
        }

    }
}
