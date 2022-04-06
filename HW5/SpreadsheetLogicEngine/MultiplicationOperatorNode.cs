namespace CptS321
{
    public class MultiplicationOperatorNode : OperatorNode
    {
        /// <summary>
        /// AdditionOperatorNode constructor.
        /// </summary>
        /// <param name="precedence"></param>
        public MultiplicationOperatorNode(ushort precedence)
        {
            Precedence = precedence;
            Left = null;
            Right = null;
        }

        /// <value>
        /// Addition operator.
        /// </value>
        public static new char Operator
        {
            get
            {
                return '*';
            }
        }

        /// <summary>
        /// Addition evaluation.
        /// </summary>
        /// <returns>The summation of the left and right subtrees</returns>
        public override double Evaluate()
        {
            return Left.Evaluate() * Right.Evaluate();
        }
    }
}