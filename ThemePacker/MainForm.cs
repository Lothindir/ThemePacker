using Microsoft.Deployment.Compression.Cab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThemePacker
{
    public partial class ThemePacker : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        private List<string> _likeds;
        private Dictionary<string, Image> _pictures;
        private string _path;
        private int _currentPic;
        private bool _isFolderBased;

        private CustomProgressBar pbProgression;

        private EventHandler _btnNextClick;

        private ImageList _imageList;

        public ThemePacker()
        {
            InitializeComponent();
            pbProgression = new CustomProgressBar(); pbProgression.Location = new Point(69, 496);
            pbProgression.MarqueeAnimationSpeed = 0;
            pbProgression.Name = "pbProgression";
            pbProgression.Size = new Size(400, 28);
            pbProgression.Style = ProgressBarStyle.Continuous;
            pbProgression.TabIndex = 16;
            pbProgression.DisplayStyle = ProgressBarDisplayText.CustomText;
            Controls.Add(pbProgression);
        }

        private void ThemePacker_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            btnGenerate.Enabled = false;
            btnLike.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
            _currentPic = 0;
            _likeds = new List<string>();
            _pictures = new Dictionary<string, Image>();
            _imageList = new ImageList();
            _imageList.ImageSize = new Size(128, 128);
            _imageList.ColorDepth = ColorDepth.Depth32Bit;
            picturesLsv.LargeImageList = _imageList;
            picturesLsv.View = View.LargeIcon;

            CreateDirectory("temp");//crée un dossier temporaire
        }

        private void ClearPictures()
        {
            foreach (Image image in _pictures.Values)
            {
                image.Dispose();
            }
            _pictures.Clear();
            _currentPic = 0;
        }

        private void ChooseImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choosePicFolder = new FolderBrowserDialog();
            choosePicFolder.ShowNewFolderButton = false;
            DialogResult result = choosePicFolder.ShowDialog();

            _btnNextClick = BtnNext_Click;
            btnNext.Click += _btnNextClick;

            if (result == DialogResult.OK)
            {
                _path = choosePicFolder.SelectedPath;

                ClearPictures();

                if (SelectPic())
                {
                    btnLike.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    ListShuffle();
                    _isFolderBased = true;
                    UpdatePic();
                }
            }
        }

        private async void GenerateFormInspirobotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearPictures();
            pbWallpaper.Image = Image.FromFile("Resources\\loadingIcon.png");

            await GetImageFromInspirobot();

            _currentPic = 0;

            _isFolderBased = false;

            _btnNextClick = BtnNext_Click_API;
            btnNext.Click += _btnNextClick;

            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnLike.Enabled = true;

            UpdatePic();
        }

        private void ListShuffle()
        {
            Random rng = new Random();
            _pictures = _pictures.OrderBy(x => rng.Next()).ToDictionary(item => item.Key, item => item.Value);
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
                if (!_pictures.ContainsKey(s))
                {
                    _pictures.Add(s, Image.FromFile(s));
                }
            }
            return true;
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
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
            //Hide();
        }

        private void UpdatePic()
        {
            pbWallpaper.Image = _pictures.ElementAt(_currentPic).Value;
            pbProgression.Value = (int)Math.Ceiling(((_currentPic + 1) * 100) / (decimal)(_pictures.Count));
            pbProgression.CustomText = $"{_currentPic + 1} / {_pictures.Count}";
            pbProgression.Refresh();
        }

        private void BtnNext_Click(object sender, EventArgs e)
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

        private void BtnLike_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = true;

            var currentImg = _pictures.ElementAt(_currentPic);
            if (!_likeds.Contains(currentImg.Key))
            {
                _likeds.Add(currentImg.Key);

                _imageList.Images.Add(currentImg.Key, currentImg.Value);

                ListViewItem img = picturesLsv.Items.Add("");
                img.ImageKey = currentImg.Key;
                img.Tag = _currentPic.ToString();

                _btnNextClick(null, null);
            }
            else
            {
                MessageBox.Show("If u like too much u leak them");
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            OptionDialogBox opb = new OptionDialogBox();
            opb.ShowDialog();
            opb.Focus();
            Generate();
        }

        public void Generate()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Themepack | *.themepack";
            saveFileDialog.Title = "Enregistrer";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName == null || saveFileDialog.FileName == string.Empty)
            {
                Show();
                return;
            }

            string fileName = new FileInfo(saveFileDialog.FileName).Name;
            fileName = fileName.Replace(".themepack", "");

            CopyQuick();


            //read and replace
            string text = File.ReadAllText("temp\\super.theme");
            text = text.Replace("DisplayName=Tinderspirobot", "DisplayName=" + fileName);
            File.WriteAllText("temp\\super.theme", text);

            CabInfo cab = new CabInfo(saveFileDialog.FileName);
            cab.Pack("temp", true, Microsoft.Deployment.Compression.CompressionLevel.Normal, null);

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

        private void PicturesLsv_Click(object sender, EventArgs e)
        {
            if (picturesLsv.SelectedItems.Count > 0)
            {
                pbWallpaper.Image = _pictures[picturesLsv.SelectedItems[0].ImageKey];
            }
        }

        private void BtnUnlike_Click(object sender, EventArgs e)
        {
            if (picturesLsv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in picturesLsv.SelectedItems)
                {
                    _likeds.Remove(item.ImageKey);
                    _imageList.Images.RemoveByKey(item.ImageKey);
                    picturesLsv.Items.Remove(item);
                }

                UpdatePic();
            }
        }

        private async void BtnNext_Click_API(object sender, EventArgs e)
        {
            if (_currentPic != _pictures.Count - 1)
            {
                _currentPic++;
            }
            else
            {
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                btnLike.Enabled = false;
                btnUnlike.Enabled = false;

                await GetImageFromInspirobot();

                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
                btnLike.Enabled = true;
                btnUnlike.Enabled = true;
            }

            UpdatePic();
        }

        private async Task GetImageFromInspirobot()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://inspirobot.me/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/uri-list"));

                HttpResponseMessage response = await client.GetAsync("api?generate=true");
                if (response.IsSuccessStatusCode)
                {
                    string url = await response.Content.ReadAsStringAsync();

                    using (WebClient webClient = new WebClient())
                    {
                        string[] urlBits = url.Split("/".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        string fileName = urlBits[urlBits.Length - 1];
                        string imagePath = $"temp\\{fileName}";

                        Debug.WriteLine($"Starting {fileName} download");
                        webClient.DownloadFile(new Uri(url), imagePath);
                        Debug.WriteLine($"{fileName} download finished");

                        _pictures.Add(imagePath, Image.FromFile(imagePath));
                    }
                    _currentPic++;
                }
            }
        }

        private void ThemePacker_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearPictures();
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp", true);
            }
        }

        private void ImportThemepackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AsImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        ~ThemePacker()
        {
            ClearPictures();
        }
    }
}
