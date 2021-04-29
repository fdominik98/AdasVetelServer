
namespace AdasVetelServer
{
    partial class KeyPickerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyPickerDialog));
            this.lockButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.beforeText = new System.Windows.Forms.RichTextBox();
            this.afterText = new System.Windows.Forms.RichTextBox();
            this.selectionTextBox = new System.Windows.Forms.RichTextBox();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.beforeTextLocked = new System.Windows.Forms.RichTextBox();
            this.afterTextLocked = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.beforeContextNum = new System.Windows.Forms.NumericUpDown();
            this.afterContextNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.afterCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.beforeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.isKeyCountBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zoomOutBtn = new System.Windows.Forms.Button();
            this.zoomInBtn = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.keyStringLocked = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beforeContextNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterContextNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lockButton
            // 
            this.lockButton.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lockButton.Location = new System.Drawing.Point(421, 190);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(141, 53);
            this.lockButton.TabIndex = 1;
            this.lockButton.Text = "Keresett érték lekötése";
            this.lockButton.UseVisualStyleBackColor = true;
            this.lockButton.Click += new System.EventHandler(this.lockButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.beforeText);
            this.groupBox1.Controls.Add(this.afterText);
            this.groupBox1.Controls.Add(this.selectionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 314);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // beforeText
            // 
            this.beforeText.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.beforeText.Location = new System.Drawing.Point(6, 24);
            this.beforeText.Name = "beforeText";
            this.beforeText.ReadOnly = true;
            this.beforeText.Size = new System.Drawing.Size(190, 161);
            this.beforeText.TabIndex = 5;
            this.beforeText.Text = "";
            // 
            // afterText
            // 
            this.afterText.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.afterText.Location = new System.Drawing.Point(390, 24);
            this.afterText.Name = "afterText";
            this.afterText.ReadOnly = true;
            this.afterText.Size = new System.Drawing.Size(182, 161);
            this.afterText.TabIndex = 4;
            this.afterText.Text = "";
            // 
            // selectionTextBox
            // 
            this.selectionTextBox.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionTextBox.Location = new System.Drawing.Point(202, 24);
            this.selectionTextBox.Name = "selectionTextBox";
            this.selectionTextBox.ReadOnly = true;
            this.selectionTextBox.Size = new System.Drawing.Size(182, 161);
            this.selectionTextBox.TabIndex = 3;
            this.selectionTextBox.Text = "";
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Window;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(10, 11);
            this.textBox.Margin = new System.Windows.Forms.Padding(0);
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(471, 648);
            this.textBox.TabIndex = 4;
            this.textBox.Text = "";
            this.textBox.SelectionChanged += new System.EventHandler(this.textBox_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.beforeTextLocked);
            this.groupBox2.Controls.Add(this.afterTextLocked);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lockButton);
            this.groupBox2.Controls.Add(this.confirmButton);
            this.groupBox2.Controls.Add(this.keyStringLocked);
            this.groupBox2.Location = new System.Drawing.Point(10, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 456);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // beforeTextLocked
            // 
            this.beforeTextLocked.BackColor = System.Drawing.Color.Wheat;
            this.beforeTextLocked.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeTextLocked.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.beforeTextLocked.Location = new System.Drawing.Point(5, 22);
            this.beforeTextLocked.Name = "beforeTextLocked";
            this.beforeTextLocked.ReadOnly = true;
            this.beforeTextLocked.Size = new System.Drawing.Size(190, 161);
            this.beforeTextLocked.TabIndex = 17;
            this.beforeTextLocked.Text = "";
            // 
            // afterTextLocked
            // 
            this.afterTextLocked.BackColor = System.Drawing.Color.Wheat;
            this.afterTextLocked.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterTextLocked.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.afterTextLocked.Location = new System.Drawing.Point(389, 22);
            this.afterTextLocked.Name = "afterTextLocked";
            this.afterTextLocked.ReadOnly = true;
            this.afterTextLocked.Size = new System.Drawing.Size(182, 161);
            this.afterTextLocked.TabIndex = 16;
            this.afterTextLocked.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.beforeContextNum);
            this.groupBox5.Controls.Add(this.afterContextNum);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.afterCheckBox);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.beforeCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 190);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(232, 152);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // beforeContextNum
            // 
            this.beforeContextNum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeContextNum.Location = new System.Drawing.Point(113, 62);
            this.beforeContextNum.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.beforeContextNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.beforeContextNum.Name = "beforeContextNum";
            this.beforeContextNum.Size = new System.Drawing.Size(93, 32);
            this.beforeContextNum.TabIndex = 11;
            this.beforeContextNum.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.beforeContextNum.ValueChanged += new System.EventHandler(this.beforeContextNum_ValueChanged);
            // 
            // afterContextNum
            // 
            this.afterContextNum.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterContextNum.Location = new System.Drawing.Point(113, 106);
            this.afterContextNum.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.afterContextNum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.afterContextNum.Name = "afterContextNum";
            this.afterContextNum.Size = new System.Drawing.Size(93, 32);
            this.afterContextNum.TabIndex = 12;
            this.afterContextNum.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.afterContextNum.ValueChanged += new System.EventHandler(this.afterContextNum_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kontextus hossza:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Utána:";
            // 
            // afterCheckBox
            // 
            this.afterCheckBox.AutoSize = true;
            this.afterCheckBox.Checked = true;
            this.afterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.afterCheckBox.Location = new System.Drawing.Point(18, 112);
            this.afterCheckBox.Name = "afterCheckBox";
            this.afterCheckBox.Size = new System.Drawing.Size(18, 17);
            this.afterCheckBox.TabIndex = 17;
            this.afterCheckBox.UseVisualStyleBackColor = true;
            this.afterCheckBox.CheckedChanged += new System.EventHandler(this.afterCheckBox_CheckedChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Előtte:";
            // 
            // beforeCheckBox
            // 
            this.beforeCheckBox.AutoSize = true;
            this.beforeCheckBox.Checked = true;
            this.beforeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beforeCheckBox.Location = new System.Drawing.Point(18, 73);
            this.beforeCheckBox.Name = "beforeCheckBox";
            this.beforeCheckBox.Size = new System.Drawing.Size(18, 17);
            this.beforeCheckBox.TabIndex = 16;
            this.beforeCheckBox.UseVisualStyleBackColor = true;
            this.beforeCheckBox.CheckedChanged += new System.EventHandler(this.beforeCheckBox_CheckedChanged_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.isKeyCountBox);
            this.groupBox4.Location = new System.Drawing.Point(244, 256);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 86);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // isKeyCountBox
            // 
            this.isKeyCountBox.AutoSize = true;
            this.isKeyCountBox.Checked = true;
            this.isKeyCountBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isKeyCountBox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isKeyCountBox.Location = new System.Drawing.Point(14, 22);
            this.isKeyCountBox.Name = "isKeyCountBox";
            this.isKeyCountBox.Size = new System.Drawing.Size(322, 26);
            this.isKeyCountBox.TabIndex = 12;
            this.isKeyCountBox.Text = "Kijelölt szöveg figyelembevétele";
            this.isKeyCountBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zoomOutBtn);
            this.groupBox3.Controls.Add(this.zoomInBtn);
            this.groupBox3.Location = new System.Drawing.Point(22, 358);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 84);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // zoomOutBtn
            // 
            this.zoomOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomOutBtn.Location = new System.Drawing.Point(79, 11);
            this.zoomOutBtn.Name = "zoomOutBtn";
            this.zoomOutBtn.Size = new System.Drawing.Size(60, 64);
            this.zoomOutBtn.TabIndex = 1;
            this.zoomOutBtn.Text = "-";
            this.zoomOutBtn.UseVisualStyleBackColor = true;
            this.zoomOutBtn.Click += new System.EventHandler(this.zoomOutBtn_Click);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomInBtn.Location = new System.Drawing.Point(13, 11);
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.Size = new System.Drawing.Size(60, 64);
            this.zoomInBtn.TabIndex = 0;
            this.zoomInBtn.Text = "+";
            this.zoomInBtn.UseVisualStyleBackColor = true;
            this.zoomInBtn.Click += new System.EventHandler(this.zoomInBtn_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.Location = new System.Drawing.Point(435, 388);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(121, 45);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // keyStringLocked
            // 
            this.keyStringLocked.BackColor = System.Drawing.Color.PeachPuff;
            this.keyStringLocked.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyStringLocked.Location = new System.Drawing.Point(201, 22);
            this.keyStringLocked.Name = "keyStringLocked";
            this.keyStringLocked.Size = new System.Drawing.Size(182, 161);
            this.keyStringLocked.TabIndex = 4;
            this.keyStringLocked.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1097, 664);
            this.splitContainer1.SplitterDistance = 491;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.textBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 5);
            this.panel1.Size = new System.Drawing.Size(491, 664);
            this.panel1.TabIndex = 5;
            // 
            // KeyPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 664);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(830, 583);
            this.Name = "KeyPickerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kulcs megadása";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beforeContextNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterContextNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox selectionTextBox;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.RichTextBox keyStringLocked;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button zoomOutBtn;
        private System.Windows.Forms.Button zoomInBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox beforeText;
        private System.Windows.Forms.RichTextBox afterText;
        private System.Windows.Forms.CheckBox isKeyCountBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown beforeContextNum;
        private System.Windows.Forms.NumericUpDown afterContextNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox afterCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox beforeCheckBox;
        private System.Windows.Forms.RichTextBox beforeTextLocked;
        private System.Windows.Forms.RichTextBox afterTextLocked;
    }
}