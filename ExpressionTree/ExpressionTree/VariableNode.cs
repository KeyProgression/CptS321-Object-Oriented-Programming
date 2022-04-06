using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeCodeDemo
{
    internal class VariableNode : ExpressionTreeNode
    {
        private string? name;

        private Dictionary<string, double> _variables = new ();
        public string? Name { get {return name; } set {name = value; } }

        public VariableNode(string _name, ref Dictionary<string,double> myDict )
        {
            name = _name;

           _variables = myDict;
        }

        public override double Evaluate()
        {
            double returnVal = 0.0;
            if (_variables.ContainsKey(key: name))
            {
                returnVal = _variables[name];
            }
            return returnVal;
        }
    }
}