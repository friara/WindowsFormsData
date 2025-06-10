namespace WinFormsApp3.View
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            textBox1 = new TextBox();
            labelComboBox = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBox6 = new TextBox();
            label6 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            maskedTextBox2 = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(244, 232, 211);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 0;
            label1.Text = "Наименование";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(167, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(511, 27);
            textBox1.TabIndex = 1;
            // 
            // labelComboBox
            // 
            labelComboBox.AutoSize = true;
            labelComboBox.BackColor = Color.FromArgb(244, 232, 211);
            labelComboBox.Location = new Point(12, 78);
            labelComboBox.Name = "labelComboBox";
            labelComboBox.Size = new Size(105, 20);
            labelComboBox.TabIndex = 2;
            labelComboBox.Text = "Тип партнера";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(167, 75);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(511, 28);
            comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(244, 232, 211);
            label2.Location = new Point(12, 127);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 4;
            label2.Text = "Рейтинг";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(167, 183);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(511, 27);
            textBox3.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(244, 232, 211);
            label3.Location = new Point(12, 183);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 6;
            label3.Text = "Адрес";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(167, 235);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(511, 27);
            textBox4.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(244, 232, 211);
            label4.Location = new Point(12, 235);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 8;
            label4.Text = "ФИО директора";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(244, 232, 211);
            label5.Location = new Point(12, 290);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 10;
            label5.Text = "Телефон";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(167, 341);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(511, 27);
            textBox6.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(244, 232, 211);
            label6.Location = new Point(12, 341);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 12;
            label6.Text = "Email";
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(167, 124);
            maskedTextBox1.Mask = "00000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(125, 27);
            maskedTextBox1.TabIndex = 14;
            maskedTextBox1.ValidatingType = typeof(int);
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(30, 107, 146);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("PMingLiU-ExtB", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(572, 421);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(106, 26);
            button1.TabIndex = 15;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(30, 107, 146);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("PMingLiU-ExtB", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(22, 421);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(106, 26);
            button2.TabIndex = 16;
            button2.Text = "Назад";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(244, 232, 211);
            panel1.Location = new Point(5, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(156, 356);
            panel1.TabIndex = 17;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Location = new Point(167, 290);
            maskedTextBox2.Mask = "+7 999 000 00 00";
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(264, 27);
            maskedTextBox2.TabIndex = 18;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 483);
            Controls.Add(maskedTextBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(maskedTextBox1);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(labelComboBox);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Данные партнера";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label labelComboBox;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Label label5;
        private TextBox textBox6;
        private Label label6;
        private MaskedTextBox maskedTextBox1;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private MaskedTextBox maskedTextBox2;
    }
}