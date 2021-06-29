namespace LAB2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OpenImgBtn = new System.Windows.Forms.Button();
            this.srcImageBox = new System.Windows.Forms.PictureBox();
            this.resImageBox = new System.Windows.Forms.PictureBox();
            this.ActionsList = new System.Windows.Forms.ListBox();
            this.DoActionBtn = new System.Windows.Forms.Button();
            this.AddIntoListBtn = new System.Windows.Forms.Button();
            this.CurrentActList = new System.Windows.Forms.ListBox();
            this.DeleteActionBtn = new System.Windows.Forms.Button();
            this.DoActionsBtn = new System.Windows.Forms.Button();
            this.moneyBox = new System.Windows.Forms.RichTextBox();
            this.targetBox = new System.Windows.Forms.RichTextBox();
            this.meanLbl = new System.Windows.Forms.Label();
            this.meanValue = new System.Windows.Forms.NumericUpDown();
            this.g1 = new System.Windows.Forms.RadioButton();
            this.g2 = new System.Windows.Forms.RadioButton();
            this.g3 = new System.Windows.Forms.RadioButton();
            this.maskLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.srcImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanValue)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // OpenImgBtn
            // 
            this.OpenImgBtn.Location = new System.Drawing.Point(12, 13);
            this.OpenImgBtn.Name = "OpenImgBtn";
            this.OpenImgBtn.Size = new System.Drawing.Size(75, 23);
            this.OpenImgBtn.TabIndex = 0;
            this.OpenImgBtn.Text = "Открыть";
            this.OpenImgBtn.UseVisualStyleBackColor = true;
            this.OpenImgBtn.Click += new System.EventHandler(this.OpenImgBtn_Click);
            // 
            // srcImageBox
            // 
            this.srcImageBox.Location = new System.Drawing.Point(12, 42);
            this.srcImageBox.Name = "srcImageBox";
            this.srcImageBox.Size = new System.Drawing.Size(560, 460);
            this.srcImageBox.TabIndex = 1;
            this.srcImageBox.TabStop = false;
            // 
            // resImageBox
            // 
            this.resImageBox.Location = new System.Drawing.Point(761, 42);
            this.resImageBox.Name = "resImageBox";
            this.resImageBox.Size = new System.Drawing.Size(597, 460);
            this.resImageBox.TabIndex = 2;
            this.resImageBox.TabStop = false;
            // 
            // ActionsList
            // 
            this.ActionsList.FormattingEnabled = true;
            this.ActionsList.Items.AddRange(new object[] {
            "Бинаризация",
            "Свертка",
            "Сужение",
            "Расширение",
            "Открытие",
            "Закрытие",
            "Выделение связных областей",
            "Оттенки серого",
            "Серый мир",
            "Растяжение контрастности",
            "Распознать"});
            this.ActionsList.Location = new System.Drawing.Point(578, 42);
            this.ActionsList.Name = "ActionsList";
            this.ActionsList.Size = new System.Drawing.Size(177, 160);
            this.ActionsList.TabIndex = 3;
            // 
            // DoActionBtn
            // 
            this.DoActionBtn.Location = new System.Drawing.Point(673, 212);
            this.DoActionBtn.Name = "DoActionBtn";
            this.DoActionBtn.Size = new System.Drawing.Size(82, 34);
            this.DoActionBtn.TabIndex = 4;
            this.DoActionBtn.Text = "Выполнить";
            this.DoActionBtn.UseVisualStyleBackColor = true;
            this.DoActionBtn.Click += new System.EventHandler(this.DoActionBtn_Click);
            // 
            // AddIntoListBtn
            // 
            this.AddIntoListBtn.Location = new System.Drawing.Point(577, 212);
            this.AddIntoListBtn.Name = "AddIntoListBtn";
            this.AddIntoListBtn.Size = new System.Drawing.Size(87, 34);
            this.AddIntoListBtn.TabIndex = 5;
            this.AddIntoListBtn.Text = "Добавить в список";
            this.AddIntoListBtn.UseVisualStyleBackColor = true;
            this.AddIntoListBtn.Click += new System.EventHandler(this.AddIntoListBtn_Click);
            // 
            // CurrentActList
            // 
            this.CurrentActList.FormattingEnabled = true;
            this.CurrentActList.Location = new System.Drawing.Point(578, 252);
            this.CurrentActList.Name = "CurrentActList";
            this.CurrentActList.Size = new System.Drawing.Size(177, 199);
            this.CurrentActList.TabIndex = 6;
            // 
            // DeleteActionBtn
            // 
            this.DeleteActionBtn.Location = new System.Drawing.Point(578, 457);
            this.DeleteActionBtn.Name = "DeleteActionBtn";
            this.DeleteActionBtn.Size = new System.Drawing.Size(69, 45);
            this.DeleteActionBtn.TabIndex = 7;
            this.DeleteActionBtn.Text = "Удалить";
            this.DeleteActionBtn.UseVisualStyleBackColor = true;
            this.DeleteActionBtn.Click += new System.EventHandler(this.DeleteActionBtn_Click);
            // 
            // DoActionsBtn
            // 
            this.DoActionsBtn.Location = new System.Drawing.Point(653, 457);
            this.DoActionsBtn.Name = "DoActionsBtn";
            this.DoActionsBtn.Size = new System.Drawing.Size(102, 45);
            this.DoActionsBtn.TabIndex = 8;
            this.DoActionsBtn.Text = "Выполнить список действий";
            this.DoActionsBtn.UseVisualStyleBackColor = true;
            this.DoActionsBtn.Click += new System.EventHandler(this.DoActionsBtn_Click);
            // 
            // moneyBox
            // 
            this.moneyBox.Location = new System.Drawing.Point(12, 508);
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.Size = new System.Drawing.Size(261, 142);
            this.moneyBox.TabIndex = 9;
            this.moneyBox.Text = "";
            // 
            // targetBox
            // 
            this.targetBox.Location = new System.Drawing.Point(298, 511);
            this.targetBox.Name = "targetBox";
            this.targetBox.Size = new System.Drawing.Size(457, 141);
            this.targetBox.TabIndex = 10;
            this.targetBox.Text = "";
            // 
            // meanLbl
            // 
            this.meanLbl.AutoSize = true;
            this.meanLbl.Location = new System.Drawing.Point(1131, 514);
            this.meanLbl.Name = "meanLbl";
            this.meanLbl.Size = new System.Drawing.Size(161, 13);
            this.meanLbl.TabIndex = 11;
            this.meanLbl.Text = "Параметр медианной свертки";
            // 
            // meanValue
            // 
            this.meanValue.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.meanValue.Location = new System.Drawing.Point(1298, 509);
            this.meanValue.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.meanValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.meanValue.Name = "meanValue";
            this.meanValue.Size = new System.Drawing.Size(60, 20);
            this.meanValue.TabIndex = 12;
            this.meanValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // g1
            // 
            this.g1.AutoSize = true;
            this.g1.Location = new System.Drawing.Point(936, 514);
            this.g1.Name = "g1";
            this.g1.Size = new System.Drawing.Size(37, 17);
            this.g1.TabIndex = 13;
            this.g1.TabStop = true;
            this.g1.Text = "g1";
            this.g1.UseVisualStyleBackColor = true;
            // 
            // g2
            // 
            this.g2.AutoSize = true;
            this.g2.Location = new System.Drawing.Point(979, 514);
            this.g2.Name = "g2";
            this.g2.Size = new System.Drawing.Size(37, 17);
            this.g2.TabIndex = 14;
            this.g2.TabStop = true;
            this.g2.Text = "g2";
            this.g2.UseVisualStyleBackColor = true;
            this.g2.CheckedChanged += new System.EventHandler(this.g2_CheckedChanged);
            // 
            // g3
            // 
            this.g3.AutoSize = true;
            this.g3.Location = new System.Drawing.Point(1022, 514);
            this.g3.Name = "g3";
            this.g3.Size = new System.Drawing.Size(37, 17);
            this.g3.TabIndex = 15;
            this.g3.TabStop = true;
            this.g3.Text = "g3";
            this.g3.UseVisualStyleBackColor = true;
            // 
            // maskLbl
            // 
            this.maskLbl.AutoSize = true;
            this.maskLbl.Location = new System.Drawing.Point(803, 511);
            this.maskLbl.Name = "maskLbl";
            this.maskLbl.Size = new System.Drawing.Size(127, 13);
            this.maskLbl.TabIndex = 16;
            this.maskLbl.Text = "Маска для морфологии";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(806, 537);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(269, 104);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 664);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.maskLbl);
            this.Controls.Add(this.g3);
            this.Controls.Add(this.g2);
            this.Controls.Add(this.g1);
            this.Controls.Add(this.meanValue);
            this.Controls.Add(this.meanLbl);
            this.Controls.Add(this.targetBox);
            this.Controls.Add(this.moneyBox);
            this.Controls.Add(this.DoActionsBtn);
            this.Controls.Add(this.DeleteActionBtn);
            this.Controls.Add(this.CurrentActList);
            this.Controls.Add(this.AddIntoListBtn);
            this.Controls.Add(this.DoActionBtn);
            this.Controls.Add(this.ActionsList);
            this.Controls.Add(this.resImageBox);
            this.Controls.Add(this.srcImageBox);
            this.Controls.Add(this.OpenImgBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.srcImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meanValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OpenImgBtn;
        private System.Windows.Forms.PictureBox srcImageBox;
        private System.Windows.Forms.PictureBox resImageBox;
        private System.Windows.Forms.ListBox ActionsList;
        private System.Windows.Forms.Button DoActionBtn;
        private System.Windows.Forms.Button AddIntoListBtn;
        private System.Windows.Forms.ListBox CurrentActList;
        private System.Windows.Forms.Button DeleteActionBtn;
        private System.Windows.Forms.Button DoActionsBtn;
        private System.Windows.Forms.RichTextBox moneyBox;
        private System.Windows.Forms.RichTextBox targetBox;
        private System.Windows.Forms.Label meanLbl;
        private System.Windows.Forms.NumericUpDown meanValue;
        private System.Windows.Forms.RadioButton g1;
        private System.Windows.Forms.RadioButton g2;
        private System.Windows.Forms.RadioButton g3;
        private System.Windows.Forms.Label maskLbl;
        private System.Windows.Forms.TextBox textBox1;
    }
}

