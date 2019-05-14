using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemePacker
{
    public partial class OptionDialogBox : Form
    {
        public OptionDialogBox()
        {
            InitializeComponent();
        }

        private void OptionDialogBox_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void BtnGenerateFromDB_Click(object sender, EventArgs e)
        {
            
        }
    }
}
