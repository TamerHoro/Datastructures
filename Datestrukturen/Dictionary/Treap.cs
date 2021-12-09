using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class Treap : BinSearchTree, ISetSorted
    {

        public new TNode root = null;
        public Treap() : base() { }

        public new bool Insert(int intValue)
        {
            Random rand = new Random();
            int prio = rand.Next(20000);
            if (root == null) //Tree empty?
            {
                root = new TNode(intValue, prio);
                return true;
            }
            else
            {
                root = RecursiveInsert(intValue,prio,root);
                return root != null; //!= in case insert fails
                
            }
        }

        public new bool Delete(int IntValue)
        {
            TNode temp = RecursiveDelete(IntValue, root);
            root = temp;
            return true;
        }

        protected TNode RecursiveDelete(int IntValue, TNode node)
        {
            if (node == null)
            {
                return null;
            }
            if(IntValue < node.IntValue)                // Search Elem Recursiv left ("smaller")
            {
                node.left = RecursiveDelete(IntValue, node.left);
            }
            else if(IntValue > node.IntValue)           //Search Elem Recursiv right ("bigger")
            {
                node.right = RecursiveDelete(IntValue, node.right);
            }                                           // not smaller or bigger == found 
            else if(node.left == null)                  //"Delete node" , or change node to node right
            {
                TNode temp = node.right;
                node = temp;
            }
            else if(node.right == null)                 //"Delete node" , or change node to node left
            {
                TNode temp = node.left;
                node = temp;
            }                                           //´"Delete node" right and left exist ,Check prio and Rotate to delete
            else if(node.left.Prio > node.right.Prio)
            {
                node = LeftRotation(node);
                node.left = RecursiveDelete(IntValue, node.left);       // node.left = "Delete node"
            }
            else
            {
                node = RightRotation(node);
                node.right = RecursiveDelete(IntValue, node.right);
            }
            return node;
        }

        protected TNode RecursiveInsert(int intValue, int prio, TNode node)
        {
            if (node == null)
            {
                return new TNode(intValue, prio);
            }
            if (intValue == node.IntValue)
            {
                Console.WriteLine("ERROR: Node (" + intValue + ") already exists");
                return node;
            }
            if (intValue < node.IntValue) //IntValue smaller than node.IntValue --> Insert left
            {
                
                node.left = RecursiveInsert(intValue, prio, node.left);
                if (node.Prio > node.left.Prio)
                {
                    
                    node = RightRotation(node);
                    
                }
                     
            }
            else // IntValue bigger than node. IntValue --> Insert right
            {
                
                node.right = RecursiveInsert(intValue, prio, node.right);
                if (node.Prio > node.right.Prio)
                {
                    
                    node = LeftRotation(node);
                    
                }

            }
            return node;
        }
        protected void IndentPrint(int intValue, int prio, int depth, int orientation)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t"); //Möglicherweise noch erweiterbar mit FindMax() um die anzahl der Tabs zu bestimmen
            }
            if (orientation == 0)
            {
                Console.WriteLine("--(" + intValue+","+prio + ")");
            }
            else if (orientation == 1)
            {
                Console.WriteLine(",--(" + intValue+"," + prio + ")");
            }
            else if (orientation == -1)
            {
                Console.WriteLine("'--(" + intValue + "," + prio + ")");
            }
            //Console.WriteLine("--("+intValue+")");
        }
        protected void TreePrint(TNode node, int depth = 0, int orientation = 0)
        {
            if (node != null)
            {
                TreePrint(node.right, depth + 1, 1); // 1 entspricht rechts
                IndentPrint(node.IntValue,node.Prio, depth, orientation);
                TreePrint(node.left, depth + 1, -1);  // -1 entspricht links                             
            }
        }
        public new void Print()
        {
            TreePrint(root);
        }
        public new bool Search(int IntValue)
        {
            if (Search(IntValue, root) != null)
            {
                return true;
            }
            return false;
        }



        private TNode Search(int IntValue, TNode node)
        {
            if (node == null)
            {
                return null;
            }
            else if (IntValue < node.IntValue) //IntValue smaller that value in node. IntValue, go left in tree
            {
                return Search(IntValue, node.left);
            }
            else if (IntValue > node.IntValue) //IntValue bigger that value in node --> go right
            {
                return Search(IntValue, node.right);
            }
            else
            {
                return node;
            }
        }
        public TNode RightRotation(TNode parent)
        {
            TNode pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

        public TNode LeftRotation(TNode parent)
        {
            TNode pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
    }
}
