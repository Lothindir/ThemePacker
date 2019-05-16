namespace ThemePacker
{
    partial class OptionDialogBox
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
            this.cbPicPos = new System.Windows.Forms.ComboBox();
            this.lblChangePosition = new System.Windows.Forms.Label();
            this.cbTimeChange = new System.Windows.Forms.ComboBox();
            this.lblChangeTime = new System.Windows.Forms.Label();
            this.btnGenerateFromDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbPicPos
            // 
            this.cbPicPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPicPos.FormattingEnabled = true;
            this.cbPicPos.Items.AddRange(new object[] {
            "Fill",
            "Fit",
            "Stretch",
            "Tile",
            "Center"});
            this.cbPicPos.Location = new System.Drawing.Point(32, 40);
            this.cbPicPos.Name = "cbPicPos";
            this.cbPicPos.Size = new System.Drawing.Size(108, 21);
            this.cbPicPos.TabIndex = 0;
            this.cbPicPos.SelectedIndexChanged += new System.EventHandler(this.CbPicPos_SelectedIndexChanged);
            // 
            // lblChangePosition
            // 
            this.lblChangePosition.AutoSize = true;
            this.lblChangePosition.Location = new System.Drawing.Point(29, 24);
            this.lblChangePosition.Name = "lblChangePosition";
            this.lblChangePosition.Size = new System.Drawing.Size(79, 13);
            this.lblChangePosition.TabIndex = 1;
            this.lblChangePosition.Text = "Picture position";
            // 
            // cbTimeChange
            // 
            this.cbTimeChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeChange.FormattingEnabled = true;
            this.cbTimeChange.Items.AddRange(new object[] {
            "10 seconds",
            "30 seconds",
            "1 minute",
            "5 minutes",
            "10 minutes",
            "20 minutes",
            "30 minutes",
            "1 hour"});
            this.cbTimeChange.Location = new System.Drawing.Point(207, 40);
            this.cbTimeChange.Name = "cbTimeChange";
            this.cbTimeChange.Size = new System.Drawing.Size(108, 21);
            this.cbTimeChange.TabIndex = 2;
            this.cbTimeChange.SelectedIndexChanged += new System.EventHandler(this.CbTimeChange_SelectedIndexChanged);
            // 
            // lblChangeTime
            // 
            this.lblChangeTime.AutoSize = true;
            this.lblChangeTime.Location = new System.Drawing.Point(204, 24);
            this.lblChangeTime.Name = "lblChangeTime";
            this.lblChangeTime.Size = new System.Drawing.Size(114, 13);
            this.lblChangeTime.TabIndex = 3;
            this.lblChangeTime.Text = "Change picture every :";
            // 
            // btnGenerateFromDB
            // 
            this.btnGenerateFromDB.Location = new System.Drawing.Point(-52, 86);
            this.btnGenerateFromDB.Name = "btnGenerateFromDB";
            this.btnGenerateFromDB.Size = new System.Drawing.Size(461, 133);
            this.btnGenerateFromDB.TabIndex = 4;
            this.btnGenerateFromDB.Text = "Generate";
            this.btnGenerateFromDB.UseVisualStyleBackColor = true;
            this.btnGenerateFromDB.Click += new System.EventHandler(this.BtnGenerateFromDB_Click);
            // 
            // OptionDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 169);
            this.Controls.Add(this.btnGenerateFromDB);
            this.Controls.Add(this.lblChangeTime);
            this.Controls.Add(this.cbTimeChange);
            this.Controls.Add(this.lblChangePosition);
            this.Controls.Add(this.cbPicPos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionDialogBox";
            this.Text = "OptionDialogBox";
            this.Load += new System.EventHandler(this.OptionDialogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPicPos;
        private System.Windows.Forms.Label lblChangePosition;
        private System.Windows.Forms.ComboBox cbTimeChange;
        private System.Windows.Forms.Label lblChangeTime;
        private System.Windows.Forms.Button btnGenerateFromDB;
    }
}