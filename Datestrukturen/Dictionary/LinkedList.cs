using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class LinkedList : IMultiSetUnsorted
    {
        protected LLNode root;
        protected LLNode current;
        public LLNode Root
        {
            get { return root;}
        }

        public LinkedList() 
        {
            current = null;
            this.root = current;
            
        }

        public bool Delete(int elem)
        {
            if (root == null)
            {
                return false;
            }
            if (elem == root.IntValue)           //Delete first element
            {
                if(root.next == null)
                {
                    root = null;
                    return true;
                }
                
                root.next.previous = null;          // Switched
                root = root.next;
            }
            else if (Search(elem))                    //Search elem
            {
                if (current.next == null)      //Delete last element
                {
                    current.previous.next = null;                    
                    return true;
                }
                else                          //Delete element in the middle of the list
                {
                    current.next.previous = current.previous;
                    current.previous.next = current.next;
                    return true;
                }                
            }
            return false;                       //Element not found
        }

        public bool Insert(int elem)
        {
            current = root;
            if(root== null)                                  //insert first Element
            {
                root = new LLNode(elem);
                return true;
            }
            while(current.next != null)
            {
                current = current.next;                
            }
            current.next = new LLNode(elem);                //insert last Element
            current.next.previous =current;

            return true;
        }

        public void Print()
        {
            current = root;
            if(current == null)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                //Console.Write(current.IntValue);
                //current = current.next;
                while (current != null)
                {
                    Console.Write($"{current.IntValue} ");
                    current = current.next;
                }
                Console.WriteLine();
            }
            
            
        }

        public bool Search(int elem)
        {
            current = root;
            
            while (current!=null)
            {
                if (elem == current.IntValue)
                {
                    return true;
                }
                current = current.next;
                
            }
            return false;
        }
    }
}
