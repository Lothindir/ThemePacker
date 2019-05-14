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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblChangePosition = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblChangeTime = new System.Windows.Forms.Label();
            this.btnGenerateFromDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Remplissage",
            "Ajuster"});
            this.comboBox1.Location = new System.Drawing.Point(32, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 0;
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
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(207, 40);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 21);
            this.comboBox2.TabIndex = 2;
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
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.lblChangePosition);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionDialogBox";
            this.Text = "OptionDialogBox";
            this.Load += new System.EventHandler(this.OptionDialogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblChangePosition;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblChangeTime;
        private System.Windows.Forms.Button btnGenerateFromDB;
    }
}