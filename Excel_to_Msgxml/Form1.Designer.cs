namespace Excel_to_Msgxml
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.executePanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.outputHintLabel = new System.Windows.Forms.Label();
            this.file_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.rowHintLabel = new System.Windows.Forms.Label();
            this.columnHintLabel = new System.Windows.Forms.Label();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.columnTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.settingsTitleLabel = new System.Windows.Forms.Label();
            this.filePanel = new System.Windows.Forms.Panel();
            this.fileHintLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.stepLabel = new System.Windows.Forms.Label();
            this.footerLabel = new System.Windows.Forms.Label();
            this.headerPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.executePanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.filePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(760, 108);
            this.headerPanel.TabIndex = 0;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(209, 213, 219);
            this.subtitleLabel.Location = new System.Drawing.Point(36, 66);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(309, 18);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "將 Excel 多語系內容快速轉換為 MSGXML 格式";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(32, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(314, 35);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Excel → MSGXML 轉換工具";
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.mainPanel.Controls.Add(this.executePanel);
            this.mainPanel.Controls.Add(this.settingsPanel);
            this.mainPanel.Controls.Add(this.filePanel);
            this.mainPanel.Controls.Add(this.footerLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 108);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(36, 28, 36, 24);
            this.mainPanel.Size = new System.Drawing.Size(760, 472);
            this.mainPanel.TabIndex = 1;
            // 
            // executePanel
            // 
            this.executePanel.BackColor = System.Drawing.Color.White;
            this.executePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.executePanel.Controls.Add(this.button2);
            this.executePanel.Controls.Add(this.outputHintLabel);
            this.executePanel.Controls.Add(this.file_name);
            this.executePanel.Controls.Add(this.label1);
            this.executePanel.Location = new System.Drawing.Point(36, 286);
            this.executePanel.Name = "executePanel";
            this.executePanel.Size = new System.Drawing.Size(688, 126);
            this.executePanel.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(514, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "開始轉換";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.execute);
            // 
            // outputHintLabel
            // 
            this.outputHintLabel.AutoSize = true;
            this.outputHintLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.outputHintLabel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.outputHintLabel.Location = new System.Drawing.Point(31, 83);
            this.outputHintLabel.Name = "outputHintLabel";
            this.outputHintLabel.Size = new System.Drawing.Size(272, 16);
            this.outputHintLabel.TabIndex = 2;
            this.outputHintLabel.Text = "程式會自動產生「_description.msgxml」檔案";
            // 
            // file_name
            // 
            this.file_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.file_name.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F);
            this.file_name.Location = new System.Drawing.Point(151, 37);
            this.file_name.Name = "file_name";
            this.file_name.Size = new System.Drawing.Size(330, 27);
            this.file_name.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "輸出檔案名稱";
            // 
            // settingsPanel
            // 
            this.settingsPanel.BackColor = System.Drawing.Color.White;
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.rowHintLabel);
            this.settingsPanel.Controls.Add(this.columnHintLabel);
            this.settingsPanel.Controls.Add(this.rowTextBox);
            this.settingsPanel.Controls.Add(this.columnTextBox);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.settingsTitleLabel);
            this.settingsPanel.Location = new System.Drawing.Point(36, 142);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(688, 126);
            this.settingsPanel.TabIndex = 1;
            // 
            // rowHintLabel
            // 
            this.rowHintLabel.AutoSize = true;
            this.rowHintLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.rowHintLabel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.rowHintLabel.Location = new System.Drawing.Point(454, 82);
            this.rowHintLabel.Name = "rowHintLabel";
            this.rowHintLabel.Size = new System.Drawing.Size(79, 16);
            this.rowHintLabel.TabIndex = 6;
            this.rowHintLabel.Text = "例如：第 2 列";
            // 
            // columnHintLabel
            // 
            this.columnHintLabel.AutoSize = true;
            this.columnHintLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.columnHintLabel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.columnHintLabel.Location = new System.Drawing.Point(124, 82);
            this.columnHintLabel.Name = "columnHintLabel";
            this.columnHintLabel.Size = new System.Drawing.Size(130, 16);
            this.columnHintLabel.TabIndex = 5;
            this.columnHintLabel.Text = "A 欄輸入 1，B 欄輸入 2";
            // 
            // rowTextBox
            // 
            this.rowTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rowTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F);
            this.rowTextBox.Location = new System.Drawing.Point(457, 47);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(92, 27);
            this.rowTextBox.TabIndex = 1;
            this.rowTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnTextBox
            // 
            this.columnTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.columnTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F);
            this.columnTextBox.Location = new System.Drawing.Point(127, 47);
            this.columnTextBox.Name = "columnTextBox";
            this.columnTextBox.Size = new System.Drawing.Size(92, 27);
            this.columnTextBox.TabIndex = 0;
            this.columnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.label3.Location = new System.Drawing.Point(354, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "起始列號";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.label2.Location = new System.Drawing.Point(30, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "讀取欄號";
            // 
            // settingsTitleLabel
            // 
            this.settingsTitleLabel.AutoSize = true;
            this.settingsTitleLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.settingsTitleLabel.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.settingsTitleLabel.Location = new System.Drawing.Point(29, 17);
            this.settingsTitleLabel.Name = "settingsTitleLabel";
            this.settingsTitleLabel.Size = new System.Drawing.Size(80, 16);
            this.settingsTitleLabel.TabIndex = 0;
            this.settingsTitleLabel.Text = "② 設定範圍";
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.Color.White;
            this.filePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filePanel.Controls.Add(this.fileHintLabel);
            this.filePanel.Controls.Add(this.button1);
            this.filePanel.Controls.Add(this.stepLabel);
            this.filePanel.Location = new System.Drawing.Point(36, 28);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(688, 96);
            this.filePanel.TabIndex = 0;
            // 
            // fileHintLabel
            // 
            this.fileHintLabel.AutoSize = true;
            this.fileHintLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.fileHintLabel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.fileHintLabel.Location = new System.Drawing.Point(30, 54);
            this.fileHintLabel.Name = "fileHintLabel";
            this.fileHintLabel.Size = new System.Drawing.Size(261, 16);
            this.fileHintLabel.TabIndex = 2;
            this.fileHintLabel.Text = "支援 .xlsx，並依工作表讀取繁中、英文與簡中";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.button1.Location = new System.Drawing.Point(514, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "選擇 Excel 檔案";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.open_file);
            // 
            // stepLabel
            // 
            this.stepLabel.AutoSize = true;
            this.stepLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.stepLabel.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.stepLabel.Location = new System.Drawing.Point(29, 22);
            this.stepLabel.Name = "stepLabel";
            this.stepLabel.Size = new System.Drawing.Size(104, 16);
            this.stepLabel.TabIndex = 0;
            this.stepLabel.Text = "① 選擇來源檔案";
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.5F);
            this.footerLabel.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.footerLabel.Location = new System.Drawing.Point(38, 432);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(388, 15);
            this.footerLabel.TabIndex = 3;
            this.footerLabel.Text = "輸出位置：程式執行檔所在資料夾　｜　範本檔：empty.msgxml";
            // 
            // Form1
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(760, 580);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(776, 619);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel to MSGXML Converter";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.executePanel.ResumeLayout(false);
            this.executePanel.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.filePanel.ResumeLayout(false);
            this.filePanel.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subtitleLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Label stepLabel;
        private System.Windows.Forms.Label fileHintLabel;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Label settingsTitleLabel;
        private System.Windows.Forms.Label columnHintLabel;
        private System.Windows.Forms.Label rowHintLabel;
        private System.Windows.Forms.Panel executePanel;
        private System.Windows.Forms.Label outputHintLabel;
        private System.Windows.Forms.Label footerLabel;
        private System.Windows.Forms.TextBox file_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox columnTextBox;
        private System.Windows.Forms.TextBox rowTextBox;
    }
}
