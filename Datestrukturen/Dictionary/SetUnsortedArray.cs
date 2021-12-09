using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class SetUnsortedArray : MultiSetUnsortedArray, ISetUnsorted
    {
        public SetUnsortedArray(int size) : base(size){ }

        public new bool Insert(int elem) 
        {
            if (elem < 0 || amountInsertedElements == dictArray.Length) return false;

            if (elem == lastSearch && !boolLastSearch) //Falls das Element zuvor gesucht, aber nicht gefunden wurde, kann es gleich eingefügt werden
            {
                dictArray[indexLastSearch] = elem;
                return Insert_();
            }
            if (Search(elem)) return false; //Element bereits vorhanden.

            dictArray[indexLastSearch] = elem; //Wenn noch nicht vohanden, einfügen
            return Insert_();
        }
    }
}
