namespace HW4
{
    partial class Form1
    {
        private readonly CptS321.Spreadsheet table = new(50,50);
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 409);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;

        /// <summary>
        /// Using MSDN to begin edit handler.
        /// </summary>
        /// <param name="sender"> Param sender.</param>
        /// <param name="e">Param e.</param>
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            CptS321.Spreadsheet_Cell index = table.GetCell(e.RowIndex, e.ColumnIndex);
            string msg = string.Format("Editing cell: ({0}, {1})", e.ColumnIndex, e.RowIndex);
            dataGridView1.CurrentCell.Value = msg;
        }

        // Pt 2 completed
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CptS321.Spreadsheet_Cell index = table.GetCell(e.RowIndex, e.ColumnIndex);
            string msg = string.Format("Editing cell: ({0}, {1}) complete.", e.ColumnIndex, e.RowIndex);
            string previousText = index.Text;

            if (this.dataGridView1.CurrentCell.Value != null)
            {
                index.Text = dataGridView1.CurrentCell.Value.ToString();
            }
            else
            {
                dataGridView1.CurrentCell.Value = string.Empty;
            }
        }
    }
}