namespace InhaTT
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbbSearchType = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvSearchAdd = new System.Windows.Forms.ListView();
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.bList = new System.Windows.Forms.Button();
            this.bMenu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bPull = new System.Windows.Forms.Button();
            this.bPush = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.lvTable = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
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
            this.lvSearch.Location = new System.Drawing.Point(6, 35);
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.Size = new System.Drawing.Size(1047, 188);
            this.lvSearch.TabIndex = 0;
            this.lvSearch.UseCompatibleStateImageBehavior = false;
            this.lvSearch.View = System.Windows.Forms.View.Details;
            this.lvSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSearch_ColumnClick);
            this.lvSearch.SelectedIndexChanged += new System.EventHandler(this.lvSearch_SelectedIndexChanged);
            this.lvSearch.DoubleClick += new System.EventHandler(this.lvSearch_DoubleClick);
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
            this.columnHeader8.Width = 122;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 257);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbSearch);
            this.tabPage1.Controls.Add(this.lvSearch);
            this.tabPage1.Controls.Add(this.cbbSearchType);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1059, 229);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "검색";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Location = new System.Drawing.Point(103, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(950, 23);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // cbbSearchType
            // 
            this.cbbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchType.FormattingEnabled = true;
            this.cbbSearchType.Items.AddRange(new object[] {
            "과목명",
            "교수",
            "필드",
            "학수번호"});
            this.cbbSearchType.Location = new System.Drawing.Point(6, 6);
            this.cbbSearchType.Name = "cbbSearchType";
            this.cbbSearchType.Size = new System.Drawing.Size(91, 23);
            this.cbbSearchType.TabIndex = 0;
            this.cbbSearchType.SelectedIndexChanged += new System.EventHandler(this.cbbSearchType_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvSearchAdd);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1059, 229);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "추가됨";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvSearchAdd
            // 
            this.lvSearchAdd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader12,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30});
            this.lvSearchAdd.FullRowSelect = true;
            this.lvSearchAdd.GridLines = true;
            this.lvSearchAdd.Location = new System.Drawing.Point(6, 6);
            this.lvSearchAdd.Name = "lvSearchAdd";
            this.lvSearchAdd.Size = new System.Drawing.Size(1047, 217);
            this.lvSearchAdd.TabIndex = 1;
            this.lvSearchAdd.UseCompatibleStateImageBehavior = false;
            this.lvSearchAdd.View = System.Windows.Forms.View.Details;
            this.lvSearchAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvSearchAdd_KeyDown);
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "인덱스";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "필드";
            this.columnHeader20.Width = 107;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "학수번호";
            this.columnHeader21.Width = 101;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "분반";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "과목명";
            this.columnHeader23.Width = 164;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "학년";
            this.columnHeader24.Width = 48;
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "학점";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "구분";
            this.columnHeader26.Width = 90;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "시간 및 강의실";
            this.columnHeader27.Width = 122;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "교수";
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "평가방식";
            this.columnHeader29.Width = 83;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "비고";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.bList);
            this.tabPage2.Controls.Add(this.bMenu);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.bPull);
            this.tabPage2.Controls.Add(this.bPush);
            this.tabPage2.Controls.Add(this.bCreate);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1059, 229);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "도구";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Copyright (C) 2017. rollrat. All Rights Reserved.";
            // 
            // bList
            // 
            this.bList.Enabled = false;
            this.bList.Location = new System.Drawing.Point(175, 28);
            this.bList.Name = "bList";
            this.bList.Size = new System.Drawing.Size(141, 33);
            this.bList.TabIndex = 6;
            this.bList.Text = "시간표 리스트";
            this.bList.UseVisualStyleBackColor = true;
            this.bList.Click += new System.EventHandler(this.bList_Click);
            // 
            // bMenu
            // 
            this.bMenu.Location = new System.Drawing.Point(28, 161);
            this.bMenu.Name = "bMenu";
            this.bMenu.Size = new System.Drawing.Size(141, 33);
            this.bMenu.TabIndex = 5;
            this.bMenu.Text = "설명서";
            this.bMenu.UseVisualStyleBackColor = true;
            this.bMenu.Click += new System.EventHandler(this.bMenu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(542, 90);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // bPull
            // 
            this.bPull.Enabled = false;
            this.bPull.Location = new System.Drawing.Point(175, 93);
            this.bPull.Name = "bPull";
            this.bPull.Size = new System.Drawing.Size(141, 33);
            this.bPull.TabIndex = 3;
            this.bPull.Text = "시간표 가져오기";
            this.bPull.UseVisualStyleBackColor = true;
            // 
            // bPush
            // 
            this.bPush.Enabled = false;
            this.bPush.Location = new System.Drawing.Point(28, 93);
            this.bPush.Name = "bPush";
            this.bPush.Size = new System.Drawing.Size(141, 33);
            this.bPush.TabIndex = 1;
            this.bPush.Text = "시간표 내보내기";
            this.bPush.UseVisualStyleBackColor = true;
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(28, 28);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(141, 33);
            this.bCreate.TabIndex = 0;
            this.bCreate.Text = "시간표 생성기";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // lvTable
            // 
            this.lvTable.BackColor = System.Drawing.SystemColors.Window;
            this.lvTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.lvTable.GridLines = true;
            this.lvTable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTable.Location = new System.Drawing.Point(12, 275);
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size(1067, 503);
            this.lvTable.TabIndex = 4;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvTable_ColumnWidthChanging);
            // 
            // columnHeader18
            // 
            this.columnHeader18.Width = 0;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "교시";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader19.Width = 146;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "월요일";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 184;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "화요일";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 184;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "수요일";
            this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader15.Width = 184;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "목요일";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 184;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "금요일";
            this.columnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader17.Width = 184;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 792);
            this.Controls.Add(this.lvTable);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "InhaTimeTable Manager ";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSearch;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbbSearchType;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.ListView lvSearchAdd;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader25;
        private System.Windows.Forms.ColumnHeader columnHeader26;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ColumnHeader columnHeader30;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button bPush;
        private System.Windows.Forms.Button bPull;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bMenu;
        private System.Windows.Forms.Button bList;
        private System.Windows.Forms.Label label1;
    }
}

