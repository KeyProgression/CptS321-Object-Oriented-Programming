using System;
using System.IO;

	public class Node
    {
		public Node? Left { get; set; }
		public Node? Right { get; set; }

		public int Data { get; set; }
    }
	public class BST
	{
		public Node? Root { get;set; }

		// To add values to our tree
        public bool Add(int value)
        {
			Node? previous = null, next = this.Root;

			while(next != null) // checks that tree is not empty
            {
				previous = next;
				if (value < next.Data) { next= next.Left; }
				else if (value > next.Data) { next=next.Right; }
				else { return false; } // returns false if unable to add data to tree, most likely a duplicate value

            }

			Node? node = new();
			node.Data = value;

			//
			if (this.Root != null) // check that tree is not empty
            {
                if (value > previous.Data) { previous.Right = node; }
                else { previous.Left = node; }
            }
			else { this.Root = node; } // empty Tree

			return true;
        }

		// To get tree height/depth/level
		public int GetTreeHeight()
        {
			return this.GetTreeHeight(this.Root);
        }

		// override call to get actual height of tree
		private int GetTreeHeight(Node parent)
        {
			if (parent == null) { return 0; }
			else
			{
				return Math.Max(GetTreeHeight(parent.Left), GetTreeHeight(parent.Right)) + 1;
			}
        }

		// standard traverse in order method
		public void TraverseInOrder(Node parent)
        {
			if (parent != null)
            {
				TraverseInOrder(parent.Left);
				Console.Write(parent.Data+ " ");
				TraverseInOrder(parent.Right);
            }
        
		}

		// function to calculate left height
		public int LeftHeight(Node root)
        {
			int lht = 0;
			while (root != null)
			{
				lht++;
				root = root.Left;
			}
			return lht;
		}

		//Function to calculate right height
		public int RightHeight(Node root)
		{
			int rht = 0;
			while (root != null)
			{
				rht++;
				root = root.Right;
			}
			return rht;
		}

		// function to count the total items in the tree
		// Should be 2^h-1 to determine total items in tree
		public int Count(Node root)
        {
			int lht = 0, rht = 0;
			//gets both left and right height
			lht = LeftHeight(root);
			rht = RightHeight(root);

			// if they're equal multiply by 2 and -1
			if( lht == rht) { return (1 << rht - 1); }

			if ( root.Right == null && root.Left == null )
			{
				return 0;
			}
			else if (root.Right == null)
			{
				return 1 + Count(root.Left);
			}
			else if (root.Left == null)
			{
				return 1 + Count(root.Right);
			}

			// do recursive call if theyre not equal
			return 1 + Count(root.Left) + Count(root.Right);
        }

		// function to determine the theoretical minimum height
		public int MinimumHeight()
        {
			// If a tree has a height h, then min number of nodes is h+1 so if you have x nodes then minimum height is x-1
			int minNodes = 0;
			if (this.GetTreeHeight() - 1 == 0) { minNodes = 1; }
			else { minNodes = this.GetTreeHeight() - 1; }
			return minNodes;
        }

	}