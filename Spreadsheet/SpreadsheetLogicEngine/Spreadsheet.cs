namespace CptS321
{
    using System;
    using System.ComponentModel;

    public class Spreadsheet
    {
        private readonly Spreadsheet_Cell[,] _cell;

        private readonly int _rowCount;
        private readonly int _columnCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="rowIndex">Cell Row index</param>
        /// <param name="columnIndex">Cell Column index</param>
        public Spreadsheet(int rowIndex, int columnIndex)
        {
            _cell = new Spreadsheet_Cell[rowIndex, columnIndex];
            _rowCount = rowIndex;
            _columnCount = columnIndex;

            for (int index = 0; index < _rowCount; ++index)
            {
                for (int index2 = 0; index2 < _columnCount; ++index2)
                {
                    _cell[index, index2] = new Cell(index, index2);
#pragma warning disable CS8601 // Possible null reference assignment.
                    _cell[index, index2].PropertyChanged += new PropertyChangedEventHandler(CellPropertyChanged);
#pragma warning restore CS8601 // Possible null reference assignment.
                    _cell[index, index2].Value = Convert.ToString(0);
                }
            }
        }

        // public string? undoText;
        // public string? redoText;
        /// <summary>
        /// Event handler for changing cell properties.
        /// </summary>
        public event PropertyChangedEventHandler? CellPropertyChanged;

        /// <summary>
        /// Returns _rowCount
        /// </summary>
        /// <value>
        /// This returns _rowCount.
        /// </value>
        public int RowCount => _rowCount;

        /// <summary>
        /// Returns _columnCount
        /// </summary>
        /// <value>
        /// This returns _columnCount.
        /// </value>
        public int ColumnCount => _columnCount;

        /// <summary>
        /// Gets the Cell's position
        /// </summary>
        /// <param name="rowIndex"> The row of the spreadsheet</param>
        /// <param name="colIndex">The column of the spreadsheet</param>
        /// <returns>Returns the spreadsheet cell of entered input indices</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Spreadsheet_Cell GetCell(int rowIndex, int colIndex)
        {
            if (rowIndex > _rowCount || colIndex > _columnCount)
            {
                throw new IndexOutOfRangeException();
            }

            return _cell[rowIndex, colIndex];
        }

        /// <summary>
        /// Gets single value of a cell.
        /// </summary>
        /// <param name="variables">The variables you're trying to retrieve.</param>
        /// <returns>GetCell with row and col</returns>
        private Spreadsheet_Cell GetSingleValue(string variables)
        {
            Dictionary<char, int> colNum = new Dictionary<char, int>();
            int count = 0;
            int row = 0;
            int col = 0;

            for (char i = 'A'; i <= 'Z'; i++)
            {
                colNum[i] = count;
                count++;
            }

            string number = variables.Substring(1);

            try
            {
                row = Convert.ToInt32(number) - 1;
            }
            catch (FormatException)
            {
                return null;
            }

            col = colNum[variables[0]];

            return GetCell(row, col);
        }

        private void CellPropertyHasChanged(object sender, PropertyChangedEventArgs e)
        {
            int count = 0;
            Spreadsheet_Cell? spreadsheet = sender as Spreadsheet_Cell;
            Dictionary<int, char> trk = new ();

            for (char val = 'A'; val <= 'Z'; val++)
            {
                trk[count++] = val;
            }
            string changeCellTo = trk[spreadsheet.ColumnIndex].ToString() + (spreadsheet.RowIndex + 1).ToString();

            if (e.PropertyName == "Text")
            {
                if (spreadsheet.Text.StartsWith("=") == false)
                {
                    spreadsheet.Value = spreadsheet.Text;
                }
                else
                {
                    if (spreadsheet.Text.Length > 3)
                    {
                        ExpressionTree expTree;
                        string expression = spreadsheet.Text.Substring(1);
                        expTree = new (expression);
                        List<string> listString = expTree.GetVar(expression);

                        foreach (string retrieve in listString)
                        {
                            Spreadsheet_Cell cell = GetSingleValue(retrieve);

                            if (cell != null)
                            {
                                if (GetSingleValue(changeCellTo) == GetSingleValue(retrieve))
                                {
                                    spreadsheet.Value = cell.Value;
                                }
                                else if (GetSingleValue(retrieve).Value != "!self reference")
                                {
                                    double value = Convert.ToDouble(GetSingleValue(retrieve).Value);

                                    expTree.SetVariable(retrieve, value);

                                    spreadsheet.Value = expTree.Evaluate().ToString();
                                }
                                else
                                {
                                    spreadsheet.Value = Convert.ToString(0);
                                }

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                                cell.PropertyChanged += spreadsheet.CellPropertyChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
                            }
                            else
                            {
                                spreadsheet.Value = "!bad reference";
                            }
                        }
                    }
                }
                CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
            }
        }
    }
}
