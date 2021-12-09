using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    interface IDictionary
    {
        bool Search(int elem);
        bool Insert(int elem);
        bool Delete(int elem);
        void Print();
    }
}
