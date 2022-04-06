namespace CptS321
{
    /// <summary>
    /// Factory design pattern for operator node.
    /// </summary>
    public class OperatorNodeFactory
    {
        /// <summary>
        /// Factory method for operator node.
        /// </summary>
        /// <param name="ins">Creates an operator node based on based ins parameter</param>
        /// <returns>Returns a new operator node</returns>
        public OperatorNode MakeOperatorNode(char ins)
        {
            if (ins == '+')
            {
                return new AdditionOperatorNode(1);
            }
            else if (ins == '/')
            {
                return new DivisionOperatorNode(2);
            }
            else if (ins == '-')
            {
                return new SubtractionOperatorNode(1);
            }
            else if (ins == '*')
            {
                return new MultiplicationOperatorNode(2);
            }

            return new AdditionOperatorNode(1);
        }
    }
}