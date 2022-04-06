using System;


class Program
{
    static void Main(string[] args)
    {
        // create BST which will hold user input
        BST BinSeaTree = new BST();

        // 1.
        Console.Write("Please input numbers seperated by a space:\n\t\t\t\t\t\t"); // ask for user input
        
        string userInput = Console.ReadLine(); // assumes all user input is correct
        
        string[] toBeAdded = userInput.Split(' ', StringSplitOptions.None); // splits the string based off of space
        

        // 2.
        // converts each string to an int then adds to tree
        foreach (string s in toBeAdded)
        {
            BinSeaTree.Add(Int16.Parse(s));
        }

        // 3.
        Console.Write("Our BST from least to greatest is:\n");
        BinSeaTree.TraverseInOrder(BinSeaTree.Root);
        Console.WriteLine();

        // 4.
        // BST.Count is bugged with unbalanced trees
        // FIXED
        Console.WriteLine("The number of nodes in the tree is: ");
        Console.WriteLine(BinSeaTree.Count(BinSeaTree.Root)); // displays total nodes/items in Tree

        Console.WriteLine("The height of our tree is: ");
        Console.WriteLine(BinSeaTree.GetTreeHeight()); // displays tree's current height

        Console.WriteLine("The minimum theoretical height of the tree is: ");
        Console.WriteLine(BinSeaTree.MinimumHeight()); // display's trees minimum height
    }
}