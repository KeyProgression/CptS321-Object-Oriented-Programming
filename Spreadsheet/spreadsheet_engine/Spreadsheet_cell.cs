namespace CptS321
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class Spreadsheet_Cell : INotifyPropertyChanged
    {
        private readonly int rowIndex;
        private readonly int columnIndex;
        protected string cellText;
        protected string _value;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Passes read only values to the constructor, containing the index of both the column and the row, which will be edited.
        /// </summary>
        /// <param name="_rowIndex">The index of the row to be edited.</param>
        /// <param name="_columnIndex">The index of the column to be edited.</param>
        Spreadsheet_Cell(int _rowIndex, int _columnIndex)
        {
            this.rowIndex = _rowIndex;
            this.columnIndex = _columnIndex;
        }

        public int RowIndex { get { return rowIndex; } }
        public int ColumnIndex { get { return columnIndex; } }
        public string Text { get { return cellText; }
            set {
                if (this.Text == this.cellText)
                    return;
                else
                {
                    this.cellText = value;
                    this.OnPropertyChanged();
                }
                ; } }

        public string Value { get { return this._value; }}

        /// <summary>
        /// The OnPropertyChanged method raises the event.
        /// </summary>
        /// <param name="cellText">The calling member's name will be used as the parameter.</param>
        protected void OnPropertyChanged([CallerMemberName] string? cellText = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cellText));
        }
    }
}
