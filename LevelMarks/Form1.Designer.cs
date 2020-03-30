namespace LevelMarks
{
    partial class Form1
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
            this.TreeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.TextNoteTypeComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRight = new System.Windows.Forms.RadioButton();
            this.radioButtonLeft = new System.Windows.Forms.RadioButton();
            this.LevelComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.BackColor = System.Drawing.SystemColors.Control;
            this.TreeView.Location = new System.Drawing.Point(12, 12);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(311, 386);
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterCheck);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 602);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Применить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextNoteTypeComboBox
            // 
            this.TextNoteTypeComboBox.FormattingEnabled = true;
            this.TextNoteTypeComboBox.Location = new System.Drawing.Point(73, 420);
            this.TextNoteTypeComboBox.Name = "TextNoteTypeComboBox";
            this.TextNoteTypeComboBox.Size = new System.Drawing.Size(200, 24);
            this.TextNoteTypeComboBox.TabIndex = 4;
            this.TextNoteTypeComboBox.Text = "Текстовые примечания";
            this.TextNoteTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TextNoteTypeComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRight);
            this.groupBox1.Controls.Add(this.radioButtonLeft);
            this.groupBox1.Location = new System.Drawing.Point(73, 520);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сторона размещения";
            // 
            // radioButtonRight
            // 
            this.radioButtonRight.AutoSize = true;
            this.radioButtonRight.Location = new System.Drawing.Point(6, 49);
            this.radioButtonRight.Name = "radioButtonRight";
            this.radioButtonRight.Size = new System.Drawing.Size(77, 21);
            this.radioButtonRight.TabIndex = 1;
            this.radioButtonRight.TabStop = true;
            this.radioButtonRight.Text = "Справа";
            this.radioButtonRight.UseVisualStyleBackColor = true;
            // 
            // radioButtonLeft
            // 
            this.radioButtonLeft.AutoSize = true;
            this.radioButtonLeft.Location = new System.Drawing.Point(6, 21);
            this.radioButtonLeft.Name = "radioButtonLeft";
            this.radioButtonLeft.Size = new System.Drawing.Size(69, 21);
            this.radioButtonLeft.TabIndex = 0;
            this.radioButtonLeft.TabStop = true;
            this.radioButtonLeft.Text = "Слева";
            this.radioButtonLeft.UseVisualStyleBackColor = true;
            // 
            // LevelComboBox
            // 
            this.LevelComboBox.FormattingEnabled = true;
            this.LevelComboBox.Location = new System.Drawing.Point(73, 490);
            this.LevelComboBox.Name = "LevelComboBox";
            this.LevelComboBox.Size = new System.Drawing.Size(200, 24);
            this.LevelComboBox.TabIndex = 6;
            this.LevelComboBox.Text = "Параметр уровня ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Выбор семейства текстовых примечаний";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выбор параметра уровня, ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "из которого необходимо считать номер этажа";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(335, 638);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LevelComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextNoteTypeComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Отметки уровней ВК";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox TextNoteTypeComboBox;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonRight;
        public System.Windows.Forms.RadioButton radioButtonLeft;
        public System.Windows.Forms.ComboBox LevelComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}