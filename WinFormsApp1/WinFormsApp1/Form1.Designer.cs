
namespace WinFormsApp1
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox_in = new System.Windows.Forms.TextBox();
            this.textBox_out = new System.Windows.Forms.TextBox();
            this.label_in = new System.Windows.Forms.Label();
            this.label_out = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.button_insert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show employee list";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(29, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(381, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox_in
            // 
            this.textBox_in.Location = new System.Drawing.Point(149, 190);
            this.textBox_in.Name = "textBox_in";
            this.textBox_in.Size = new System.Drawing.Size(261, 31);
            this.textBox_in.TabIndex = 2;
            // 
            // textBox_out
            // 
            this.textBox_out.Location = new System.Drawing.Point(149, 253);
            this.textBox_out.Name = "textBox_out";
            this.textBox_out.Size = new System.Drawing.Size(261, 31);
            this.textBox_out.TabIndex = 3;
            // 
            // label_in
            // 
            this.label_in.AutoSize = true;
            this.label_in.Location = new System.Drawing.Point(26, 196);
            this.label_in.Name = "label_in";
            this.label_in.Size = new System.Drawing.Size(80, 25);
            this.label_in.TabIndex = 4;
            this.label_in.Text = "Check-in";
            this.label_in.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_out
            // 
            this.label_out.AutoSize = true;
            this.label_out.Location = new System.Drawing.Point(26, 259);
            this.label_out.Name = "label_out";
            this.label_out.Size = new System.Drawing.Size(93, 25);
            this.label_out.TabIndex = 5;
            this.label_out.Text = "Check-out";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(29, 140);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(54, 25);
            this.label_date.TabIndex = 6;
            this.label_date.Text = "Date ";
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(149, 134);
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(261, 31);
            this.textBox_date.TabIndex = 7;
            // 
            // button_insert
            // 
            this.button_insert.Location = new System.Drawing.Point(149, 331);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(123, 34);
            this.button_insert.TabIndex = 8;
            this.button_insert.Text = "Insert date";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.button_insert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 389);
            this.Controls.Add(this.button_insert);
            this.Controls.Add(this.textBox_date);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_out);
            this.Controls.Add(this.label_in);
            this.Controls.Add(this.textBox_out);
            this.Controls.Add(this.textBox_in);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_in;
        private System.Windows.Forms.TextBox textBox_out;
        private System.Windows.Forms.Label label_in;
        private System.Windows.Forms.Label label_out;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.TextBox textBox_date;
        private System.Windows.Forms.Button button_insert;
    }
}

