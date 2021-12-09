using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class SetSortedLinkedList : MultiSetSortedLinkedList, ISetSorted
    {
        public SetSortedLinkedList() : base() { }

        
        public new bool Insert(int elem)
        {
            if (Search(elem))   return false;       // Ask if element is in List 
            base.Insert(elem);                      // Normal Set Insert
            return true;
        }
    }
}
