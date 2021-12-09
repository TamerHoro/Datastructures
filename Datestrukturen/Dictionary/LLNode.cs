using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class LLNode : Node
    {
        public LLNode next=null; //Bei Liste nur einen der beiden benutzen.
        public LLNode previous=null;

        public LLNode(int elem) : base(elem)
        {
            //public LLNode(int elem) :  Möglichererweise nötig, warten auf Test
        }

    }
}
