using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class AVLTree : BinSearchTree , ISetSorted
    {
        //new protected AVLNode root;
        public AVLTree() : base() { }

        public int BalanceFactor(BTNode node) //left negativ, right positiv
        {
            int l = GetDepth(node.left);
            int r = GetDepth(node.right);            
            return r - l;
        }
        public int GetDepth(BTNode node)
        {
            int height = 0;
            if (node != null)
            {
                int l = GetDepth(node.left);
                int r = GetDepth(node.right);                
                height = Math.Max(l, r) + 1;
            }
            return height;
        }
        public new bool Insert(int intValue)
        {
            if (root == null) //Tree empty?
            {
                root = new BTNode(intValue);
                return true;
            }
            else
            {
                root = RecursiveInsert(intValue, root);
                return root != null; //!= in case insert fails

            }
        }

        protected new BTNode RecursiveInsert(int intValue, BTNode node)
        {
            if (intValue == node.IntValue)
            {
                Console.WriteLine("ERROR: Node (" + intValue + ") already exists");
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
                {
                    node.left = RecursiveInsert(intValue, node.left);
                    node = BalanceTree(node);

                }
            }
            else // IntValue bigger than node. IntValue --> Insert right
            {
                if (node.right == null)
                {
                    node.right = new BTNode(intValue);                    
                    return node;
                }
                else
                {
                    node.right = RecursiveInsert(intValue, node.right);
                    node = BalanceTree(node);
                }
            }
            return node;
        }
        public new bool Delete(int IntValue)
        {
            BTNode temp = RecursiveDelete(IntValue, root);
            root = temp;
            return true;
        }

        protected new BTNode RecursiveDelete(int IntValue, BTNode node)
        {
            if (node == null)
            {
                return null;
            }
            else if (IntValue < node.IntValue)
            {
                node.left = RecursiveDelete(IntValue, node.left);
                node = BalanceTree(node);
            }            
            else if (IntValue > node.IntValue)
            {
                node.right = RecursiveDelete(IntValue, node.right);
                node = BalanceTree(node);
            }
            //node = Search(IntValue, node);
            else
            {
                //else                                          //Zu loeschender Knoten gefunden 
                //{
                if (node.left != null && node.right != null)    //Es gibt sowohl links als auch rechts
                {
                    node.IntValue = FindMax(node.left);
                    node.left = RecursiveDelete(node.IntValue, node.left);
                    node = BalanceTree(node);
                }
                else if (node.left != null) //Es gibt keinen rechten
                {
                    node = node.left;
                    //node = BalanceTree(node);
                }
                else//Es gibt keinen linken
                {
                    node = node.right;
                    //node = BalanceTree(node);
                }
            }
            //}
            return node;
        }
        protected BTNode BalanceTree(BTNode node)
        {
            int bf = BalanceFactor(node);
            if(bf > 1)        //Subtree imbalanced right 
            {
                if (BalanceFactor(node.right) > 0) //rightright
                {
                    return LeftRotation(node);
                }
                else
                {
                    BTNode pivot = node.right;
                    node.right = RightRotation(pivot);
                    return LeftRotation(node);
                }
            }
            if(bf < -1) //Subtree imbalanced left
            {
                if (BalanceFactor(node.left) < 0) //leftleft
                {
                    return RightRotation(node);
                }
                else
                {
                    BTNode pivot = node.left;
                    node.left = LeftRotation(pivot);
                    return RightRotation(node);
                }
            }
            return node;
        }
    }
}
