namespace InhaTT_Creator
{
    partial class frmTTViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTViewer));
            this.lvTable = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bLeft = new System.Windows.Forms.Button();
            this.bRight = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
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
            this.lvTable.Location = new System.Drawing.Point(12, 12);
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size(1067, 601);
            this.lvTable.TabIndex = 5;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvTable_KeyDown);
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
            // bLeft
            // 
            this.bLeft.Enabled = false;
            this.bLeft.Location = new System.Drawing.Point(400, 813);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(83, 29);
            this.bLeft.TabIndex = 6;
            this.bLeft.Text = "<--";
            this.bLeft.UseVisualStyleBackColor = true;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // bRight
            // 
            this.bRight.Location = new System.Drawing.Point(618, 813);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(83, 29);
            this.bRight.TabIndex = 7;
            this.bRight.Text = "-->";
            this.bRight.UseVisualStyleBackColor = true;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
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
            this.lvSearch.Location = new System.Drawing.Point(12, 619);
            this.lvSearch.Name = "lvSearch";
            this.lvSearch.Size = new System.Drawing.Size(1067, 188);
            this.lvSearch.TabIndex = 8;
            this.lvSearch.UseCompatibleStateImageBehavior = false;
            this.lvSearch.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "인덱스";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "필드";
            this.columnHeader1.Width = 128;
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
            // frmTTViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 850);
            this.Controls.Add(this.lvSearch);
            this.Controls.Add(this.bRight);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.lvTable);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTTViewer";
            this.Text = "시간표 뷰어";
            this.Load += new System.EventHandler(this.frmTTViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.Button bRight;
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
    }
}