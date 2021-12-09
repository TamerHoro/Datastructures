using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class SetSortedArray : MultiSetSortedArray, ISetSorted
    {

        public SetSortedArray(int size) : base(size) { }

        public new bool Insert(int elem)
        {
            if (elem < 0 || amountInsertedElements >= dictArray.Length) return false; //falls falsche Eingabe oder kein Platz im Array
            if (elem == lastSearch && boolLastSearch) return false;  //falls elem zuvor gesucht und gefunden => kein Insert mehr

            if (elem == lastSearch && !boolLastSearch) //Falls gerade erst gesucht und nicht gefunden, an passende Stelle einfügen
            {
                return Insert_(elem);
            }
            else 
            {
                Search(elem);             //Ansonsten elem suchen

                if (boolLastSearch) return false; //Falls bereits vorhanden

                if (!boolLastSearch)        //Ansonsten einfügen
                {
                    return Insert_(elem);
                }
            }
            return false;           
        }
    }
}
