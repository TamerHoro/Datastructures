using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class BinSearchTree :ISetSorted
    {

        protected BTNode root;


        public BinSearchTree()
        {}
        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        private void TraversePreOrder(BTNode node)
        {
            Console.WriteLine(node.IntValue);
            if (node.left != null) TraversePreOrder(node.left);
            if (node.right != null) TraversePreOrder(node.right);

        }


        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }
        private void TraverseInOrder(BTNode node)
        {
            if (node.left != null) TraverseInOrder(node.left);
            Console.WriteLine(node.IntValue);
            if (node.right != null) TraverseInOrder(node.right);
        }

        public bool Search(int IntValue)
        {
            if(Search(IntValue, root) != null)
            {
                return true;
            }
            return false;
        }

        

        private BTNode Search(int IntValue, BTNode node)
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

        public bool Insert(int intValue)
        {
            if (root == null) //Tree empty?
            {
                root = new BTNode(intValue);
                return true;
            }
            else
            {
                root = RecursiveInsert(intValue, root);
                return root!= null; //!= in case insert fails
                
            }            
        }

        protected BTNode RecursiveInsert(int intValue, BTNode node)
        {            
            if (intValue == node.IntValue)
            {
                Console.WriteLine("ERROR: Node (" + intValue +") already exists");
                return node;
            }
            if (intValue < node.IntValue) //IntValue smaller than node.IntValue --> Insert left
            {
                if (node.left == null)
                {
                    node.left = new BTNode(intValue);
                    return node;
                }
                else
                    RecursiveInsert(intValue, node.left);

            }
            else // IntValue bigger than node. IntValue --> Insert right
            {
                if (node.right == null)
                {
                    node.right = new BTNode(intValue);
                    return node;
                }
                else               
                    RecursiveInsert(intValue, node.right);                    
                
                    
            }
            return node;
        }

        protected int FindMax(BTNode node)
        {
            if (node.right == null)
            {
                return node.IntValue;
            }
            else
            {
                return FindMax(node.right);
            }

            /* alternative iterativ:
             * BTNode current = node;
             * while(current.right != null) {
             *
             *    current = current.right;
             *
             * }
             * return current.IntValue;
             */
        }

        public bool Delete(int IntValue)
        {
            BTNode temp = RecursiveDelete(IntValue, root);
            root = temp;
            return true;
        }

        protected BTNode RecursiveDelete(int IntValue, BTNode node)
        {

            if (node == null)
            {
                return null;
            }
            else if (IntValue < node.IntValue)
                node.left = RecursiveDelete(IntValue, node.left);
            else if (IntValue > node.IntValue)
                node.right = RecursiveDelete(IntValue, node.right);
            //node = Search(IntValue, node);
            else
            {
                //else                                          //Zu loeschender Knoten gefunden 
                //{
                if (node.left != null && node.right != null)    //Es gibt sowohl links als auch rechts
                {
                    node.IntValue = FindMax(node.left);
                    node.left = RecursiveDelete(node.IntValue, node.left);
                }
                else if (node.left != null) //Es gibt keinen rechten
                {                   
                    node = node.left;
                }
                else//Es gibt keinen linken
                {
                    node = node.right;
                }
            }
            //}
            return node;
        }

        protected void IndentPrint(int intValue, int depth, int orientation)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("\t"); //Möglicherweise noch erweiterbar mit FindMax() um die anzahl der Tabs zu bestimmen
            }
            if (orientation == 0)
            {
                Console.WriteLine("--(" + intValue + ")");
            }
            else if (orientation == 1)
            {
                Console.WriteLine(",--(" + intValue + ")");
            }
            else if (orientation == -1)
            {
                Console.WriteLine("'--(" + intValue + ")");
            }
            //Console.WriteLine("--("+intValue+")");
        }
        protected void TreePrint(BTNode node, int depth = 0, int orientation = 0)
        {
            if (node != null)
            {
                TreePrint(node.right, depth + 1, 1); // 1 entspricht rechts
                IndentPrint(node.IntValue, depth, orientation);
                TreePrint(node.left, depth + 1, -1);  // -1 entspricht links                             
            }
        }
        public void Print()
        {
            TreePrint(root);           
        }


        
        /* T1, T2 and T3 are subtrees of the tree rooted with y
         (on left side) or x (on right side) : 
        
                y                               x
               / \        Right Rotation       /  \
              x   T3      – – – – – – – >     T1   y
             / \          < - - - - - - -         / \
            T1  T2        Left Rotation         T2  T3 */

        // On The LeftSide(RightRotation): 

        //          Pivot  == x
        //          Parent == y 

        //On The RightSide(LeftRotation): 

        //          Pivot  == y 
        //          Parent == x
        public BTNode LeftRotation(BTNode parent)
        {
            BTNode pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        public BTNode RightRotation(BTNode parent)
        {
            BTNode pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }

    }
}
