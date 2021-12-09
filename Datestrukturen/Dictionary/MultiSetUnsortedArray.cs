using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class MultiSetUnsortedArray : IMultiSetUnsorted
    {
        //Hilfreiche Attribute
        protected int[] dictArray;
        protected int lastSearch = -1; //Element was als letztes gesucht wurde
        protected int indexLastSearch = -1; //Index der letzten Suche (Entweder an Stelle des Elements oder an Stelle an der es eingefügt werden sollte)
        protected bool boolLastSearch; // war letzte Suche erfolgreich
        protected int amountInsertedElements = 0; //Anzahl der enthaltenen Elemente;

        public MultiSetUnsortedArray(int size) {
            if (size < 1) throw new Exception("Die Größe des Arrays muss mindestens 1 betragen");

            dictArray = new int[size];          //Legt neues Array an
            for (int i = 0; i < dictArray.Length; i++) //-1 bildet einen leeren Wert im Array ab
            {
                dictArray[i] = -1;                     // Array mit -1 füllen, da standartmäßig mit 0 gefüllt
            }
        }


        //Methoden
        public bool Delete(int elem) 
        {
            if (elem < 0 || amountInsertedElements == 0) return false; //Falls Eingabe nicht zulässig oder keine Elemente in Array

            if (elem == lastSearch && boolLastSearch) //Wenn Element gerade erst gesucht und gefunden wurde, gleich löschen
            {
                dictArray[indexLastSearch] = -1;
                return Delete_();
            }
            int index = Search_(elem);              //Ansonsten suchen

            if (index == -1) return false;          //Sollte Element nicht im Array sein
            else 
            {
                dictArray[index] = -1;              //löschen, falls Element gefunden
                return Delete_();
            }
        }

        private bool Delete_()  //Hilfsklasse: Setzt letzte Suche zurück und gibt true zurück
        {
            lastSearch = -1;
            boolLastSearch = false;
            indexLastSearch = -1;
            amountInsertedElements--;
            return true;
        }

        public void Print() 
        {
            foreach (int i in dictArray) {          //Gibt nur die Elemente des Arrays aus, die auch enthalten sind
                if(i != -1) 
                    Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public bool Insert(int elem) 
        {
            if (elem < 0 || amountInsertedElements == dictArray.Length) return false; //Falls falsche Eingabe oder kein Platz mehr für neues Element

            if (elem == lastSearch && !boolLastSearch) //falls das Element zuvor gesucht, aber nicht gefunden wurde, kann es gleich eingefügt werden
            {
                dictArray[indexLastSearch] = elem;
                return Insert_();
            }
            int index = Search_(-1);  //Erste freie Stelle zum Einfügen suchen

            if (index == -1) return false; // keine freie Stelle gefunden
            else
            {
                dictArray[index] = elem; // einfügen
                return Insert_();
            }
        }

        protected bool Insert_()  //Hilfsklasse: setzt letzte Suche zurück und gibt true zurück
        {
            lastSearch = -1;
            boolLastSearch = false;
            indexLastSearch = -1;
            amountInsertedElements++;
            return true;
        }

        protected int Search_(int elem)
        {
            bool firstEmptyFound = false; //für den Fall, dass elem nicht gefunden wurde, wird erste freie Stelle gemerkt

            for (int i = 0; i < dictArray.Length; i++)
            {
                if (dictArray[i] == elem) // Wenn Element gefunden
                {
                    lastSearch = elem;  //Werte zwischenspeichern und Stelle des gefundenen elem zurückgeben
                    indexLastSearch = i;
                    boolLastSearch = true;
                    return i;
                }
                else if (dictArray[i] == -1)  //Wenn Element nicht gefunden
                {
                    if(!firstEmptyFound) 
                    {                           //Merkt sich erste freie Stelle zum Einfügen
                        firstEmptyFound = true;
                        lastSearch = elem;
                        indexLastSearch = i;
                    }
                }
            }
            boolLastSearch = false;  //Suche war erfolglos
            return -1;
        }

        public bool Search(int elem) 
        {
            if (Search_(elem) == -1)
            {
                return false;
            }
            return true;
        }
    }
}
