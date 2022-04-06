namespace CptS321
{
    /// <summary>
    /// Abstract node, should be inherited by all other node contains the Evaluate method which should be abstract and inherited by all other nodes.
    /// </summary>
    public abstract class ExpressionTreeNode
    {
        /// <summary>
        /// Holds the unique method for each operation. I.E. +, /, *, ^, %
        /// </summary>
        /// <returns>Returns evaluated operation.</returns>
        public abstract double Evaluate();
    }
}
