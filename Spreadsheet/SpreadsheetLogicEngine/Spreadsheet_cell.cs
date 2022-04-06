namespace CptS321
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class Spreadsheet_Cell : INotifyPropertyChanged
    {
        private int _rowIndex;
        private int _columnIndex;

        private string? _cellText;
        private string? _value;

        /// <summary>
        /// Passes read only values to the constructor, containing the index of both the column and the row, which will be edited.
        /// </summary>
        /// <param name="_rowIndex">The index of the row to be edited.</param>
        /// <param name="_columnIndex">The index of the column to be edited.</param>
        public Spreadsheet_Cell(int rowIndex, int columnIndex)
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _cellText = string.Empty;
            _value = string.Empty;
        }

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { _columnIndex = value; }
        }

        public string Text
        {
            get
            {
                return _cellText;
            }

            set
            {
                if (Text == _cellText)
                {
                    return;
                }
                else
                {
                    _cellText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }

            internal set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Property changed.
        /// </summary>
        /// <param name="sender">Sender parameter</param>
        /// <param name="e">Event parameter</param>
        public void CellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }

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
