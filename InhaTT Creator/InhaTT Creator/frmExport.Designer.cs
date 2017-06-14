namespace InhaTT_Creator
{
    partial class frmExport
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
            this.rtbExport = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbExport
            // 
            this.rtbExport.Location = new System.Drawing.Point(12, 28);
            this.rtbExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbExport.Name = "rtbExport";
            this.rtbExport.Size = new System.Drawing.Size(678, 296);
            this.rtbExport.TabIndex = 0;
            this.rtbExport.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "밑 내용을 복사하세요 !";
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbExport);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExport";
            this.Text = "시간표 내보내기";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbExport;
        private System.Windows.Forms.Label label1;
    }
}