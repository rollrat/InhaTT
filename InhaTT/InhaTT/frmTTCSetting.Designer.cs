namespace InhaTT
{
    partial class frmTTCSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTTCSetting));
            this.pgSet = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pgSet
            // 
            this.pgSet.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.pgSet.Location = new System.Drawing.Point(12, 12);
            this.pgSet.Name = "pgSet";
            this.pgSet.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.pgSet.Size = new System.Drawing.Size(405, 426);
            this.pgSet.TabIndex = 0;
            // 
            // frmTTCSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.pgSet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTTCSetting";
            this.Text = "생성기 설정";
            this.Load += new System.EventHandler(this.frmTTCSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgSet;
    }
}