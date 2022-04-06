// <copyright file="FibonacciTextReader.cs" company="Washington State University">
// Copyright (c) Washington State University. All rights reserved.
// </copyright>
/*
 * Author: Matthew Yien
 * Student ID: 11698797
 */
namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Contains a Fibonacci Sequence, parameters determine how many lines of the sequence you load.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private readonly int lines;

        private int currentLine;

        private System.Numerics.BigInteger[] fibSequence;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Loads the first 10 lines of the Fibonacci sequence by default.
        /// </summary>
        /*
        private FibonacciTextReader()
        {
            this.lines = 10;
            this.currentLine = 0;


            this.fibSequence[0] = new (0);

            this.fibSequence[1] = new (1);

            // Generates Fibonacci series based upon the lines variable.
            for (int index = 2; index <= this.lines; index++)
            {
                this.fibSequence[index] = new ((ulong)this.fibSequence[index - 1] + (ulong)this.fibSequence[index - 2]);
            }
        }
        */

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="linesToLoad">Creates a Fibonacci series up to this integer.</param>
        public FibonacciTextReader(int linesToLoad)
        {
            this.lines = linesToLoad - 1;
            this.currentLine = 0;

            this.fibSequence = new System.Numerics.BigInteger[this.lines + 1];

            this.fibSequence[0] = new (0UL);

            this.fibSequence[1] = new (1UL);

            // Generates Fibonacci series based upon the lines variable.
            for (int index = 2; index <= this.lines; index++)
            {
                this.fibSequence[index] = new ((ulong)this.fibSequence[index - 1] + (ulong)this.fibSequence[index - 2]);
            }
        }

        /// <summary>
        /// Gets the number of fibonacci lines to load.
        /// </summary>
        public int Lines
        {
            get { return this.lines; }
        }

        public System.Numerics.BigInteger[] FibSequence { get { return this.fibSequence; } }

        /// <summary>
        /// Gets or sets the current position in the array of big integers fibSequence.
        /// </summary>
        public int CurrentLine
        {
            get { return this.currentLine; }
            set { this.currentLine = value; }
        }

        /// <summary>
        /// Reads a line of characters from FibonacciTextReader and returns the data as a string.
        /// </summary>
        /// <returns> The next line from the reader, or null if all characters have been returned.</returns>
        public override string? ReadLine()
        {
            // capture current number to be printed before next advancing to the next fib sequence
            string stringFib = this.fibSequence[this.currentLine].ToString();

            if (this.CurrentLine == this.Lines)
            {
                return null;
            }

            // Advance current line to print the next number in the series.
            this.CurrentLine++;

            return stringFib;
        }
    }
}
