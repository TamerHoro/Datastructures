using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class MultiSetSortedArray : MultiSetUnsortedArray, IMultiSetSorted
    {
        public MultiSetSortedArray(int size) : base(size) { }



        public new bool Insert(int elem) // Kommentare siehe andere Array-Inserts()
        {
            if (elem < 0 || amountInsertedElements >= dictArray.Length) return false;
            if (elem == lastSearch && !boolLastSearch)
            {
                return Insert_(elem);
            }
            else
            {
                Search(elem);
                return Insert_(elem);
            }
        }

        protected bool Insert_(int elem)
        {
            MoveUp(indexLastSearch); //Hilsklasse, die die Elemente nach oben/rechts verschiebt. Ab dem Index, an dem das elem eingefügt werden soll.
            dictArray[indexLastSearch] = elem;
            lastSearch = -1;
            boolLastSearch = false;
            indexLastSearch = -1;
            amountInsertedElements++;
            return true;
        }



        public new bool Delete(int elem) // Kommentare siehe andere Array-Delete()
        {
            if (elem < 0 || amountInsertedElements == 0) return false;
            if (elem == lastSearch && boolLastSearch) //Wenn Element gerade erst gesucht und gefunden wurde, gleich löschen
            {
                return Delete_();
            }
            else
            {
                Search(elem);
                if (boolLastSearch)
                {
                    return Delete_();
                }
                else return false;
            }
        }

        private bool Delete_() 
        {
            dictArray[indexLastSearch] = -1;
            MoveDown(indexLastSearch); //Hilfsklasse: Rückt alle Elemente auf, wenn es eine leere Stelle zwischen Elementen gibt
            lastSearch = -1;
            boolLastSearch = false;
            indexLastSearch = -1;
            amountInsertedElements--;
            return true;
        }



        public new bool Search(int elem) => QuickSearch(elem, 0, amountInsertedElements - 1) != -1;

        protected int QuickSearch(int elem, int firstIndex, int lastIndex)  //Rekursive Methode, die die Suche verkleinert
        {
            int index = (firstIndex + lastIndex) / 2;  //Suche Mitte des Arrays
            if ((dictArray[index] != elem && firstIndex == lastIndex) || amountInsertedElements == 0) //Abbruchbedingung, Element nicht gefunden
            {
                boolLastSearch = false;
                if (dictArray[index] < elem && dictArray[index] != -1) //Entscheiden, ob der Index, an dem das elem eingefügt werden sollte, rechts oder links des aktuellen "index" ist
                {
                    indexLastSearch = ++index;
                }
                else
                {
                    indexLastSearch = index;
                }
                lastSearch = elem;
                return -1;
            }
            if (dictArray[index] == elem) //2te Abbruchbedingung, Element gefunden
            {
                boolLastSearch = true;
                indexLastSearch = index;
                lastSearch = elem;
                return index;
            }
            //Verkleinere Problem:
            if (dictArray[index] > elem || dictArray[index] == -1) //Wenn Element an aktuellem Index größer ist als elem, suche erneut aber unterhalb des aktuellen Index
            {
                return QuickSearch(elem, firstIndex, index == 0 ? index : index -= 1); //Sonderfall abdecken, falls lastIndex == 0 ist
            }
            else if (dictArray[index] < elem)       //Wenn Element an aktuellem Index kleiner ist als elem, suche erneut aber oberhalb des aktuellen Index
            {
                return QuickSearch(elem, index + 1, lastIndex);
            }
            return -1;
        }



        protected void MoveDown(int index) //Schiebt alle Elemente nach dem index nach unten/links
        {
            if (index + 1 < amountInsertedElements)
            {
                if (dictArray[index + 1] != -1)
                {
                    dictArray[index] = dictArray[index + 1];
                    MoveDown(index + 1);
                }
            }
            else
                dictArray[index] = -1;
        }

        protected void MoveUp(int index) //Schiebt alle Elemente ab index nach oben/rechts
        {
            if (amountInsertedElements < dictArray.Length)
            {
                for (int i = amountInsertedElements; i > index; i--)
                {
                    if (i != 0)
                        dictArray[i] = dictArray[i - 1];
                }
                dictArray[index] = -1;
            }
        }
    }
}
