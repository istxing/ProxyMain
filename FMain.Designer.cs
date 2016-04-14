namespace ProxyMain
{
    partial class FMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelIp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBADFilter = new System.Windows.Forms.CheckBox();
            this.cBCustomFilter = new System.Windows.Forms.CheckBox();
            this.listBoxRequest = new System.Windows.Forms.ListBox();
            this.checkedListBoxFilter = new System.Windows.Forms.CheckedListBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonFilterAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxTxt = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBoxBlock = new System.Windows.Forms.ListBox();
            this.fBDFilter = new System.Windows.Forms.FolderBrowserDialog();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.AutoSize = true;
            this.panelTop.BackColor = System.Drawing.Color.Teal;
            this.panelTop.Controls.Add(this.labelIp);
            this.panelTop.Controls.Add(this.panel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTop.MaximumSize = new System.Drawing.Size(0, 40);
            this.panelTop.MinimumSize = new System.Drawing.Size(0, 50);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(994, 50);
            this.panelTop.TabIndex = 0;
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIp.Location = new System.Drawing.Point(12, 17);
            this.labelIp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(0, 21);
            this.labelIp.TabIndex = 1;
            this.labelIp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cBADFilter);
            this.panel1.Controls.Add(this.cBCustomFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(449, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 50);
            this.panel1.TabIndex = 2;
            // 
            // cBADFilter
            // 
            this.cBADFilter.AutoSize = true;
            this.cBADFilter.Location = new System.Drawing.Point(139, 15);
            this.cBADFilter.Name = "cBADFilter";
            this.cBADFilter.Size = new System.Drawing.Size(93, 25);
            this.cBADFilter.TabIndex = 4;
            this.cBADFilter.Text = "广告过虑";
            this.cBADFilter.UseVisualStyleBackColor = true;
            // 
            // cBCustomFilter
            // 
            this.cBCustomFilter.AutoSize = true;
            this.cBCustomFilter.Location = new System.Drawing.Point(0, 15);
            this.cBCustomFilter.Name = "cBCustomFilter";
            this.cBCustomFilter.Size = new System.Drawing.Size(109, 25);
            this.cBCustomFilter.TabIndex = 3;
            this.cBCustomFilter.Text = "自定义过虑";
            this.cBCustomFilter.UseVisualStyleBackColor = true;
            // 
            // listBoxRequest
            // 
            this.listBoxRequest.BackColor = System.Drawing.Color.White;
            this.listBoxRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRequest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxRequest.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxRequest.ForeColor = System.Drawing.Color.Teal;
            this.listBoxRequest.FormattingEnabled = true;
            this.listBoxRequest.ItemHeight = 26;
            this.listBoxRequest.Location = new System.Drawing.Point(3, 3);
            this.listBoxRequest.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.listBoxRequest.MinimumSize = new System.Drawing.Size(200, 0);
            this.listBoxRequest.Name = "listBoxRequest";
            this.listBoxRequest.Size = new System.Drawing.Size(405, 471);
            this.listBoxRequest.TabIndex = 1;
            this.listBoxRequest.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxRequest_DrawItem);
            this.listBoxRequest.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBoxRequest_MeasureItem);
            this.listBoxRequest.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxRequest_KeyUp);
            this.listBoxRequest.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxRequest_MouseDoubleClick);
            // 
            // checkedListBoxFilter
            // 
            this.checkedListBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkedListBoxFilter.FormattingEnabled = true;
            this.checkedListBoxFilter.Items.AddRange(new object[] {
            ".css",
            ".js",
            ".png",
            ".jpeg",
            ".jpg",
            ".gif",
            ".swf"});
            this.checkedListBoxFilter.Location = new System.Drawing.Point(3, 25);
            this.checkedListBoxFilter.MultiColumn = true;
            this.checkedListBoxFilter.Name = "checkedListBoxFilter";
            this.checkedListBoxFilter.Size = new System.Drawing.Size(529, 288);
            this.checkedListBoxFilter.TabIndex = 2;
            this.checkedListBoxFilter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBoxFilter_MouseDown);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.groupBox1);
            this.panelRight.Controls.Add(this.panel2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(449, 50);
            this.panelRight.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(0, 20, 10, 10);
            this.panelRight.Size = new System.Drawing.Size(545, 541);
            this.panelRight.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkedListBoxFilter);
            this.groupBox1.Controls.Add(this.textBoxFilter);
            this.groupBox1.Controls.Add(this.buttonFilterAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 392);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义过虑";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(7, 348);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(424, 29);
            this.textBoxFilter.TabIndex = 1;
            this.textBoxFilter.WordWrap = false;
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.BackColor = System.Drawing.Color.White;
            this.buttonFilterAdd.FlatAppearance.BorderSize = 0;
            this.buttonFilterAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonFilterAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonFilterAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFilterAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonFilterAdd.Location = new System.Drawing.Point(450, 346);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(79, 30);
            this.buttonFilterAdd.TabIndex = 2;
            this.buttonFilterAdd.Text = "添加";
            this.buttonFilterAdd.UseCompatibleTextRendering = true;
            this.buttonFilterAdd.UseVisualStyleBackColor = false;
            this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 412);
            this.panel2.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 119);
            this.panel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxTxt);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 104);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "广告过虑";
            // 
            // listBoxTxt
            // 
            this.listBoxTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxTxt.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxTxt.FormattingEnabled = true;
            this.listBoxTxt.ItemHeight = 21;
            this.listBoxTxt.Items.AddRange(new object[] {
            "ad.txt"});
            this.listBoxTxt.Location = new System.Drawing.Point(3, 25);
            this.listBoxTxt.Name = "listBoxTxt";
            this.listBoxTxt.Size = new System.Drawing.Size(529, 63);
            this.listBoxTxt.TabIndex = 0;
            this.listBoxTxt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxTxt_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 20, 20, 10);
            this.panel3.Size = new System.Drawing.Size(449, 541);
            this.panel3.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 511);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxRequest);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(411, 477);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "请求网址";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBoxBlock);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(411, 477);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "过滤列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBoxBlock
            // 
            this.listBoxBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxBlock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxBlock.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxBlock.ForeColor = System.Drawing.Color.LightCoral;
            this.listBoxBlock.FormattingEnabled = true;
            this.listBoxBlock.ItemHeight = 19;
            this.listBoxBlock.Location = new System.Drawing.Point(3, 3);
            this.listBoxBlock.Name = "listBoxBlock";
            this.listBoxBlock.Size = new System.Drawing.Size(405, 471);
            this.listBoxBlock.TabIndex = 0;
            this.listBoxBlock.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxBlock_KeyUp);
            this.listBoxBlock.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxBlock_MouseDoubleClick);
            // 
            // fBDFilter
            // 
            this.fBDFilter.RootFolder = System.Environment.SpecialFolder.ApplicationData;
            this.fBDFilter.ShowNewFolderButton = false;
            // 
            // FMain
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(994, 591);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1010, 630);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络代理测试工具";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilter;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonFilterAdd;
        private System.Windows.Forms.ListBox listBoxRequest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox cBCustomFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FolderBrowserDialog fBDFilter;
        private System.Windows.Forms.CheckBox cBADFilter;
        private System.Windows.Forms.ListBox listBoxTxt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBoxBlock;


    }
}
