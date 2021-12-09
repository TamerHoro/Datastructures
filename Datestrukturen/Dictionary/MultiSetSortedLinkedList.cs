using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class MultiSetSortedLinkedList : LinkedList, IMultiSetSorted
    {
        public MultiSetSortedLinkedList() : base() { }       

        public bool InsertFirst(int elem)
        {
            //Console.WriteLine("insert before?");
            current.previous = new LLNode(elem);
            current.previous.next = current;
            root = current.previous;
            return true;
        }

        public bool InsertAfter(int elem)
        {
            current.next = new LLNode(elem);
            current.next.previous = current;
            return true;
        }     

        public new bool Insert(int elem)
        {
            current = root;
            bool insertsuccess = false; 
            if(root== null)                                         //insert first elem
            {   
                root = new LLNode(elem);
                insertsuccess = true;
                return insertsuccess;
            }
            if (root.next == null)                                  //insert second elem
            {
                if(elem>= current.IntValue)                            //insert after
                {
                    //Console.WriteLine("insert after?");
                    //current.next = new llnode(elem);
                    //current.next.previous = current;
                    insertsuccess = InsertAfter(elem);
                    return insertsuccess;
                }
                else                                                //insert before
                {
                    //Console.WriteLine("insert before?");
                    //current.previous = new LLNode(elem);
                    //current.previous.next = current;
                    //root = current.previous;
                    insertsuccess = InsertFirst(elem);
                    return insertsuccess;
                }
            }
            while (current.next != null && insertsuccess == false)
            {
                //if(elem > current.next.intvalue&&current.next.next!= null)    //
                //{
                    
                //}
                if(elem<= current.next.IntValue && elem > current.IntValue)                    //insert between
                {
                    current.next.previous = new LLNode(elem);
                    current.next.previous.next = current.next;
                    current.next = current.next.previous;
                    current.next.previous = current;
                    insertsuccess = true;
                    return insertsuccess;
                }                 
                else if(insertsuccess == false && current.previous == null && current.IntValue> elem) //insert first
                {
                    //current.previous = new LLNode(elem);
                    //current.previous.next = current;
                    //root = current.previous;
                    insertsuccess = InsertFirst(elem);
                    return insertsuccess;

                }
                current = current.next;
            }
            //current.next = new LLNode(elem);                                                         //insert last
            //current.next.previous = current;
            insertsuccess = InsertAfter(elem);
            return insertsuccess;

        }
    }
}
