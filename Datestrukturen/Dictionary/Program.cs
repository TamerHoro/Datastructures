using System;

namespace Dictionary
{
    /// <summary>
    /// Vielleicht ein Loop bei dem man die eingabe Delete etc übergibt und jenachdem Looped auser Print 
    /// heißt man kann dann Delete zu mini Funktionen beschränken 
    /// 
    /// 
    /// Dict name in den einzelnen Klassen merken 
    /// </summary>
    public enum DictonaryType
    {
        MultiSetSortedLinkedList,
        MultiSetUnsortedLinkedList,
        SetSortedLinkedList,
        SetUnsortedLinkedList,
        MultiSetSortedArray,
        MultiSetUnsortedArray,
        SetSortedArray,
        SetUnsortedArray,
        BinarySearchTree,
        AVLTree,
        Treap,
        HashTabQuadProb,
        HashTabSepChain,
        NotImplemented
    }

    class Program
    {
        public static string DictName;
        public static int arrayLength = 10;

        static void Main(string[] args)
        {
            Menu();
        }
        public static void TestFunc1(IDictionary test)
        {
            for (int i = 0; i < 15; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(1, 100);
                test.Insert(r);
                //test.Print();
            }



        }
        //---------------------------------------------
        // Diffrent style of Write and navigate  To the Dictonarys 
        //------------------------------- 
        private static void Menu()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Dictonary - Menu \n \n" + "Select your abstract Dictonary: \n"
                    + "\t<1> \t Multi Set Sorted \n"
                                + "\t<2> \t Multi Set Unsorted\n"
                                + "\t<3> \t Set Sorted\n"
                                + "\t<4> \t Set Unsorted\n"
                                + "\t<5> \t Exit\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "5")
                {
                    break;
                }
                switch (input)
                {
                    case ("1"):
                        {
                            MultiSetSortedMenu();
                            break;
                        }
                    case ("2"):
                        {
                            MultiSetUnsortedMenu();
                            break;
                        }
                    case ("3"):
                        {
                            SetSortedMenu();
                            break;
                        }
                    case ("4"):
                        {
                            SetUnsortedMenu();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
            }
        }
        //---------------------------------------------
        // Multi Set Sorted Typs 
        //---------------------------------------------
        private static void MultiSetSortedMenu()
        {
            string input;
            
            while (true)
            {
                DictonaryType dictonaryType = DictonaryType.NotImplemented;
                Console.WriteLine("Multi Set Sorted Dictonary - Menu \n \n" + "Select your Dictonary: \n"
                     + "\t<1> \t Multi Set Sorted Array \n"
                                + "\t<2> \t Multi Set Sorted Linked List\n \n "
                                + "\t<3> \t Go Back\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "3")
                {
                    break; 
                }
                switch (input)
                {
                    case ("1"):
                        {
                            DictName = "Multi Set Sorted Array";
                            dictonaryType = DictonaryType.MultiSetSortedArray;
                            break;
                        }
                    case ("2"):
                        {
                            DictName = "Multi Set Sorted Linked List";
                            dictonaryType = DictonaryType.MultiSetSortedLinkedList;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
                if(dictonaryType != DictonaryType.NotImplemented)
                {
                    IDictionary dictionary = CreatDictonary(dictonaryType);
                    MethodMenu(dictionary);
                }
            }
        }
        //---------------------------------------------
        // Multi Set Sorted Typs 
        //---------------------------------------------
        private static void MultiSetUnsortedMenu()
        {
            string input;

            while (true)
            {
                DictonaryType dictonaryType = DictonaryType.NotImplemented;
                Console.WriteLine("Multi Set Unsorted Dictonary - Menu \n \n" + "Select your Dictonary: \n"
                                + "\t<1> \t Multi Set Unsorted Array \n"
                                + "\t<2> \t Multi Set Unsorted Linked List\n"
                                + "\t<3> \t Go Back\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "3")
                {
                    break;
                }
                switch (input)
                {
                    case ("1"):
                        {
                            DictName = "Multi Set Unsorted Array";
                            dictonaryType = DictonaryType.MultiSetUnsortedArray;
                            break;
                        }
                    case ("2"):
                        {
                            DictName = "Multi Set Unsorted Linked List";
                            dictonaryType = DictonaryType.MultiSetUnsortedLinkedList;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
                if (dictonaryType != DictonaryType.NotImplemented)
                {
                    IDictionary dictionary = CreatDictonary(dictonaryType);
                    MethodMenu(dictionary);
                }
            }
        }
        //---------------------------------------------
        // Multi Set Sorted Typs 
        //---------------------------------------------
        private static void SetUnsortedMenu()
        {
            string input;

            while (true)
            {
                DictonaryType dictonaryType = DictonaryType.NotImplemented;
                Console.WriteLine("Set Unsorted Dictonary - Menu \n \n" + "Select your Dictonary: \n"
                     + "\t<1> \t Set Unsorted Array \n"
                                + "\t<2> \t Set Unsorted Linked List\n"
                                + "\t<3> \t Hash Tab Sep Chain\n"
                                + "\t<4> \t Hash Tab Quad Prob\n"
                                + "\t<5> \t Go Back\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "5")
                {
                    break;
                }
                switch (input)
                {
                    case ("1"):
                        {
                            DictName = "Set Unsorted Array";
                            dictonaryType = DictonaryType.SetUnsortedArray;
                            break;
                        }
                    case ("2"):
                        {
                            DictName = "Set Unsorted Linked List";
                            dictonaryType = DictonaryType.SetUnsortedLinkedList;
                            break;
                        }
                    case ("3"):
                        {
                            DictName = "Hash Tab Sep Chain";
                            dictonaryType = DictonaryType.HashTabSepChain;
                            break;
                        }
                    case ("4"):
                        {
                            DictName = "Hash Tab Quad Prob";
                            dictonaryType = DictonaryType.HashTabQuadProb;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
                if (dictonaryType != DictonaryType.NotImplemented)
                {
                    IDictionary dictionary = CreatDictonary(dictonaryType);
                    MethodMenu(dictionary);
                }
            }
        }
        //---------------------------------------------
        //Set Sorted Typs 
        //---------------------------------------------
        private static void SetSortedMenu()
        {
            string input;

            while (true)
            {
                DictonaryType dictonaryType = DictonaryType.NotImplemented;
                Console.WriteLine("Set Sorted Dictonary - Menu \n \n" + "Select your Dictonary: \n"
                     + "\t<1> \t Binary Search Tree \n"
                                + "\t<2> \t AVL Tree\n"
                                + "\t<3> \t Treap\n"
                                + "\t<4> \t Set Sorted Array\n"
                                + "\t<5> \t Set Sorted Linked List\n"                               
                                + "\t<6> \t Go Back\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "6")
                {
                    break;
                }
                switch (input)
                {
                    case ("1"):
                        {
                            DictName = "Binary Search Tree";
                            dictonaryType = DictonaryType.BinarySearchTree;
                            break;
                        }
                    case ("2"):
                        {
                            DictName = "AVL Tree";
                            dictonaryType = DictonaryType.AVLTree;
                            break;
                        }
                    case ("3"):
                        {
                            DictName = "Treap";
                            dictonaryType = DictonaryType.Treap;
                            break;
                        }
                    case ("4"):
                        {
                            DictName = "Set Sorted Array";
                            dictonaryType = DictonaryType.SetSortedArray;
                            break;
                        }
                    case ("5"):
                        {
                            DictName = "Set Sorted Linked List";
                            dictonaryType = DictonaryType.SetSortedLinkedList;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
                if (dictonaryType != DictonaryType.NotImplemented)
                {
                    IDictionary dictionary = CreatDictonary(dictonaryType);
                    MethodMenu(dictionary);
                }
            }
        }
        //---------------------------------------------
        // Diffrent style of Write and navigate  To the Dictonarys 
        //------------------------------- 
        private static void Menu1()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Dictonary - Menu \n \n" + "Select your Dictonary: \n"
                                + "    Lists: \n"
                                + "\t<1> \t Multi Set Sorted Linked List \n"
                                + "\t<2> \t Multi Set Unsorted Linked List \n"
                                + "\t<3> \t Set Sorted Linked List\n"
                                + "\t<4> \t Set Unsorted Linked List\n"
                                + "    Array: \n"
                                + "\t<5> \t Multi Set Sorted  Array \n"
                                + "\t<6> \t Multi Set Unsorted  Array \n"
                                + "\t<7> \t Set Sorted Array \n"
                                + "\t<8> \t Set Unsorted Array \n"
                                + "    Tree: \n"
                                + "\t<9> \t Binary Tree  \n"
                                + "\t<10> \t AVL Tree  \n"
                                + "\t<11> \t Treap  \n"
                                + "    Hash: \n"
                                + "\t<12> \t Hash Tab Quad Prob  \n"
                                + "\t<13> \t Hash Tab Sep Chain \n"
                                + "    Exit: \n"
                                + "\t<14> \t Exit\n");
                //NewCommand();
                Console.WriteLine("Enter Dictonary number to select Type: ");
                input = Console.ReadLine();
                NewCommand();
                if (input == "14")
                {
                    break;
                }
                if (IsDictonaryInput(input))
                {
                    IDictionary dictionary = CreatDictonary(GetDictonaryType(input));
                    MethodMenu(dictionary);
                }
            }
        }

        public static bool IsDictonaryInput(string input)
        {
            bool isDictonary = false;
            if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" ||
                input == "9" || input == "10" || input == "11" || input == "12" || input == "13")
            {
                isDictonary = true;
            }
            return isDictonary;
        }
        public static DictonaryType GetDictonaryType(string input)
        {
            DictonaryType dictonaryType = DictonaryType.MultiSetSortedArray;

            switch (input)
            {
                case ("1"):
                    {
                        dictonaryType = DictonaryType.MultiSetSortedLinkedList;
                        break;
                    }
                case ("2"):
                    {
                        dictonaryType = DictonaryType.MultiSetUnsortedLinkedList;
                        break;
                    }
                case ("3"):
                    {
                        dictonaryType = DictonaryType.SetSortedLinkedList;
                        break;
                    }
                case ("4"):
                    {
                        dictonaryType = DictonaryType.SetUnsortedLinkedList;
                        break;
                    }
                case ("5"):
                    {
                        dictonaryType = DictonaryType.MultiSetSortedArray;
                        DictName = "Multi Set Sorted Array";
                        break; }
                case ("6"):
                    {
                        dictonaryType = DictonaryType.MultiSetUnsortedArray;
                        DictName = "Multi Set Unsorted Array";
                        break; }
                case ("7"):
                    {
                        dictonaryType = DictonaryType.SetSortedArray;
                        DictName = "Set Sorted Array";
                        break; }
                case ("8"):
                    {
                        dictonaryType = DictonaryType.SetUnsortedArray;
                        DictName = "Set Unsorted Array";
                        break; }
                case ("9"):
                    {
                        dictonaryType = DictonaryType.BinarySearchTree;
                        break;
                    }
                case ("10"):
                    {
                        dictonaryType = DictonaryType.AVLTree;
                        break;
                    }
                case ("11"):
                    {
                        dictonaryType = DictonaryType.Treap;
                        break;
                    }

                case ("12"):
                    {
                        dictonaryType = DictonaryType.HashTabQuadProb;
                        break;
                    }
                case ("13"):
                    {
                        dictonaryType = DictonaryType.HashTabSepChain;
                        break;
                    }
                default:
                    { 
                        break;
                    }
            }
            return dictonaryType;
        }


        // ---------------------------------------------------------
        // Selection Create as Dictonary for Numbers instead of a Word
        // ---------------------------------------------------------
        public static IDictionary CreatDictonary(DictonaryType dictonaryType)
        {
            IDictionary dictonary = null;
            switch (dictonaryType)
            {
                case (DictonaryType.MultiSetSortedLinkedList):
                    {
                        dictonary = new MultiSetSortedLinkedList();
                        DictName = "Multi Set Sorted Linked List";
                        break;
                    }
                case (DictonaryType.MultiSetUnsortedLinkedList):
                    {
                        dictonary = new MultiSetUnsortedLinkedList();
                        DictName = "Multi Set Unsorted Linked List";
                        break;
                    }
                case (DictonaryType.SetSortedLinkedList):
                    {
                        dictonary = new SetSortedLinkedList();
                        DictName = "Set Sorted Linked List";
                        break;
                    }
                case (DictonaryType.SetUnsortedLinkedList):
                    {
                        dictonary = new SetUnsortedLinkedList();
                        DictName = "Set Unsorted Linked List";
                        break;
                    }
               case (DictonaryType.MultiSetSortedArray):
                    {
                        dictonary = new MultiSetSortedArray(arrayLength);
                        DictName = "Multi Set Sorted Array";
                        break; }
                case (DictonaryType.MultiSetUnsortedArray):
                    {
                        dictonary = new MultiSetUnsortedArray(arrayLength);
                        DictName = "Multi Set Unsorted Array";
                        break; }
                case (DictonaryType.SetSortedArray):
                    {
                        dictonary = new SetSortedArray(arrayLength);
                        DictName = "Set Sorted Array";
                        break; }
                case (DictonaryType.SetUnsortedArray):
                    {
                        dictonary = new SetUnsortedArray(arrayLength);
                        DictName = "Set Unsorted Array";
                        break; }
                case (DictonaryType.BinarySearchTree):
                    {
                        dictonary = new BinSearchTree();
                        DictName = "Binary Search Tree";
                        break;
                    }
                case (DictonaryType.AVLTree):
                    {
                        dictonary = new AVLTree();
                        DictName = "AVL Tree";
                        break;
                    }
                case (DictonaryType.Treap):
                    {
                        dictonary = new Treap();
                        DictName = "Treap";
                        break;
                    }

                case (DictonaryType.HashTabQuadProb):
                    {
                        dictonary = new HashTabQuadProb();
                        DictName = "Hash Tab Quad Prob";
                        break;
                    }
                case (DictonaryType.HashTabSepChain):
                    {
                        dictonary = new HashTabSepChain();
                        DictName = "Hash Tab Sep Chain";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return dictonary;


        }
        public static void NewCommand()
        {
            Console.WriteLine("\n--------------------------------------------------");
        }
        //---------------------------------------------
        // Diffrent style of Write and navigate  To the Methods 
        //------------------------------- 
        public static void MethodMenu(IDictionary dictionary)
        {
            string input;
            while (true)
            {
                Console.WriteLine($"{DictName}: \n \n"
                    + "Choose a Method:\n"
                    + " \t<1> \t Insert a Number\n"
                    + "\t<2> \t Delete a Number \n"
                    + $"\t<3> \t Search if a Number is in the {DictName}\n"
                    + $"\t<4> \t Print the {DictName}\n"
                    + "\t<5> \t Go back and Choose another Dictonary\n");
                //NewCommand();
                Console.WriteLine( "Enter a Method Number : ");
                input = Console.ReadLine();
                NewCommand();
                switch (input)
                {
                    //Insert
                    case ("1"):
                        {
                            DoInsert(dictionary);
                            break;
                        }
                    //Delete
                    case ("2"):
                        {
                            DoDelete(dictionary);
                            break;
                        }
                    //Search
                    case ("3"):
                        {
                            DoSearch(dictionary);
                            break;
                        }
                    //Print
                    case ("4"):
                        {
                            
                            Console.WriteLine($"{DictName}: \n");
                            dictionary.Print();
                            Console.WriteLine();
                            break;
                        }
                    //Return
                    case ("5"):
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("!!! ERROR !!! \n Input is not Valid");
                            break;
                        }
                }
                NewCommand();
            }
        }
       
        
        public static void DoInsert(IDictionary dictionary)
        {
            string[] inputs;
            Console.WriteLine($"{DictName} : \n \n" + $"Insert Numbers separated with " +
                "a Blank if your finished press Enter: ");
            inputs = Console.ReadLine().Split(' ');
            foreach (string s in inputs)
            {
                int elem;
                if (!int.TryParse(s, out elem))
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) wont be inserted");
                    continue;
                }
                else if (elem < 0)
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) cant be inserted");
                    continue;
                }
                dictionary.Insert(elem);
                //if(!dictionary.Insert(elem))
                //{
                //    Console.WriteLine($"\nWARNING: ( {elem} ) do exist already");
                //}
            }

        }
        public static void DoDelete(IDictionary dictionary)
        {
            string[] inputs;
            Console.WriteLine($"{DictName} : \n \n" + $"Delete Numbers separated with " +
                "a Blank if your finished press Enter: ");
            inputs = Console.ReadLine().Split(' ');
            foreach (string s in inputs)
            {
                int elem;
                if (!int.TryParse(s, out elem))
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) cant be deleted");
                    continue;
                }
                else if(elem < 0)
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) cant be deleted");
                    continue;
                }
                dictionary.Delete((int)elem);
                //if (!dictionary.Delete(elem))
                //{
                //    Console.WriteLine($"\nWARNING: ( {elem} ) was not found");
                //}

            }

        }
        public static void DoSearch(IDictionary dictionary)
        {
            string[] inputs;
            Console.WriteLine($"{DictName} : \n \n" + $"Search Numbers separated with " +
                "a Blank if your finished press Enter: ");
            inputs = Console.ReadLine().Split(' ');
            NewCommand();
            foreach (string s in inputs)
            {
                int elem;
                if (!int.TryParse(s, out elem))
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) wont be searched");
                    continue;
                }
                else if (elem < 0)
                {
                    Console.WriteLine($"\nERROR: Invalid value ( {s} ) cant be deleted");
                    continue;
                }

                if (dictionary.Search(elem))
                {
                    Console.WriteLine($"\nFound : {elem} is element of {DictName}");
                }
                else
                {
                    Console.WriteLine($"\nNot Found: {elem} is not element of {DictName}");
                }
            }
        }

        public static void TestDelFunc1(IDictionary test)
        {
            for (int i = 0; i < 25; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(1, 100);
                Console.WriteLine("Deleting " + r);
                test.Delete(r);
                //test.Print();
            }

        }
        public static void TestFunc2(IDictionary test)
        {
            test.Insert(3);
            test.Insert(3);
            test.Insert(7);
            test.Insert(7);
            test.Insert(9);
            test.Insert(9);



        }
    }
}





