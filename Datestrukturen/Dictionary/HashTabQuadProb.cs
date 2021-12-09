using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class HashTabQuadProb : DictionaryHash, ISetUnsorted
    {
        public Node[] HashTab = new Node[prim];

        private int search(int elem)
        {
            int v = -1;
            for (int i = 0; i < HashTab.Length; i++)
            {
                if (HashTab[i] != null)
                {
                    if (HashTab[i].IntValue == elem)
                    {
                        v = i;              //liefert den Index der gefundenen Stelle zurück
                        break;
                    }
                }
            }
            return v;                       //falls es nicht gefunden wurde liefert es -1 zurück
        }

        public bool Delete(int elem)
        {
            int b = search(elem);
            if (b == -1)
                return false;

            HashTab[b] = null;
            return true;
        }

        public bool Insert(int elem)
        {

            int t = -1;                 //prüfen ob Tabelle voll ist
            for (int i = 0; i < HashTab.Length; i++)
            {
                if (HashTab[i] == null)
                {
                    t = 1;              //t wird auf 1 gesetzt, sobald das erste freie Feld gefunden wurde
                    break;
                }
            }

            if (t == 1)
            {
                int fv = 0;
                int v1 = Hashfunktion(elem);
                int v2=v1;
                while (HashTab[v2] != null)     //solange ein Wert in v1 steht wird nach dem nächsten Platz gesucht
                {
                    fv++;
                    v2 = (v1 + fv*fv) % prim;      //sucht es mithilfe quadratischer Sondierung

                    if (HashTab[v2] != null)
                    { 
                        v2 = (v1 - fv*fv) % prim;
                        if (v2 < 0)
                            v2 = prim + v2;
                    }
                }

                Node neuNode = new Node(elem);
                HashTab[v2] = neuNode;
                return true;

            }
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < HashTab.Length; i++)
            {
                if (HashTab[i] == null)
                    Console.WriteLine("--");
                else
                    Console.WriteLine(HashTab[i].IntValue);
            }
        }

        public bool Search(int elem)
        {
            if (search(elem) == -1)
                return false;
            return true;
        }

    }
}
