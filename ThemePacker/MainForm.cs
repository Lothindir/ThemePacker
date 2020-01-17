using Microsoft.Deployment.Compression.Cab;
using Newtonsoft.Json.Linq;
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
        private Dictionary<string, bool> _shownImages;
        private string _path;
        private int _currentPic;
        private bool _isFolderBased;
        private OptionDialogBox _opb;
        private CustomProgressBar _pbProgression;

        private EventHandler _btnNextClick;

        private ImageList _imageList;

        public ThemePacker()
        {
            InitializeComponent();
            _pbProgression = new CustomProgressBar(); _pbProgression.Location = new Point(69, 496);
            _pbProgression.MarqueeAnimationSpeed = 0;
            _pbProgression.Name = "pbProgression";
            _pbProgression.Size = new Size(400, 28);
            _pbProgression.Style = ProgressBarStyle.Continuous;
            _pbProgression.TabIndex = 16;
            _pbProgression.DisplayStyle = ProgressBarDisplayText.CustomText;
            Controls.Add(_pbProgression);
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
            btnUnlike.Enabled = false;
            _currentPic = 0;
            _likeds = new List<string>();
            _pictures = new Dictionary<string, Image>();
            _shownImages = new Dictionary<string, bool>();
            _imageList = new ImageList();
            _imageList.ImageSize = new Size(128, 128);
            _imageList.ColorDepth = ColorDepth.Depth32Bit;
            picturesLsv.LargeImageList = _imageList;
            picturesLsv.View = View.LargeIcon;

            CreateDirectory("temp\\themepack");//crée un dossier temporaire
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

            _btnNextClick = BtnNext_Click_API;
            btnNext.Click += _btnNextClick;

            btnNext.Enabled = true;
            btnPrevious.Enabled = true;
            btnLike.Enabled = true;

            UpdatePic();
        }

        private void ImportThemepackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Themepack | *.themepack";
            openFileDialog.Title = "Ouvrir";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.EndsWith(".themepack"))
            {

                string filename = $"temp\\{openFileDialog.FileName.Split('\\').Last()}";
                File.Copy(openFileDialog.FileName, filename);
                File.Move(filename, filename = filename.Replace(".themepack", ".cab"));

                CabInfo cab = new CabInfo(filename);
                _path = filename.Split('.')[0];
                cab.Unpack(_path);

                _btnNextClick = BtnNext_Click;
                btnNext.Click += _btnNextClick;

                if (SelectPic(_path + "\\DesktopBackground"))
                {
                    btnLike.Enabled = true;
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                    UpdatePic();
                }

                foreach (var pics in _pictures)
                {
                    BtnLike_Click(null, null);
                }
            }
        }

        private bool SelectPic(string path = null)
        {
            if(path == null)
            {
                path = _path;
            }

            List<string> imagesList = Directory.GetFiles(path, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
            imagesList.AddRange(Directory.GetFiles(path, "*.png", SearchOption.TopDirectoryOnly));
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
        }

        private void UpdatePic()
        {
            pbWallpaper.Image = _pictures.ElementAt(_currentPic).Value;
            _pbProgression.Value = (int)Math.Ceiling(((_currentPic + 1) * 100) / (decimal)(_pictures.Count));
            _pbProgression.CustomText = $"{_currentPic + 1} / {_pictures.Count}";
            _pbProgression.Refresh();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentPic != _pictures.Count - 1)
            {
                _currentPic++;
                UpdatePic();
            }
        }

        private void BtnLike_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = true;
            btnUnlike.Enabled = true;

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
            _opb = new OptionDialogBox();
            if (_opb.ShowDialog() == DialogResult.OK)
            {
                Generate();
            }
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

            ThemeFileSerializer tfs = new ThemeFileSerializer("temp\\super.theme");
            tfs.Deserialize();
            JObject theme = tfs.JSON;
            theme["Theme"]["DisplayName"] = fileName;
            theme["Control Panel_Desktop"]["TileWallpaper"] = _opb.TileWallpaper;
            theme["Control Panel_Desktop"]["WallpaperStyle"] = _opb.WallPaperStyle;
            theme["Slideshow"]["Interval"] = _opb.TimeChange;
            tfs.JSON = theme;
            tfs.JsonSerialize($"temp\\themepack\\{fileName}.theme");

            CabInfo cab = new CabInfo(saveFileDialog.FileName);
            cab.Pack("temp\\themepack", true, Microsoft.Deployment.Compression.CompressionLevel.Normal, null);

            this.Close();
        }

        private void CopyQuick()
        {
            foreach (string path in _likeds)
            {
                File.Copy(path, "temp\\themepack\\DesktopBackground\\" + new FileInfo(path).Name);
            }

            File.Copy("Resources\\super.theme", "temp\\super.theme", true);
            File.Copy("Resources\\icon.png", "temp\\themepack\\icon.png", true);
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

            if(picturesLsv.Items.Count == 0)
            {
                btnUnlike.Enabled = false;
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
            Directory.CreateDirectory(@"temp\images");

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
                        string imagePath = $"temp\\images\\{fileName}";

                        Debug.WriteLine($"Starting {fileName} download");
                        webClient.DownloadFile(new Uri(url), imagePath);
                        Debug.WriteLine($"{fileName} download finished");

                        _pictures.Add(imagePath, Image.FromFile(imagePath));
                    }
                    _currentPic++;
                }
            }
        }

        private void AsImageFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        ~ThemePacker()
        {
            ClearPictures();
        }

        private void ThemePacker_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearPictures();
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp", true);
            }
        }
    }
}
