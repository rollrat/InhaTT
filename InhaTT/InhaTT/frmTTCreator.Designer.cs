﻿namespace InhaTT
{
    partial class frmTTCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTCreator));
            this.tbSearch = new System.Windows.Forms.TextBox();
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
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bDel1 = new System.Windows.Forms.Button();
            this.bDel2 = new System.Windows.Forms.Button();
            this.bDel4 = new System.Windows.Forms.Button();
            this.bDel3 = new System.Windows.Forms.Button();
            this.bDel5 = new System.Windows.Forms.Button();
            this.numClass = new System.Windows.Forms.NumericUpDown();
            this.bDelClass = new System.Windows.Forms.Button();
            this.bFix = new System.Windows.Forms.Button();
            this.bDel9 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numClass)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbSearch.Location = new System.Drawing.Point(109, 12);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(1034, 23);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
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
            this.lvSearch.Location = new System.Drawing.Point(12, 41);
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.Size = new System.Drawing.Size(1131, 520);
            this.lvSearch.TabIndex = 3;
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
            // cbSearch
            // 
            this.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "과목명",
            "학수번호"});
            this.cbSearch.Location = new System.Drawing.Point(12, 12);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(91, 23);
            this.cbSearch.TabIndex = 4;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(1018, 567);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(125, 28);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "생성시작";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bDel1
            // 
            this.bDel1.Location = new System.Drawing.Point(12, 567);
            this.bDel1.Name = "bDel1";
            this.bDel1.Size = new System.Drawing.Size(78, 28);
            this.bDel1.TabIndex = 6;
            this.bDel1.Text = "월삭";
            this.bDel1.UseVisualStyleBackColor = true;
            this.bDel1.Click += new System.EventHandler(this.bDel1_Click);
            // 
            // bDel2
            // 
            this.bDel2.Location = new System.Drawing.Point(96, 567);
            this.bDel2.Name = "bDel2";
            this.bDel2.Size = new System.Drawing.Size(78, 28);
            this.bDel2.TabIndex = 7;
            this.bDel2.Text = "화삭";
            this.bDel2.UseVisualStyleBackColor = true;
            this.bDel2.Click += new System.EventHandler(this.bDel2_Click);
            // 
            // bDel4
            // 
            this.bDel4.Location = new System.Drawing.Point(264, 567);
            this.bDel4.Name = "bDel4";
            this.bDel4.Size = new System.Drawing.Size(78, 28);
            this.bDel4.TabIndex = 9;
            this.bDel4.Text = "목삭";
            this.bDel4.UseVisualStyleBackColor = true;
            this.bDel4.Click += new System.EventHandler(this.bDel4_Click);
            // 
            // bDel3
            // 
            this.bDel3.Location = new System.Drawing.Point(180, 567);
            this.bDel3.Name = "bDel3";
            this.bDel3.Size = new System.Drawing.Size(78, 28);
            this.bDel3.TabIndex = 8;
            this.bDel3.Text = "수삭";
            this.bDel3.UseVisualStyleBackColor = true;
            this.bDel3.Click += new System.EventHandler(this.bDel3_Click);
            // 
            // bDel5
            // 
            this.bDel5.Location = new System.Drawing.Point(348, 567);
            this.bDel5.Name = "bDel5";
            this.bDel5.Size = new System.Drawing.Size(78, 28);
            this.bDel5.TabIndex = 10;
            this.bDel5.Text = "금삭";
            this.bDel5.UseVisualStyleBackColor = true;
            this.bDel5.Click += new System.EventHandler(this.bDel5_Click);
            // 
            // numClass
            // 
            this.numClass.Location = new System.Drawing.Point(473, 569);
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
            this.numClass.TabIndex = 20;
            this.numClass.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bDelClass
            // 
            this.bDelClass.Location = new System.Drawing.Point(557, 567);
            this.bDelClass.Name = "bDelClass";
            this.bDelClass.Size = new System.Drawing.Size(78, 28);
            this.bDelClass.TabIndex = 21;
            this.bDelClass.Text = "교시 삭제";
            this.bDelClass.UseVisualStyleBackColor = true;
            this.bDelClass.Click += new System.EventHandler(this.bDelClass_Click);
            // 
            // bFix
            // 
            this.bFix.Location = new System.Drawing.Point(701, 567);
            this.bFix.Name = "bFix";
            this.bFix.Size = new System.Drawing.Size(78, 28);
            this.bFix.TabIndex = 22;
            this.bFix.Text = "남김";
            this.bFix.UseVisualStyleBackColor = true;
            this.bFix.Click += new System.EventHandler(this.bFix_Click);
            // 
            // bDel9
            // 
            this.bDel9.Location = new System.Drawing.Point(785, 567);
            this.bDel9.Name = "bDel9";
            this.bDel9.Size = new System.Drawing.Size(78, 28);
            this.bDel9.TabIndex = 23;
            this.bDel9.Text = "과목삭제";
            this.bDel9.UseVisualStyleBackColor = true;
            this.bDel9.Click += new System.EventHandler(this.bDel9_Click);
            // 
            // frmTTCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 602);
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
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTTCreator";
            this.Text = "시간표 생성기";
            this.Load += new System.EventHandler(this.frmTTCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSearch;
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
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bDel1;
        private System.Windows.Forms.Button bDel2;
        private System.Windows.Forms.Button bDel4;
        private System.Windows.Forms.Button bDel3;
        private System.Windows.Forms.Button bDel5;
        private System.Windows.Forms.NumericUpDown numClass;
        private System.Windows.Forms.Button bDelClass;
        private System.Windows.Forms.Button bFix;
        private System.Windows.Forms.Button bDel9;
    }
}