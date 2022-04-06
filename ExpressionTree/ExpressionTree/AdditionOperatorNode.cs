using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    public class AdditionOperatorNode : OperatorNode
    {
        public AdditionOperatorNode(char c) : base(c)
        {
        }

        public new static char Operator => '+';
        public new static ushort Precedence => 7;
        //public static Associative Associativity => Associative.Left;


        public override double Evaluate()
        {
            if (Left == null)
            {
                return Right.Evaluate();
            }

            else if (Right == null)
            {
                return Left.Evaluate();
            }
            else
            {
                return Left.Evaluate() + Right.Evaluate();
            }
        }
    }
}
