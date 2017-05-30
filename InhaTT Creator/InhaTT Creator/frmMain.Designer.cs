namespace InhaTT_Creator
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.생성된시간표ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도구TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.과목분석기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.도움말HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설명서ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDel9 = new System.Windows.Forms.Button();
            this.bFix = new System.Windows.Forms.Button();
            this.bDelClass = new System.Windows.Forms.Button();
            this.numClass = new System.Windows.Forms.NumericUpDown();
            this.bDel5 = new System.Windows.Forms.Button();
            this.bDel4 = new System.Windows.Forms.Button();
            this.bDel3 = new System.Windows.Forms.Button();
            this.bDel2 = new System.Windows.Forms.Button();
            this.bDel1 = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lvSearch = new System.Windows.Forms.ListView();
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.정보IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClass)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.보기ToolStripMenuItem,
            this.도구TToolStripMenuItem,
            this.도움말HToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 보기ToolStripMenuItem
            // 
            this.보기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.생성된시간표ToolStripMenuItem});
            this.보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            this.보기ToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.보기ToolStripMenuItem.Text = "보기(&V)";
            // 
            // 생성된시간표ToolStripMenuItem
            // 
            this.생성된시간표ToolStripMenuItem.Name = "생성된시간표ToolStripMenuItem";
            this.생성된시간표ToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.생성된시간표ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.생성된시간표ToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.생성된시간표ToolStripMenuItem.Text = "생성된 시간표";
            this.생성된시간표ToolStripMenuItem.Click += new System.EventHandler(this.생성된시간표ToolStripMenuItem_Click);
            // 
            // 도구TToolStripMenuItem
            // 
            this.도구TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.과목분석기ToolStripMenuItem});
            this.도구TToolStripMenuItem.Name = "도구TToolStripMenuItem";
            this.도구TToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.도구TToolStripMenuItem.Text = "도구(&T)";
            // 
            // 과목분석기ToolStripMenuItem
            // 
            this.과목분석기ToolStripMenuItem.Name = "과목분석기ToolStripMenuItem";
            this.과목분석기ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.과목분석기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.과목분석기ToolStripMenuItem.Text = "과목 분석기";
            this.과목분석기ToolStripMenuItem.Click += new System.EventHandler(this.과목분석기ToolStripMenuItem_Click);
            // 
            // 도움말HToolStripMenuItem
            // 
            this.도움말HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.설명서ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.정보IToolStripMenuItem});
            this.도움말HToolStripMenuItem.Name = "도움말HToolStripMenuItem";
            this.도움말HToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.도움말HToolStripMenuItem.Text = "도움말(&H)";
            // 
            // 설명서ToolStripMenuItem
            // 
            this.설명서ToolStripMenuItem.Name = "설명서ToolStripMenuItem";
            this.설명서ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.설명서ToolStripMenuItem.Text = "설명서(&M)";
            this.설명서ToolStripMenuItem.Click += new System.EventHandler(this.설명서ToolStripMenuItem_Click);
            // 
            // bDel9
            // 
            this.bDel9.Location = new System.Drawing.Point(785, 587);
            this.bDel9.Name = "bDel9";
            this.bDel9.Size = new System.Drawing.Size(78, 28);
            this.bDel9.TabIndex = 36;
            this.bDel9.Text = "과목삭제";
            this.bDel9.UseVisualStyleBackColor = true;
            this.bDel9.Click += new System.EventHandler(this.bDel9_Click);
            // 
            // bFix
            // 
            this.bFix.Location = new System.Drawing.Point(701, 587);
            this.bFix.Name = "bFix";
            this.bFix.Size = new System.Drawing.Size(78, 28);
            this.bFix.TabIndex = 35;
            this.bFix.Text = "남김";
            this.bFix.UseVisualStyleBackColor = true;
            this.bFix.Click += new System.EventHandler(this.bFix_Click);
            // 
            // bDelClass
            // 
            this.bDelClass.Location = new System.Drawing.Point(557, 587);
            this.bDelClass.Name = "bDelClass";
            this.bDelClass.Size = new System.Drawing.Size(78, 28);
            this.bDelClass.TabIndex = 34;
            this.bDelClass.Text = "교시 삭제";
            this.bDelClass.UseVisualStyleBackColor = true;
            this.bDelClass.Click += new System.EventHandler(this.bDelClass_Click);
            // 
            // numClass
            // 
            this.numClass.Location = new System.Drawing.Point(473, 589);
            this.numClass.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numClass.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numClass.Name = "numClass";
            this.numClass.Size = new System.Drawing.Size(78, 23);
            this.numClass.TabIndex = 33;
            this.numClass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bDel5
            // 
            this.bDel5.Location = new System.Drawing.Point(348, 587);
            this.bDel5.Name = "bDel5";
            this.bDel5.Size = new System.Drawing.Size(78, 28);
            this.bDel5.TabIndex = 32;
            this.bDel5.Text = "금삭";
            this.bDel5.UseVisualStyleBackColor = true;
            this.bDel5.Click += new System.EventHandler(this.bDel5_Click);
            // 
            // bDel4
            // 
            this.bDel4.Location = new System.Drawing.Point(264, 587);
            this.bDel4.Name = "bDel4";
            this.bDel4.Size = new System.Drawing.Size(78, 28);
            this.bDel4.TabIndex = 31;
            this.bDel4.Text = "목삭";
            this.bDel4.UseVisualStyleBackColor = true;
            this.bDel4.Click += new System.EventHandler(this.bDel4_Click);
            // 
            // bDel3
            // 
            this.bDel3.Location = new System.Drawing.Point(180, 587);
            this.bDel3.Name = "bDel3";
            this.bDel3.Size = new System.Drawing.Size(78, 28);
            this.bDel3.TabIndex = 30;
            this.bDel3.Text = "수삭";
            this.bDel3.UseVisualStyleBackColor = true;
            this.bDel3.Click += new System.EventHandler(this.bDel3_Click);
            // 
            // bDel2
            // 
            this.bDel2.Location = new System.Drawing.Point(96, 587);
            this.bDel2.Name = "bDel2";
            this.bDel2.Size = new System.Drawing.Size(78, 28);
            this.bDel2.TabIndex = 29;
            this.bDel2.Text = "화삭";
            this.bDel2.UseVisualStyleBackColor = true;
            this.bDel2.Click += new System.EventHandler(this.bDel2_Click);
            // 
            // bDel1
            // 
            this.bDel1.Location = new System.Drawing.Point(12, 587);
            this.bDel1.Name = "bDel1";
            this.bDel1.Size = new System.Drawing.Size(78, 28);
            this.bDel1.TabIndex = 28;
            this.bDel1.Text = "월삭";
            this.bDel1.UseVisualStyleBackColor = true;
            this.bDel1.Click += new System.EventHandler(this.bDel1_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(1018, 587);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(125, 28);
            this.bStart.TabIndex = 27;
            this.bStart.Text = "생성시작";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "과목명",
            "학수번호"});
            this.cbSearch.Location = new System.Drawing.Point(12, 32);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(91, 23);
            this.cbSearch.TabIndex = 26;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lvSearch
            // 
            this.lvSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader31,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvSearch.FullRowSelect = true;
            this.lvSearch.GridLines = true;
            this.lvSearch.Location = new System.Drawing.Point(12, 61);
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.Size = new System.Drawing.Size(1131, 520);
            this.lvSearch.TabIndex = 25;
            this.lvSearch.UseCompatibleStateImageBehavior = false;
            this.lvSearch.View = System.Windows.Forms.View.Details;
            this.lvSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSearch_ColumnClick);
            this.lvSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSearch_KeyDown);
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "인덱스";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "필드";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "학수번호";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "분반";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "과목명";
            this.columnHeader4.Width = 164;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "학년";
            this.columnHeader5.Width = 48;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "학점";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "구분";
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "시간 및 강의실";
            this.columnHeader8.Width = 201;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "교수";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "평가방식";
            this.columnHeader10.Width = 83;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "비고";
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Location = new System.Drawing.Point(109, 32);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(1034, 23);
            this.tbSearch.TabIndex = 24;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // 정보IToolStripMenuItem
            // 
            this.정보IToolStripMenuItem.Name = "정보IToolStripMenuItem";
            this.정보IToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.정보IToolStripMenuItem.Text = "정보(&I)";
            this.정보IToolStripMenuItem.Click += new System.EventHandler(this.정보IToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 623);
            this.Controls.Add(this.bDel9);
            this.Controls.Add(this.bFix);
            this.Controls.Add(this.bDelClass);
            this.Controls.Add(this.numClass);
            this.Controls.Add(this.bDel5);
            this.Controls.Add(this.bDel4);
            this.Controls.Add(this.bDel3);
            this.Controls.Add(this.bDel2);
            this.Controls.Add(this.bDel1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.lvSearch);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "InhaTimeTable Creator ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button bDel9;
        private System.Windows.Forms.Button bFix;
        private System.Windows.Forms.Button bDelClass;
        private System.Windows.Forms.NumericUpDown numClass;
        private System.Windows.Forms.Button bDel5;
        private System.Windows.Forms.Button bDel4;
        private System.Windows.Forms.Button bDel3;
        private System.Windows.Forms.Button bDel2;
        private System.Windows.Forms.Button bDel1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.ListView lvSearch;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ToolStripMenuItem 보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도움말HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 도구TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 생성된시간표ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 과목분석기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설명서ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 정보IToolStripMenuItem;
    }
}

