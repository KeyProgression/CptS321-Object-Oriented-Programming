// <copyright file="Form1.cs" company="Washington State University">
// Copyright (c) Washington State University. All rights reserved.
// </copyright>
/*
 * Author: Matthew Yien
 * Student ID: 11698797
 */

namespace HW3
{
    /// <summary>
    /// Standard WinForm partial class.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Loads all the TextReader objext to the text box in Form1.
        /// </summary>
        /// <param name="sr">System.IO.TextReader object.</param>
        private void LoadText(TextReader sr)
        {
            // Unsure if ReadLine adds a new line at the end of reading, so adding it manually until tested.
           this.textBox1.Text = "1: " + sr.ReadLine();
           this.textBox1.AppendText(System.Environment.NewLine);

           // start line count from 2 and read in from there, first one was manually set, rough implementation of line counting.
           int lineCount = 2;
           // This will contain the actual string you're reading in
           string strValue;

           while ((strValue = sr.ReadLine()) != null)
           {
                this.textBox1.AppendText(lineCount.ToString() + ": " + strValue);
                lineCount++;
                this.textBox1.AppendText(System.Environment.NewLine);
            }
        }

        // unused button
        private void SaveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        // Unused function
        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        /// <summary>
        /// Calls FibonacciTextReader and loads the first 50 numbers of the series
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFibonacci50_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader (51);

            this.LoadText(fibonacciTextReader);

        }

        private void LoadFibonacci100_Click(object sender, EventArgs e)
        {
            FibonacciTextReader fibonacciTextReader = new FibonacciTextReader(101);

            this.LoadText(fibonacciTextReader);
        }

        /// <summary>
        /// Uses LoadText function to load text from a file.
        /// </summary>
        /// <param name="sender">Windows generated parameter.</param>
        /// <param name="e">Windows generated parametey.</param>
        private void LoadFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = false,
            };

            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            bool? userClickedOK = false;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userClickedOK = true;
            }

            if (userClickedOK == true)
            {
                Stream fileStream = this.openFileDialog1.OpenFile();

                using (StreamReader reader = new(fileStream))
                {
                    this.LoadText(reader);
                }

                fileStream.Close();
            }
        }

        /// <summary>
        /// Save method from: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?redirectedfrom=MSDN&view=windowsdesktop-6.0 .
        /// </summary>
        /// <param name="sender">Visual Studio Generated Parameter.</param>
        /// <param name="e">Windows generated parameter.</param>
        private void SaveFile_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
            };

            bool? userClickedOK = false;

            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userClickedOK = true;
            }

            if (userClickedOK == true)
            {
                File.WriteAllText(this.saveFileDialog1.FileName, this.textBox1.Text);
            }
        }
    }
}