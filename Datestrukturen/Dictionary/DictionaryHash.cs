using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    abstract class DictionaryHash 
    {
        public static int prim = 19; //Größe des Arrays 19, da es die p=4n+3 Regel gibt, damit durch die Hashverfahren (HashTabSepChain, HashTabQuadProb) wirklich alle Felder des Arrays abgedeckt werden können. (p muss dabei Primzahl sein)
        public virtual int Hashfunktion(int s)
        {
            return s % prim; //Hashfunktion: Division
        }

        
    }
}
