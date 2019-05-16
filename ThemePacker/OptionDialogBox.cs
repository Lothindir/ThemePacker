using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemePacker
{
    public partial class OptionDialogBox : Form
    {
        public string TimeChange { get; private set; }
        public string TileWallpaper { get; private set; }
        public string WallPaperStyle { get; private set; }
        public OptionDialogBox()
        {
            InitializeComponent();
        }

        private void OptionDialogBox_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            cbPicPos.SelectedItem = "Tile";
            cbTimeChange.SelectedItem = "1 minute";
        }

        private void BtnGenerateFromDB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CbPicPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wallpaper = cbPicPos.SelectedItem.ToString();
            switch (wallpaper)
            {
                case "Fill":
                    TileWallpaper = "0";
                    WallPaperStyle = "10";
                    break;
                case "Fit":
                    TileWallpaper = "0";
                    WallPaperStyle = "6";
                    break;
                case "Stretch":
                    TileWallpaper = "0";
                    WallPaperStyle = "2";
                    break;
                case "Tile":
                    TileWallpaper = "1";
                    WallPaperStyle = "0";
                    break;
                case "Center":
                    TileWallpaper = "0";
                    WallPaperStyle = "0";
                    break;
            }
        }

        private void CbTimeChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            string time = cbTimeChange.SelectedItem.ToString();
            switch (time)
            {
                case "10 seconds":
                    TimeChange = "10000";
                    break;
                case "30 seconds":
                    TimeChange = "30000";
                    break;
                case "1 minute":
                    TimeChange = "60000";
                    break;
                case "5 minutes":
                    TimeChange = "300000";
                    break;
                case "10 minutes":
                    TimeChange = "600000";
                    break;
                case "20 minutes":
                    TimeChange = "1200000";
                    break;
                case "30 minutes":
                    TimeChange = "1800000";
                    break;
                case "1 hour":
                    TimeChange = "3600000";
                    break;
            }
        }
    }
}
