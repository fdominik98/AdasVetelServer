
namespace AdasVetelServer
{
    partial class AdasVetelServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdasVetelServer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.startBox = new System.Windows.Forms.GroupBox();
            this.domainCheckBox = new System.Windows.Forms.CheckBox();
            this.portNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.startServerBtn = new System.Windows.Forms.Button();
            this.stopBox = new System.Windows.Forms.GroupBox();
            this.stopServerBtn = new System.Windows.Forms.Button();
            this.serverInfo = new System.Windows.Forms.Label();
            this.serverLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.fileFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xmlSelectButton = new System.Windows.Forms.Button();
            this.xmlFileTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clearListButton = new System.Windows.Forms.Button();
            this.contractSelectButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.resetDataBaseBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.startBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).BeginInit();
            this.stopBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 553);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(816, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kezdőlap";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 2);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.clearLogBtn);
            this.splitContainer2.Panel1.Controls.Add(this.startBox);
            this.splitContainer2.Panel1.Controls.Add(this.stopBox);
            this.splitContainer2.Panel1.Controls.Add(this.serverInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.serverLog);
            this.splitContainer2.Size = new System.Drawing.Size(810, 516);
            this.splitContainer2.SplitterDistance = 261;
            this.splitContainer2.TabIndex = 4;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.Location = new System.Drawing.Point(148, 9);
            this.clearLogBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(102, 36);
            this.clearLogBtn.TabIndex = 3;
            this.clearLogBtn.Text = "Log törlése";
            this.clearLogBtn.UseVisualStyleBackColor = true;
            this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
            // 
            // startBox
            // 
            this.startBox.Controls.Add(this.domainCheckBox);
            this.startBox.Controls.Add(this.portNumber);
            this.startBox.Controls.Add(this.label1);
            this.startBox.Controls.Add(this.startServerBtn);
            this.startBox.Location = new System.Drawing.Point(30, 139);
            this.startBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBox.Name = "startBox";
            this.startBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBox.Size = new System.Drawing.Size(177, 242);
            this.startBox.TabIndex = 0;
            this.startBox.TabStop = false;
            // 
            // domainCheckBox
            // 
            this.domainCheckBox.AutoSize = true;
            this.domainCheckBox.Checked = true;
            this.domainCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.domainCheckBox.Location = new System.Drawing.Point(12, 92);
            this.domainCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.domainCheckBox.Name = "domainCheckBox";
            this.domainCheckBox.Size = new System.Drawing.Size(97, 24);
            this.domainCheckBox.TabIndex = 4;
            this.domainCheckBox.Text = "localhost";
            this.domainCheckBox.UseVisualStyleBackColor = true;
            // 
            // portNumber
            // 
            this.portNumber.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portNumber.Location = new System.Drawing.Point(68, 36);
            this.portNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(87, 30);
            this.portNumber.TabIndex = 3;
            this.portNumber.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port:";
            // 
            // startServerBtn
            // 
            this.startServerBtn.Location = new System.Drawing.Point(10, 144);
            this.startServerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(156, 88);
            this.startServerBtn.TabIndex = 0;
            this.startServerBtn.Text = "Szerver indítása";
            this.startServerBtn.UseVisualStyleBackColor = true;
            this.startServerBtn.Click += new System.EventHandler(this.startServer_Click);
            // 
            // stopBox
            // 
            this.stopBox.Controls.Add(this.stopServerBtn);
            this.stopBox.Location = new System.Drawing.Point(40, 400);
            this.stopBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopBox.Name = "stopBox";
            this.stopBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopBox.Size = new System.Drawing.Size(150, 99);
            this.stopBox.TabIndex = 1;
            this.stopBox.TabStop = false;
            // 
            // stopServerBtn
            // 
            this.stopServerBtn.Location = new System.Drawing.Point(12, 24);
            this.stopServerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopServerBtn.Name = "stopServerBtn";
            this.stopServerBtn.Size = new System.Drawing.Size(129, 53);
            this.stopServerBtn.TabIndex = 1;
            this.stopServerBtn.Text = "Leállítás";
            this.stopServerBtn.UseVisualStyleBackColor = true;
            this.stopServerBtn.Click += new System.EventHandler(this.stopServer_Click);
            // 
            // serverInfo
            // 
            this.serverInfo.AutoSize = true;
            this.serverInfo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverInfo.Location = new System.Drawing.Point(25, 71);
            this.serverInfo.Name = "serverInfo";
            this.serverInfo.Size = new System.Drawing.Size(203, 30);
            this.serverInfo.TabIndex = 2;
            this.serverInfo.Text = "A szerver aktív...";
            // 
            // serverLog
            // 
            this.serverLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverLog.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverLog.Location = new System.Drawing.Point(0, 0);
            this.serverLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serverLog.Multiline = true;
            this.serverLog.Name = "serverLog";
            this.serverLog.ReadOnly = true;
            this.serverLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.serverLog.Size = new System.Drawing.Size(545, 516);
            this.serverLog.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(816, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Speciális";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileFlowLayout);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(810, 516);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 7;
            // 
            // fileFlowLayout
            // 
            this.fileFlowLayout.AutoScroll = true;
            this.fileFlowLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.fileFlowLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileFlowLayout.Name = "fileFlowLayout";
            this.fileFlowLayout.Size = new System.Drawing.Size(291, 516);
            this.fileFlowLayout.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 516);
            this.panel1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xmlSelectButton);
            this.groupBox2.Controls.Add(this.xmlFileTextBox);
            this.groupBox2.Location = new System.Drawing.Point(44, 22);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(468, 119);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // xmlSelectButton
            // 
            this.xmlSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlSelectButton.Location = new System.Drawing.Point(341, 62);
            this.xmlSelectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xmlSelectButton.Name = "xmlSelectButton";
            this.xmlSelectButton.Size = new System.Drawing.Size(105, 38);
            this.xmlSelectButton.TabIndex = 2;
            this.xmlSelectButton.Text = "Tallózás";
            this.xmlSelectButton.UseVisualStyleBackColor = true;
            this.xmlSelectButton.Click += new System.EventHandler(this.xmlSelectButton_Click);
            // 
            // xmlFileTextBox
            // 
            this.xmlFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xmlFileTextBox.Location = new System.Drawing.Point(28, 22);
            this.xmlFileTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xmlFileTextBox.Name = "xmlFileTextBox";
            this.xmlFileTextBox.ReadOnly = true;
            this.xmlFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.xmlFileTextBox.Size = new System.Drawing.Size(417, 28);
            this.xmlFileTextBox.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trainButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(206, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(306, 342);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // trainButton
            // 
            this.trainButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trainButton.Enabled = false;
            this.trainButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainButton.Location = new System.Drawing.Point(3, 274);
            this.trainButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(300, 66);
            this.trainButton.TabIndex = 0;
            this.trainButton.Text = "Bevitel";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(300, 319);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clearListButton);
            this.groupBox3.Controls.Add(this.contractSelectButton);
            this.groupBox3.Location = new System.Drawing.Point(18, 348);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(126, 158);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // clearListButton
            // 
            this.clearListButton.Location = new System.Drawing.Point(7, 22);
            this.clearListButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearListButton.Name = "clearListButton";
            this.clearListButton.Size = new System.Drawing.Size(112, 42);
            this.clearListButton.TabIndex = 2;
            this.clearListButton.Text = "Lista törlése";
            this.clearListButton.UseVisualStyleBackColor = true;
            this.clearListButton.Click += new System.EventHandler(this.clearListButton_Click);
            // 
            // contractSelectButton
            // 
            this.contractSelectButton.Location = new System.Drawing.Point(7, 87);
            this.contractSelectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contractSelectButton.Name = "contractSelectButton";
            this.contractSelectButton.Size = new System.Drawing.Size(112, 54);
            this.contractSelectButton.TabIndex = 1;
            this.contractSelectButton.Text = "Tallózás";
            this.contractSelectButton.UseVisualStyleBackColor = true;
            this.contractSelectButton.Click += new System.EventHandler(this.contractSelectButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.resetDataBaseBtn);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(816, 520);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Adatbázis";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // resetDataBaseBtn
            // 
            this.resetDataBaseBtn.BackColor = System.Drawing.Color.IndianRed;
            this.resetDataBaseBtn.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetDataBaseBtn.Location = new System.Drawing.Point(604, 399);
            this.resetDataBaseBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetDataBaseBtn.Name = "resetDataBaseBtn";
            this.resetDataBaseBtn.Size = new System.Drawing.Size(188, 99);
            this.resetDataBaseBtn.TabIndex = 0;
            this.resetDataBaseBtn.Text = "Adatbázis törlése";
            this.resetDataBaseBtn.UseVisualStyleBackColor = false;
            this.resetDataBaseBtn.Click += new System.EventHandler(this.resetDataBaseBtn_Click);
            // 
            // AdasVetelServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 553);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(842, 600);
            this.Name = "AdasVetelServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adás Vétel Szerver";
            this.Load += new System.EventHandler(this.AdasVetelServer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.startBox.ResumeLayout(false);
            this.startBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portNumber)).EndInit();
            this.stopBox.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox stopBox;
        private System.Windows.Forms.Button stopServerBtn;
        private System.Windows.Forms.GroupBox startBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startServerBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox serverLog;
        private System.Windows.Forms.Label serverInfo;
        private System.Windows.Forms.NumericUpDown portNumber;
        private System.Windows.Forms.Button xmlSelectButton;
        private System.Windows.Forms.TextBox xmlFileTextBox;
        private System.Windows.Forms.FlowLayoutPanel fileFlowLayout;
        private System.Windows.Forms.Button contractSelectButton;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox domainCheckBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button resetDataBaseBtn;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearListButton;
    }
}

