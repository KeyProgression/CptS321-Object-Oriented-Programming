using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    public class OperatorNode : ExpressionTreeNode
    {
        public OperatorNode(char c)
        {
            Operator = c;
            Left = Right = null;
        }

        public override double Evaluate()
        {
            return 0.0;
        }

        public char Operator { get; set; }
        public int Precedence { set; get; }
        public int Associativity { set; get; }
        public ExpressionTreeNode? Left { get; set; }
        public ExpressionTreeNode? Right { get; set; }
    }
}
