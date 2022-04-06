namespace CptS321
{
    /// <summary>
    /// Cell class to do part 5.
    /// </summary>
    public class Cell : Spreadsheet_Cell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="rowIn">Row index for spreadsheet.</param>
        /// <param name="colIn">Column index for spreadsheet.</param>
        public Cell(int rowIn, int colIn)
            : base(rowIn, colIn)
        {
        }
    }
}
