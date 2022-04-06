// CptS 321: Expression Tree Code Demo of how NOT to code your assignments
// Problems and solutions of this code will be discussed in class
// Note that if you sumbit this code you will not get ANY points for the assignments

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace ExpressionTreeCodeDemo
{
	public class Expression
    {
        private ExpressionTreeNode? _root;

        private Dictionary<string, double> _variables = new();

        private Stack<ExpressionTreeNode> _treeOutput = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTreeCodeDemo.Expression"/> class.
        /// </summary>
        public Expression(string expression)
		{
			_root = Compile(expression);
		}

        private List<string> CompileHelper(string expression)
        {
            Stack<string> stack = new();

            List<string> strlist = new();

            string name = string.Empty;

            string number = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsLetter(expression[i]))
                {
                    name += expression[i];
                    string temp = expression.Substring(i + 1);
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (char.IsDigit(temp[j]))
                        {
                            name += temp[j];
                            i++;
                        }

                        if (char.IsLetter(temp[j]) || temp[j] == '+' || temp[j] == '-' || temp[j] == '*' || temp[j] == '/')
                        {
                            break;
                        }
                    }

                    strlist.Add(name);
                    name = string.Empty;
                }
                else if (expression[i] != '+' && expression[i] != '-' && expression[i] != '*' && expression[i] != '/')
                {
                    if (expression[i] == '(')
                    {
                        stack.Push(expression[i].ToString());
                    }
                    else if (expression[i] == ')')
                    {
                        while (stack.Peek() != "(" && stack.Count != 0)
                        {
                            strlist.Add(stack.Pop());
                        }

                        stack.Pop();
                    }
                    else if (char.IsDigit(expression[i]))
                    {
                        if (i != expression.Length - 1)
                        {
                            number += expression[i];
                            if (char.IsDigit(expression[i + 1]))
                            {
                                number += expression[i + 1];
                                strlist.Add(number);
                                i++;
                                number = string.Empty;
                            }
                            else
                            {
                                strlist.Add(number);
                                number = string.Empty;
                            }
                        }
                        else
                        {
                            strlist.Add(expression[i].ToString());
                        }
                    }
                }
                else
                {
                    while (stack.Count != 0 && GetPrecedence(expression[i]) <= GetPrecedence(Convert.ToChar(stack.Peek())))
                    {
                        strlist.Add(stack.Pop());
                    }

                    stack.Push(expression[i].ToString());
                }
            }

            while (stack.Count != 0)
            {
                if (stack.Peek() != "(")
                {
                    strlist.Add(stack.Pop());
                }
            }

            return strlist;
        }

        private ExpressionTreeNode? Compile(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            List<string> expression = CompileHelper(s);
            for (int i = 0; i < expression.Count; i++)
            {
                if (expression[i] != "+" && expression[i] != "-" && expression[i] != "*" && expression[i] != "/")
                {
                    if (Regex.IsMatch(expression[i], @"^[+-]?\d*[.]?\d*$"))
                    {
                        _treeOutput.Push(new ConstantNode(Convert.ToDouble(expression[i])));
                    }
                    else
                    {
                        _treeOutput.Push(new VariableNode(expression[i], ref _variables));
                    }
                }
                else
                {
                    OperatorNodeFactory ps5 = new();
                    OperatorNode node = ps5.MakeOperatorNode(Convert.ToChar(expression[i]));
                    if (_treeOutput.Count != 0)
                    {
                        node.Right = _treeOutput.Pop();
                        node.Left = _treeOutput.Pop();
                    }

                    _treeOutput.Push(node);
                }
            }

            return _treeOutput.Pop();
        }

        /*
		private static Node Compile(string s)
		{
			if (string.IsNullOrEmpty(s))
            {
                return null;
            }

            // Check for extra parentheses and get rid of them, e.g. (((((2+3)-(4+5)))))
            if ('(' == s[0])
            {
                int parenthesisCounter = 1;
                for (int characterIndex = 1; characterIndex < s.Length; characterIndex++)
                {
                    // if open parenthisis increment a counter
                    if ('(' == s[characterIndex])
                    {
                        parenthesisCounter++;
                    }
                    // if closed parenthisis decrement the counter
                    else if (')' == s[characterIndex])
                    {
                        parenthesisCounter--;
                        // if the counter is 0 check where we are
                        if (0 == parenthesisCounter)
                        {
                            if (characterIndex != s.Length - 1)
                            {
                                // if we are not at the end, then get out (there are no extra parentheses)
                                break;
                            }
                            else
                            {
                                // Else get rid of the outer most parentheses and start over
                                return Compile(s.Substring(1, s.Length - 2));
                            }
                        }
                    }
                }
            }
            
            // define the operators we want to look for in that order
            char[] operators = { '+', '-', '*', '/', '^' };
            foreach (char op in operators)
            {
                Node n = Compile(s, op);
                if (n != null) return n;
            }

            // what can we see here?  
            double number;
            // a constant
            if (double.TryParse(s, out number))
            {
                // We need a ConstantNode
                return new ConstantNode()
                {
                    Value = number
                };
            }
            // or variable
            else
            {
                // We need a VariableNode
                return new VariableNode()
                {
                    Name = s
                };
            }
		}

        private static Node Compile(string expression, char op)
        {
            // track the parentheses
            int parenthesisCounter = 0;
            // iterate from back to front
            for (int expressionIndex = expression.Length - 1; expressionIndex >= 0; expressionIndex--)
            {
                // if closed parenthisis INcrement the counter
                if (')' == expression[expressionIndex])
                {
                    parenthesisCounter++;
                }
                // if open parenthisis DEcrement the counter
                else if ('(' == expression[expressionIndex])
                {
                    parenthesisCounter--;
                }
                // if the counter is at 0 and we have the operator that we are looking for
                if (0 == parenthesisCounter && op == expression[expressionIndex])
                {
                    // build an operator node
                    OperatorNode operatorNode = new OperatorNode(expression[expressionIndex]);
                    // and start over with the left and right sub-expressions
                    operatorNode.Left = Compile(expression.Substring(0, expressionIndex));
                    operatorNode.Right = Compile(expression.Substring(expressionIndex + 1));
                    return operatorNode;
                }
            }

            // if the counter is not at 0 something was off
            if (parenthesisCounter != 0)
            {
                // throw a general exception
                throw new Exception();
            }
            // we did not find the operator
            return null;
        }

		// Precondition: n is non-null
		internal double Evaluate(Node node)
		{
            // try to evaluate the node as a constant
            // the "as" operator is evaluated to null 
            // as opposed to throwing an exception
            ConstantNode constantNode = node as ConstantNode;
			if (null != constantNode)
			{
				return constantNode.Value;
			}
            
            // as a variable
            VariableNode variableNode = node as VariableNode;
			if (null != variableNode)
			{
				return variables[variableNode.Name];
			}

			// it is an operator node if we came here
			OperatorNode operatorNode = node as OperatorNode;
			if (null != operatorNode)
			{
                // but which one?
				switch (operatorNode.Operator)
				{
				case '+':
					return Evaluate(operatorNode.Left) + Evaluate(operatorNode.Right);
                case '-':
                    return Evaluate(operatorNode.Left) - Evaluate(operatorNode.Right);
                case '*':
                    return Evaluate(operatorNode.Left) * Evaluate(operatorNode.Right);
                case '/':
                    return Evaluate(operatorNode.Left) / Evaluate(operatorNode.Right);
                case '^':
                    return Math.Pow(Evaluate(operatorNode.Left), Evaluate(operatorNode.Right));
				default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + operatorNode.Operator.ToString() + " not supported.");
				}
			}

			throw new NotSupportedException();
		}
        */
            
        public double Evaluate()
        {
            return _root.Evaluate();
        }

        public void SetVariable(string name, double value)
        {
            _variables[name] = value;
        }

        public double GetPrecedence(char c)
        {
            if (c == '+' || c == '-')
            {
                return 1;
            }
            else if (c == '*' || c == '/')
            {
                return 2;
            }
            // double result = 0;
            throw new NotImplementedException();
        }

    }
}