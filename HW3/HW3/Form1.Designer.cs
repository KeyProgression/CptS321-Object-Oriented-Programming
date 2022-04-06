namespace HW3
{
    partial class Form1
    {
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LoadFibonacci50 = new System.Windows.Forms.Button();
            this.LoadFibonacci100 = new System.Windows.Forms.Button();
            this.LoadFile = new System.Windows.Forms.Button();
            this.SaveFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(776, 410);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // LoadFibonacci50
            // 
            this.LoadFibonacci50.Location = new System.Drawing.Point(181, 3);
            this.LoadFibonacci50.Name = "LoadFibonacci50";
            this.LoadFibonacci50.Size = new System.Drawing.Size(115, 23);
            this.LoadFibonacci50.TabIndex = 3;
            this.LoadFibonacci50.Text = "Load Fibonacci 50";
            this.LoadFibonacci50.UseVisualStyleBackColor = true;
            this.LoadFibonacci50.Click += new System.EventHandler(this.LoadFibonacci50_Click);
            // 
            // LoadFibonacci100
            // 
            this.LoadFibonacci100.Location = new System.Drawing.Point(302, 3);
            this.LoadFibonacci100.Name = "LoadFibonacci100";
            this.LoadFibonacci100.Size = new System.Drawing.Size(117, 23);
            this.LoadFibonacci100.TabIndex = 4;
            this.LoadFibonacci100.Text = "Load Fibonacci 100";
            this.LoadFibonacci100.UseVisualStyleBackColor = true;
            this.LoadFibonacci100.Click += new System.EventHandler(this.LoadFibonacci100_Click);
            // 
            // LoadFile
            // 
            this.LoadFile.Location = new System.Drawing.Point(19, 3);
            this.LoadFile.Name = "LoadFile";
            this.LoadFile.Size = new System.Drawing.Size(75, 23);
            this.LoadFile.TabIndex = 5;
            this.LoadFile.Text = "Load File";
            this.LoadFile.UseVisualStyleBackColor = true;
            this.LoadFile.Click += new System.EventHandler(this.LoadFile_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Location = new System.Drawing.Point(100, 3);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(75, 23);
            this.SaveFile.TabIndex = 6;
            this.SaveFile.Text = "Save File";
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveFile);
            this.Controls.Add(this.LoadFile);
            this.Controls.Add(this.LoadFibonacci100);
            this.Controls.Add(this.LoadFibonacci50);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button LoadFibonacci50;
        private Button LoadFibonacci100;
        private Button LoadFile;
        private Button SaveFile;
    }
}