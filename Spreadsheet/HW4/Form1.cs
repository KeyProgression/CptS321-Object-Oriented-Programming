namespace HW4
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.GenerateColumns();
            this.GenerateRows();
        }

        /// <summary>
        /// Function generates columns labeled A to Z in object dataGridView1.
        /// </summary>
        private void GenerateColumns()
        {
            string[] columnHeader = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i < 26; i++)
            {
                this.dataGridView1.Columns.Add(columnHeader[i], columnHeader[i]);
            }
        }

        /// <summary>
        /// Method generates rows labeled 1 to 50 in object dataGridView1.
        /// </summary>
        private void GenerateRows()
        {
            this.dataGridView1.Rows.Add(50);

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.HeaderCell.Value = string.Format("{0}", row.Index + 1);
            }

            this.dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}