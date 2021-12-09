using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class HashTabSepChain : DictionaryHash, ISetUnsorted
    {
        

        public LinkedList[] LLarray = new LinkedList[prim]; //Erstellt ein Array aus LinkedLists

        public  bool Delete(int elem)
        {
            int h = Hashfunktion(elem);

            return LLarray[h].Delete(elem);
        }

        public  bool Insert(int elem)
        {
            int h = Hashfunktion(elem); //Fügt Objekt in die Liste ein, welche von der Hashfunktion ausgegeben wird
            if (LLarray[h] == null)
            {
                LinkedList List = new LinkedList();
                List.Insert(elem);
                LLarray[h] = List;
                return true;
            }
            else
                return LLarray[h].Insert(elem);
        }

        public void Print()
        {
            for (int i = 0; i < prim; i++)
            {
                if (LLarray[i] != null)
                {
                    LLarray[i].Print(); 
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("--");
            }
        }

        public bool Search(int elem)
        {
            int h = Hashfunktion(elem); //Durchsucht nicht alle Listen, sondern nur die, in die das Objekt auch eingefügt worden wäre (s.Insert)

            return LLarray[h].Search(elem);

        }
    }
}
