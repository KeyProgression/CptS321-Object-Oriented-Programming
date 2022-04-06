namespace CptS321
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// ExpressionTree on which most of this assignment is graded.
    /// </summary>
    public class ExpressionTree
    {
        private ExpressionTreeNode? _root = null;

        private OperatorNodeFactory _operatorNodeFactory = new OperatorNodeFactory();

        private Dictionary<string, double> _variables = new ();

        private Stack<ExpressionTreeNode> _treeOutput = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
    /// </summary>
    /// <param name="expression">A string.</param>
        public ExpressionTree(string expression)
        {
            _root = Compile(expression);
        }

        /// <summary>
        /// Sets the value of a key in a dictionary.
        /// </summary>
        /// <param name="variableName">Dictionary Key</param>
        /// <param name="variableValue">Dictionary Value</param>
        public void SetVariable(string variableName, double variableValue) => _variables[variableName] = variableValue;

        /// <summary>
        /// Returns the value of the entire tree.
        /// </summary>
        /// <returns> This returns the value of the entire tree.</returns>
        public double Evaluate()
        {
            return _root.Evaluate();
        }

        private List<string> CompileHelper(string expression)
        {
            Stack<string> stack = new ();

            List<string> strlist = new ();

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

        private ExpressionTreeNode Compile(string s)
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
                    OperatorNode node = _operatorNodeFactory.MakeOperatorNode(Convert.ToChar(expression[i]));
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

        /// <summary>
        /// Get opeartor precedence.
        /// </summary>
        /// <param name="operatorCheck"></param>
        /// <returns>Returns the precedence of operator.</returns>
        private int GetPrecedence(char operatorCheck)
        {
            if (operatorCheck == '+' || operatorCheck == '-')
            {
                return 1;
            }
            else if (operatorCheck == '*' || operatorCheck == '/')
            {
                return 2;
            }
            else
            {
                return -1;
            }
        }
    }
}