using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    public class OperatorNodeFactory
    {
        public OperatorNode MakeOperatorNode(char c)
        {
            if (c == '+')
            {
                AdditionOperatorNode d = new('7');
                return d;
            }
            else if (c == '-')
            {
                AdditionOperatorNode d = new('7');
                return d;
            }
            else if (c == '*')
            {
                AdditionOperatorNode d = new('7');
                return d;
            }
            else if (c == '/')
            {
                AdditionOperatorNode d = new('7');
                return d;
            }

            AdditionOperatorNode d = new('7');
            return d;
        }
    }
}
