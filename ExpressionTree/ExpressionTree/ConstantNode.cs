using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    internal class ConstantNode : ExpressionTreeNode
    {
        public double Value { get; set; }

        public override double Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}


/*ExpressionTreeNode <<abstract>>
 ConstantNode   -- VariableNode     -- OperatorNode <<abstract>>
-Value          -- -name            -- -LeftSubtree
+Evaluate()     -- -variable        -- -RightSubtree
                -- +Evaluate()      -- -operator
                                    -- -precedence
                                    -- -associativity
AdditionOperatorNode        -- SubOperatorNode -^   Same for multiplication and subtraction
+Evaluate()                 -- +Evaluate()

 
 Hold a dictionary of variables for each expression. Just store the name and the key to the variable, to look up the value of the node. */