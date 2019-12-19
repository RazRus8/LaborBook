namespace LaborBook
{
    partial class JobForm
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
            this.tbxDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxJobNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPosition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxDoc = new System.Windows.Forms.TextBox();
            this.btnJobOk = new System.Windows.Forms.Button();
            this.btnJobCancel = new System.Windows.Forms.Button();
            this.btnJobDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxDate
            // 
            this.tbxDate.AcceptsReturn = true;
            this.tbxDate.Enabled = false;
            this.tbxDate.Location = new System.Drawing.Point(136, 19);
            this.tbxDate.Margin = new System.Windows.Forms.Padding(10);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Size = new System.Drawing.Size(232, 20);
            this.tbxDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Employment info";
            // 
            // tbxJobNote
            // 
            this.tbxJobNote.AcceptsReturn = true;
            this.tbxJobNote.Enabled = false;
            this.tbxJobNote.Location = new System.Drawing.Point(136, 59);
            this.tbxJobNote.Margin = new System.Windows.Forms.Padding(10);
            this.tbxJobNote.Multiline = true;
            this.tbxJobNote.Name = "tbxJobNote";
            this.tbxJobNote.Size = new System.Drawing.Size(232, 100);
            this.tbxJobNote.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Position";
            // 
            // tbxPosition
            // 
            this.tbxPosition.AcceptsReturn = true;
            this.tbxPosition.Location = new System.Drawing.Point(136, 179);
            this.tbxPosition.Margin = new System.Windows.Forms.Padding(10);
            this.tbxPosition.Multiline = true;
            this.tbxPosition.Name = "tbxPosition";
            this.tbxPosition.Size = new System.Drawing.Size(232, 100);
            this.tbxPosition.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 302);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Document";
            // 
            // tbxDoc
            // 
            this.tbxDoc.AcceptsReturn = true;
            this.tbxDoc.Enabled = false;
            this.tbxDoc.Location = new System.Drawing.Point(136, 299);
            this.tbxDoc.Margin = new System.Windows.Forms.Padding(10);
            this.tbxDoc.Multiline = true;
            this.tbxDoc.Name = "tbxDoc";
            this.tbxDoc.Size = new System.Drawing.Size(232, 100);
            this.tbxDoc.TabIndex = 3;
            // 
            // btnJobOk
            // 
            this.btnJobOk.Location = new System.Drawing.Point(17, 433);
            this.btnJobOk.Name = "btnJobOk";
            this.btnJobOk.Size = new System.Drawing.Size(75, 23);
            this.btnJobOk.TabIndex = 4;
            this.btnJobOk.Text = "OK";
            this.btnJobOk.UseVisualStyleBackColor = true;
            this.btnJobOk.Click += new System.EventHandler(this.btnJobOk_Click);
            // 
            // btnJobCancel
            // 
            this.btnJobCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnJobCancel.Location = new System.Drawing.Point(112, 433);
            this.btnJobCancel.Name = "btnJobCancel";
            this.btnJobCancel.Size = new System.Drawing.Size(75, 23);
            this.btnJobCancel.TabIndex = 5;
            this.btnJobCancel.Text = "Cancel";
            this.btnJobCancel.UseVisualStyleBackColor = true;
            // 
            // btnJobDel
            // 
            this.btnJobDel.Location = new System.Drawing.Point(252, 433);
            this.btnJobDel.Name = "btnJobDel";
            this.btnJobDel.Size = new System.Drawing.Size(116, 23);
            this.btnJobDel.TabIndex = 6;
            this.btnJobDel.Text = "Delete Record";
            this.btnJobDel.UseVisualStyleBackColor = true;
            this.btnJobDel.Click += new System.EventHandler(this.btnJobDel_Click);
            // 
            // JobForm
            // 
            this.AcceptButton = this.btnJobOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnJobCancel;
            this.ClientSize = new System.Drawing.Size(383, 478);
            this.Controls.Add(this.btnJobDel);
            this.Controls.Add(this.btnJobCancel);
            this.Controls.Add(this.btnJobOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxDoc);
            this.Controls.Add(this.tbxPosition);
            this.Controls.Add(this.tbxJobNote);
            this.Controls.Add(this.tbxDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "JobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxJobNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxDoc;
        private System.Windows.Forms.Button btnJobOk;
        private System.Windows.Forms.Button btnJobCancel;
        private System.Windows.Forms.Button btnJobDel;
    }
}