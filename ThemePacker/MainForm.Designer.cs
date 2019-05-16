﻿namespace ThemePacker
{
    partial class ThemePacker
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemePacker));
            this.btnNext = new System.Windows.Forms.Button();
            this.pbProgression = new System.Windows.Forms.ProgressBar();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.pbWallpaper = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFormInspirobotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picturesLsv = new System.Windows.Forms.ListView();
            this.btnUnlike = new System.Windows.Forms.Button();
            this.importThemepackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(363, 448);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(106, 42);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // pbProgression
            // 
            this.pbProgression.Location = new System.Drawing.Point(69, 496);
            this.pbProgression.Name = "pbProgression";
            this.pbProgression.Size = new System.Drawing.Size(400, 28);
            this.pbProgression.TabIndex = 16;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(199, 530);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(135, 42);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(199, 448);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(135, 42);
            this.btnLike.TabIndex = 14;
            this.btnLike.Text = "I LIKE DAT";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.BtnLike_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(69, 448);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(106, 42);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // pbWallpaper
            // 
            this.pbWallpaper.Image = ((System.Drawing.Image)(resources.GetObject("pbWallpaper.Image")));
            this.pbWallpaper.Location = new System.Drawing.Point(69, 27);
            this.pbWallpaper.Name = "pbWallpaper";
            this.pbWallpaper.Size = new System.Drawing.Size(400, 400);
            this.pbWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWallpaper.TabIndex = 12;
            this.pbWallpaper.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1117, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseImageFolderToolStripMenuItem,
            this.generateFormInspirobotToolStripMenuItem,
            this.importThemepackToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // chooseImageFolderToolStripMenuItem
            // 
            this.chooseImageFolderToolStripMenuItem.Name = "chooseImageFolderToolStripMenuItem";
            this.chooseImageFolderToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.chooseImageFolderToolStripMenuItem.Text = "Choose image folder";
            this.chooseImageFolderToolStripMenuItem.Click += new System.EventHandler(this.ChooseImageFolderToolStripMenuItem_Click);
            // 
            // generateFormInspirobotToolStripMenuItem
            // 
            this.generateFormInspirobotToolStripMenuItem.Name = "generateFormInspirobotToolStripMenuItem";
            this.generateFormInspirobotToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.generateFormInspirobotToolStripMenuItem.Text = "Generate from inspirobot.me";
            this.generateFormInspirobotToolStripMenuItem.Click += new System.EventHandler(this.GenerateFormInspirobotToolStripMenuItem_Click);
            // 
            // picturesLsv
            // 
            this.picturesLsv.Location = new System.Drawing.Point(497, 27);
            this.picturesLsv.Name = "picturesLsv";
            this.picturesLsv.Size = new System.Drawing.Size(608, 497);
            this.picturesLsv.TabIndex = 19;
            this.picturesLsv.UseCompatibleStateImageBehavior = false;
            this.picturesLsv.Click += new System.EventHandler(this.PicturesLsv_Click);
            // 
            // btnUnlike
            // 
            this.btnUnlike.Location = new System.Drawing.Point(680, 530);
            this.btnUnlike.Name = "btnUnlike";
            this.btnUnlike.Size = new System.Drawing.Size(135, 42);
            this.btnUnlike.TabIndex = 20;
            this.btnUnlike.Text = "I dislike dis";
            this.btnUnlike.UseVisualStyleBackColor = true;
            this.btnUnlike.Click += new System.EventHandler(this.BtnUnlike_Click);
            // 
            // importThemepackToolStripMenuItem
            // 
            this.importThemepackToolStripMenuItem.Name = "importThemepackToolStripMenuItem";
            this.importThemepackToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.importThemepackToolStripMenuItem.Text = "Import Themepack";
            this.importThemepackToolStripMenuItem.Click += new System.EventHandler(this.ImportThemepackToolStripMenuItem_Click);
            // 
            // ThemePacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 576);
            this.Controls.Add(this.btnUnlike);
            this.Controls.Add(this.picturesLsv);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pbProgression);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.pbWallpaper);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThemePacker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemePacker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ThemePacker_FormClosed);
            this.Load += new System.EventHandler(this.ThemePacker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbWallpaper)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ProgressBar pbProgression;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.PictureBox pbWallpaper;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseImageFolderToolStripMenuItem;
        private System.Windows.Forms.ListView picturesLsv;
        private System.Windows.Forms.Button btnUnlike;
        private System.Windows.Forms.ToolStripMenuItem generateFormInspirobotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importThemepackToolStripMenuItem;
    }
}

