namespace CptS321
{
    /// <summary>
    /// Constant node with a constructor for the node constant to set the value of your constants.
    /// </summary>
    public class ConstantNode : ExpressionTreeNode
    {
        private double _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value"> Value of cons node.</param>
        public ConstantNode(double value)
        {
            _value = value;
        }

        /// <summary>
        /// Setter and getter for _value.
        /// </summary>
        /// <value>
        /// It is the setter and getter for _value.
        /// </value>
        public double Value
        {
            get { return _value; } set { _value = value; }
        }

        /// <summary>
        /// Constant Node evaluation method.
        /// </summary>
        /// <returns>The constant value of a node.</returns>
        public override double Evaluate()
        {
            return _value;
        }
    }
}
