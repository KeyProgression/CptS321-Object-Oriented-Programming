namespace CptS321
{
    /// <summary>
    /// Variable node contains a dictionary named _variables where you should pass in the value of your outside dictionary for look up.
    /// </summary>
    public class VariableNode : OperatorNode
    {
        private string _name;

        private Dictionary<string, double> _variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="name">String name.</param>
        /// <param name="variables">Dictionary named variables.</param>
        public VariableNode(string name, ref Dictionary<string,double> variables)
        {
            _name = name;
            _variables = variables;
        }

        /// <summary>
        /// Setter and getter for _name.
        /// </summary>
        /// <value>
        /// It is a setter and getter for _name.
        /// </value>
        public string Name
        {
            get { return _name; } set { _name = value; }
        }

        /// <summary>
        /// Evaluates variable node.
        /// </summary>
        /// <returns>Returns value of a variable node.</returns>
        public override double Evaluate()
        {
            double returnValue = 0.0;

            if (_variables.ContainsKey(_name))
            {
                returnValue = _variables[_name];
            }

            return returnValue;
        }
    }
}
