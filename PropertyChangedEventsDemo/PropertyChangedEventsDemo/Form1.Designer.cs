namespace PropertyChangedEventsDemo
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
            this.btnFirstName1_Click = new System.Windows.Forms.Button();
            this.btnFirstName2_Click = new System.Windows.Forms.Button();
            this.btnLastName1_Click = new System.Windows.Forms.Button();
            this.btnLastName2_Click = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnFirstName1_Click
            // 
            this.btnFirstName1_Click.Location = new System.Drawing.Point(133, 122);
            this.btnFirstName1_Click.Name = "btnFirstName1_Click";
            this.btnFirstName1_Click.Size = new System.Drawing.Size(315, 23);
            this.btnFirstName1_Click.TabIndex = 0;
            this.btnFirstName1_Click.Text = "First name is Currently Joe. Click to change to Bob.";
            this.btnFirstName1_Click.UseVisualStyleBackColor = true;
            this.btnFirstName1_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnFirstName2_Click
            // 
            this.btnFirstName2_Click.Location = new System.Drawing.Point(133, 151);
            this.btnFirstName2_Click.Name = "btnFirstName2_Click";
            this.btnFirstName2_Click.Size = new System.Drawing.Size(315, 23);
            this.btnFirstName2_Click.TabIndex = 1;
            this.btnFirstName2_Click.Text = "First name is Currently Bob Click to change to Joe.";
            this.btnFirstName2_Click.UseVisualStyleBackColor = true;
            this.btnFirstName2_Click.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLastName1_Click
            // 
            this.btnLastName1_Click.Location = new System.Drawing.Point(133, 250);
            this.btnLastName1_Click.Name = "btnLastName1_Click";
            this.btnLastName1_Click.Size = new System.Drawing.Size(315, 23);
            this.btnLastName1_Click.TabIndex = 2;
            this.btnLastName1_Click.Text = "Last name is currently Smith. Click to change to Johnson";
            this.btnLastName1_Click.UseVisualStyleBackColor = true;
            this.btnLastName1_Click.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLastName2_Click
            // 
            this.btnLastName2_Click.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLastName2_Click.Location = new System.Drawing.Point(133, 279);
            this.btnLastName2_Click.Name = "btnLastName2_Click";
            this.btnLastName2_Click.Size = new System.Drawing.Size(315, 23);
            this.btnLastName2_Click.TabIndex = 3;
            this.btnLastName2_Click.Text = "Last name is currently Johnson. Click to change to Smith.";
            this.btnLastName2_Click.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLastName2_Click.UseVisualStyleBackColor = true;
            this.btnLastName2_Click.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(123, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Name";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Location = new System.Drawing.Point(123, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 109);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(604, 467);
            this.Controls.Add(this.btnLastName2_Click);
            this.Controls.Add(this.btnLastName1_Click);
            this.Controls.Add(this.btnFirstName2_Click);
            this.Controls.Add(this.btnFirstName1_Click);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "CptS 321: Property Changed Events Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFirstName1_Click;
        private Button btnFirstName2_Click;
        private Button btnLastName1_Click;
        private Button btnLastName2_Click;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}