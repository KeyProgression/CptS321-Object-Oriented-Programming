// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Matthew Yien</author>
// <studentid>11698797</studentid>

namespace HW2
{
    /// <summary>
    /// Where all the action happens.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly FindDistinct output = new FindDistinct();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.output.Results();
        }
    }
}
