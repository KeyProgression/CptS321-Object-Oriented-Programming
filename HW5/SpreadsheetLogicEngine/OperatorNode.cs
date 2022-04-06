namespace CptS321
{
    /// <summary>
    /// The OperatorNode which inherits the ExpressionTreeNode, using example as seen in class.
    /// </summary>
    public class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Setter and getter for Left subtree.
        /// </summary>
        /// <value>
        /// The left subtree.
        /// </value>
        public ExpressionTreeNode? Left { get; set; }

        /// <summary>
        /// Setter and getter for Right subtree.
        /// </summary>
        /// <value>
        /// The right subtree.
        /// </value>
        public ExpressionTreeNode? Right { get; set; }

        /// <summary>
        /// The setter and getter for the operator.
        /// </summary>
        /// <value>
        /// Will be the character on which the specified operation is executed.
        /// </value>
        public char Operator { get; set; }

        /// <summary>
        /// Setter and getter for operator precedence. Determines which operator executes first.
        /// </summary>
        /// <value>
        /// Contains the precedence on which operation should be executed first.
        /// </value>
        public ushort Precedence { get; set; }

        /// <summary>
        /// Inherited evaluate method.
        /// </summary>
        /// <returns> returns the value after calculation. </returns>
        /// <exception cref="NotImplementedException"> Hasn't been implemented.</exception>
        public override double Evaluate()
        {
            // throw new NotImplementedException();
            return 0.0;
        }
    }
}
