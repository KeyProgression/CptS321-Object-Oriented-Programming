// <copyright file="FindDistinct.cs" company="WSU-Dr. Venera Arnaoudova">
// Copyright (c) WSU-Dr. Venera Arnaoudova. All rights reserved.
// </copyright>
// <author>Matthew Yien</author>
// <studentid>11698797</studentid>

namespace HW2
{
    using System;

    /// <summary>
    /// Class where all algorithms to find distinct values from a list reside.
    /// </summary>
    public class FindDistinct
    {
        /// <summary>
        /// The List we'll be using for all our methods.
        /// </summary>
        private List<int> randomList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindDistinct"/> class.
        /// </summary>
        public FindDistinct()
        {
            this.randomList = new List<int>(10000);

            this.SetList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FindDistinct"/> class, with overloaded parameters.
        /// </summary>
        /// <param name="setList">List.<int> type</int></param>
        public FindDistinct(List<int> setList)
        {
            this.randomList = setList;
        }

        /// <summary>
        /// Gets read Only Random List.
        /// </summary>
        public List<int> GetsRandomList
        {
            get { return this.randomList; }
        }

        /// <summary>
        /// Goes through the entire list once in a for loop, which takes O(n) time, for every element in the list it checks if the key-value pair already exists this takes O(1). The overall time of this method should be O(n) due to having to loop through the input list once.
        /// </summary>
        /// <returns> Returns the count of the hash set for all the distinct values of randomList. </returns>
        public int DistinctHashMethod()
        {
            // Takes advantage of the key-value look up times to create a set of unique values
            HashSet<int> distinctValues = new HashSet<int>(10000);

            // input is n = 100000
            foreach (int insert in this.randomList)
            {
                distinctValues.Add(insert);
            }

            return distinctValues.Count;
        }

        /// <summary>
        /// Uses 2 for loops to compare each value against every other value in the list, worst case time complexity is O(n^2) because of nested loops.
        /// </summary>
        /// <returns> Returns an integer value containing the number of unique values in the set.</returns>
        public int StaticListMethod()
        {
            // The number of unique values in a list
            int uniqueCount = 0;

            for (int index = 0; index < 10000; index++)
            {
                int internalIndex = 0;
                for (internalIndex = 0; internalIndex < 10000; internalIndex++)
                {
                    if (this.randomList[index] == this.randomList[internalIndex])
                    {
                        break;
                    }
                }

                if (index == internalIndex)
                {
                    uniqueCount++;
                }
            }

            return uniqueCount;
        }

        /// <summary>
        /// Sorting an array takes nlogn time, the counting of all items should be O(n) after being sorted you only need to go through the list once to count all unique values.
        /// </summary>
        /// <returns>The count of all distinct values in the list.</returns>
        public int SortedListMethod()
        {
            // the return value containing total number of sets changed
            int uniqueCount = 0;

            this.randomList.Sort();

            for (int index = this.randomList.Count - 1; index > 0; index--)
            {
                if (this.randomList[index] == this.randomList[index - 1])
                {
                    // if the values are the same do nothing, else count the value
                }
                else
                {
                    uniqueCount++;
                }
            }

            return uniqueCount + 1;
        }

        /// <summary>
        /// Runs all tests and inserts the ran values into a string before returning.
        /// </summary>
        /// <returns>Returns the results of all tests as a string.</returns>
        public string Results()
        {
            return "1. Hash Set method: " + this.DistinctHashMethod() + " unique numbers" + Environment.NewLine + "\tTime Complexity: O(n)" + Environment.NewLine + "\tExplanation: it was determined by the number of loops used here, only 1 loop was required to add to a hash set and lookup time is constant for using a hashset. So input of unique values doesn't take up additional time." + Environment.NewLine + "2 .O(1) storage method: " + this.StaticListMethod() + " unique numbers" + Environment.NewLine + "\tTime Complexity: O(n^2)" + Environment.NewLine + "\tExplanation: This was determined again by the amount of loops needed to perform this task, which was 2 for loops, one of those being nested." + Environment.NewLine + "3. Sorted method: " + this.SortedListMethod() + " unique numbers" + Environment.NewLine + "\tTime Complexity: O(n)" + Environment.NewLine + "\tExplanation: Sorting an array takes nlogn time, the actual counting of unique values takes O(n) time, because all values are sorted you only need to compare to the next one rather than having to compare to all values in the list.\n";
        }

        /// <summary>
        /// Method to create a random list of 10,000 integers ranging from 1 to 20,000.
        /// </summary>
        private void SetList()
        {
            var rand = new Random();

            for (int index = 0; index < 10000; index++)
            {
                this.randomList.Add(rand.Next(1, 20001));
            }
        }
    }
}
