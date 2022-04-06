/*
 Author: Matthew Yien
        11698797
 */
namespace CptS321
{
    /// <summary>
    /// Test program to run a menu where tests can be run.
    /// </summary>
    class Program
    {
        private static ExpressionTree tree = new ExpressionTree("0");

        /// <summary>
        /// Does menu and operates on tree.
        /// </summary>
        /// <param name="expression"> The expression to be passed into our Tree.</param>
        /// <returns> The while loop condition is returned.</returns>
        public static bool DoMenu(ref string expression)
        {
            string variable;
            double value = 0.0;

            string ourExpression = string.Format("\rMenu -- Current Expression \"{0}\"", expression);

            Console.Clear();
            Console.WriteLine(ourExpression);
            Console.WriteLine("1. Enter New Expression");
            Console.WriteLine("2. Set a variable value");
            Console.WriteLine("3. Evaluate Tree");
            Console.WriteLine("4. Quit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please type new expression: ");
#pragma warning disable CS8601 // Possible null reference assignment.
                    expression = Console.ReadLine();
#pragma warning restore CS8601 // Possible null reference assignment.
                    tree = new ExpressionTree(expression);
                    return true;
                case "2":
                    Console.WriteLine("Chose a variable: ");
                    variable = Console.ReadLine();
                    Console.WriteLine("Enter a value for that variable");
                    value = Convert.ToDouble(Console.ReadLine());
#pragma warning disable CS8604 // Possible null reference argument.
                    tree.SetVariable(variable, value);
#pragma warning restore CS8604 // Possible null reference argument.
                    return true;
                case "3":
                    Console.WriteLine(Convert.ToString(tree.Evaluate()));
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return true;
                case "4":
                    return false;
                default:
                    Console.WriteLine("Invalid number, try again.");
                    return true;
            }
        }

        private static void Main()
        {

            bool showMenu = true;

            string expression = string.Empty;

            while (showMenu)
            {
                showMenu = DoMenu(ref expression);
            }
        }
       }
    }