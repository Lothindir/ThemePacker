using Microsoft.Deployment.Compression.Cab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheFullFacebook
{
    public partial class TheFacebook : Form
    {
        private List<string> _likeds;
        private List<Image> _pictures;
        private List<string> _picturePath;
        private string _path;
        private int _currentPic;

        public TheFacebook()
        {
            InitializeComponent();
        }

        private void TheFacebook_Load(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            btnLike.Enabled = false;
            btnNext.Enabled = false;
            btnUnlike.Enabled = false;
            _currentPic = 0;
            _likeds = new List<string>();
            _pictures = new List<Image>();
            _picturePath = new List<string>();
        }

        private void ChooseImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choosePicFolder = new FolderBrowserDialog();
            choosePicFolder.ShowNewFolderButton = false;
            DialogResult result = choosePicFolder.ShowDialog();
            if (result == DialogResult.OK)
            {
                _path = choosePicFolder.SelectedPath;
                if (SelectPic())
                {
                    btnGenerate.Enabled = true;
                    btnLike.Enabled = true;
                    btnNext.Enabled = true;
                    btnUnlike.Enabled = true;
                    ListShuffle();
                    UpdatePic();
                }
            }
        }

        private void ListShuffle()
        {
            Random rng = new Random();
            _pictures = _pictures.OrderBy(p => rng.Next()).ToList();
        }

        private bool SelectPic()
        {
            List<string> imagesList = Directory.GetFiles(_path, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
            imagesList.AddRange(Directory.GetFiles(_path, "*.png", SearchOption.TopDirectoryOnly));
            if (imagesList.Count < 1)
            {
                MessageBox.Show("Votre dossier ne contient pas d'image ou pas le bon type d'image. (png et jpg only)");
                return false; ;
            }
            foreach (string s in imagesList)
            {
                _pictures.Add(Image.FromFile(s));
                _picturePath.Add(s);
            }
            return true;
        }

        private void btnUnlike_Click(object sender, EventArgs e)
        {
            if (_currentPic != 0)
            {
                _currentPic--;
                UpdatePic();
            }
            else
            {
                MessageBox.Show("DIS IS ZE BEGINING (joy face)");
            }
        }

        private void UpdatePic()
        {
            pbWallpaper.Image = _pictures[_currentPic];
            pbProgression.Value = (_currentPic * 100) / (_pictures.Count - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPic != _pictures.Count - 1)
            {
                _currentPic++;
                UpdatePic();
            }
            else
            {
                MessageBox.Show("DIS IS ZE END (sad face)");
            }
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            if (!_likeds.Contains(_picturePath[_currentPic]))
            {
                _likeds.Add(_picturePath[_currentPic]);
                btnNext_Click(null, null);
            }
            else
            {
                MessageBox.Show("If u like too much u leak them");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Themepack | *.themepack";
            saveFileDialog.Title = "Enregistrer";
            saveFileDialog.ShowDialog();
            string fileName = new FileInfo(saveFileDialog.FileName).Name;
            fileName = fileName.Replace(".themepack", "");

            CreateDirectory("temp");//crée un dossier temporaire
            CopyQuick();


            //read and replace
            string text = File.ReadAllText("temp\\super.theme");
            text = text.Replace("DisplayName=Tinderspirobot", "DisplayName=" + fileName);
            File.WriteAllText("temp\\super.theme", text);

            CabInfo cab = new CabInfo(saveFileDialog.FileName);
            cab.Pack("temp", true, Microsoft.Deployment.Compression.CompressionLevel.Normal, null);
            Directory.Delete("temp", true);
            Environment.Exit(7);

        }

        private void CopyQuick()
        {
            foreach (string path in _likeds)
            {
                File.Copy(path, "temp\\DesktopBackground\\" + new FileInfo(path).Name);
            }

            File.Copy("Resources\\super.theme", "temp\\super.theme", true);
            File.Copy("Resources\\icon.png", "temp\\icon.png", true);
        }

        private void CreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            DirectoryInfo di = Directory.CreateDirectory(path);
            DirectoryInfo dii = Directory.CreateDirectory(path + "\\DesktopBackground");
        }
    }
}
