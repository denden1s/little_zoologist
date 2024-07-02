using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace little_zoologist
{
    public partial class MainWindow : Form
    {
        Configuration config;
        static Panel mainPanel;// = new Panel();
        List<Animal> animals;
        PictureBox SlideAnimalsRight, SlideAnimalsLeft;
        string uiPath = DataFolder.defaultPath + "/.ui/";
        static int carusel = 0;
        Image leftImg, rightImg, playImg, framePng;
        WMPLib.WindowsMediaPlayer Player;

        //Dictionary<string, Image> pics = new Dictionary<string, Image>();
        //Label text;
        public MainWindow()
        {
            InitializeComponent();
            mainPanel = new Panel();
            config = new Configuration();
            Player = new WMPLib.WindowsMediaPlayer();
            animals = config.GetAnimals();
            this.DoubleBuffered = true;
            FileStream imageStream = new FileStream(Convert.ToString(uiPath + "/left.png"), FileMode.Open);
            leftImg = Image.FromStream(imageStream);
            imageStream.Close();
            imageStream = new FileStream(Convert.ToString(uiPath + "/right.png"), FileMode.Open);
            rightImg = Image.FromStream(imageStream);
            imageStream.Close();
            imageStream = new FileStream(Convert.ToString(uiPath + "/play.png"), FileMode.Open);
            playImg = Image.FromStream(imageStream);
            imageStream.Close();
            imageStream = new FileStream(Convert.ToString(uiPath + "/frame.png"), FileMode.Open);
            framePng = Image.FromStream(imageStream);
            imageStream.Close();

            mainPanel.Width = 1920;
            mainPanel.Height = 800;
            mainPanel.BackColor = Color.Transparent;
            mainPanel.Location = new Point(0, 180);

            Panel lowButtons = new Panel();
            lowButtons.BackColor = Color.Transparent;
            lowButtons.Width = 1920;
            lowButtons.Height = 100;
            lowButtons.Location = new Point(0, 980);
            SlideAnimalsRight = CreatePictureBox(lowButtons, "SlideAnimalsRight", uiPath + "/right.png", new Point(1820, 10));
            SlideAnimalsLeft = CreatePictureBox(lowButtons, "SlideAnimalsLeft", uiPath + "/left.png", new Point(20, 10));
            SlideAnimalsLeft.Click += (sender, e) => { 
                carusel = carusel - 1 >= 0 ? carusel - 1 : 0;
                mainPanel.Controls.Clear();
                MainWindow_Load(sender, e);
            };

            SlideAnimalsRight.Click += (sender, e) => {
                carusel = carusel + 1 > animals.Count() / 8 ? carusel : carusel + 1;
                mainPanel.Controls.Clear();
                MainWindow_Load(sender, e);
            };
            lowButtons.Controls.Add(SlideAnimalsRight);
            lowButtons.Controls.Add(SlideAnimalsLeft);
            this.Controls.Add(lowButtons);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Player.controls.stop();
            Application.Exit();
        }

        public string ShowDialog(string buttonCaption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(192, 255, 192)
            };
            Font font = new Font("Arial", 20);
            Label textLabel = new Label() { Left = 150, Top = 30, Text = "Введите пароль", Font = font, Width = 300, Height = 40 };
            MaskedTextBox textBox = new MaskedTextBox() { Left = 50, Top = 80, Width = 400, Font = font, Height = 20, PasswordChar='*' };
            Button confirmation = new Button() { Text = buttonCaption, Left = 50, Width = 400, Top = 140, DialogResult = DialogResult.OK, Font = font, Height = 40 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void pictureBox2_Click(object sender, EventArgs e) 
        {
            if (!config.PasswordStatus())
            {
                string res = ShowDialog("Сохранить");
                config.SetPassword(res);
            }
            else
            {
                string res = ShowDialog("Войти");
                if (config.VerifyPassword(res) != 0)
                {
                    MessageBox.Show("Введен неправильный пароль");
                    return;
                }
                CRUDForm form = CRUDForm.GetForm(config);
                Player.controls.stop();
                this.Close();
            }
        }


        // TODO: add event on click
        PictureBox CreatePictureBox(Panel panel, string name, string image, Point location, int width = 85, int height = 85, bool circle = true)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel;
            pictureBox.Name = name;

            FileStream imageStream = new FileStream(Convert.ToString(image), FileMode.Open);
            Image image1 = Image.FromStream(imageStream);
            imageStream.Close();
            pictureBox.Image = image1; 
            pictureBox.Location = location; 
            pictureBox.BackColor = Color.White;
            pictureBox.Size = new  Size(width, height);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (circle)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(pictureBox.DisplayRectangle);
                pictureBox.Region = new Region(gp);
                pictureBox.MouseLeave += (sender, e) => { ((PictureBox)sender).BackColor = Color.White; };
                pictureBox.MouseEnter += (sender, e) => { ((PictureBox)sender).BackColor = Color.Aquamarine; };
            }
            return pictureBox;
        }

        PictureBox CreatePictureBox(Panel panel, string name, Image image, Point location, int width = 85, int height = 85, bool circle = true)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel;
            pictureBox.Name = name;

            pictureBox.Image = image;
            pictureBox.Location = location;
            pictureBox.BackColor = Color.White;
            pictureBox.Size = new Size(width, height);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (circle)
            {
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(pictureBox.DisplayRectangle);
                pictureBox.Region = new Region(gp);
                pictureBox.MouseLeave += (sender, e) => { ((PictureBox)sender).BackColor = Color.White; };
                pictureBox.MouseEnter += (sender, e) => { ((PictureBox)sender).BackColor = Color.Aquamarine; };
            }
            return pictureBox;
        }

        // Function to create a rounded rectangle region
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        Label CreateLabel(Panel parent, string name, string text, Point location, int width = 290, int height = 30)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Parent = parent;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Sans", 14, FontStyle.Regular);
            label.BackColor = Color.White;
            label.Size = new Size(width, height);
            label.Location = location;
            label.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label.Width, label.Height, 10, 10));
            return label;
        }
        static int CountPanels = 0;

        private void NavigateImages(PictureBox pictureBox, List<string> imageList, ref int currentIndex, int change)
        {
            // Adjust currentIndex based on change (previous or next)
            currentIndex += change;

            // Ensure currentIndex stays within bounds
            if (currentIndex < 0)
            {
                currentIndex = imageList.Count - 1; // Wrap around to the end
            }
            else if (currentIndex >= imageList.Count)
            {
                currentIndex = 0; // Wrap around to the beginning
            }

            // Update UI or perform other actions based on the currentIndex
            string currentImage = imageList[currentIndex];
            // Example: Display the currentImage in a PictureBox or perform other actions
            FileStream imageStream = new FileStream(Convert.ToString(currentImage), FileMode.Open);
            pictureBox.Image = Image.FromStream(imageStream);
            imageStream.Close();
        }


        private void PlayRandomSound(List<string> soundFiles)
        {
            // Stop currently playing sound (if any)
            Random random = new Random();
            Player.controls.stop();

            // Get a random sound file from the list
            int index = random.Next(soundFiles.Count);
            string soundFile = soundFiles[index];
            try
            {
                Player.URL = soundFile;
                Player.controls.play(); // Load the sound file
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }

        private List<string> LoadImagesFromDirectory(string directoryPath)
        {
            List<string> imagePaths = new List<string>();

            try
            {
                // Check if the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Get all files with specific extensions (e.g., JPEG, PNG, etc.)
                    IEnumerable<string> imageFiles = Directory.EnumerateFiles(directoryPath);

                    // Add each image file path to the list
                    imagePaths.AddRange(imageFiles);
                }
                else
                {
                    Console.WriteLine("Directory does not exist: " + directoryPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading images from directory: " + ex.Message);
            }

            return imagePaths;
        }

        private List<string> LoadSoundFiles(string directoryPath)
        {
            List<string> soundFiles = new List<string>();
            try
            {
                // Check if the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Get all sound files with specific extensions (e.g., .wav, .mp3)
                    IEnumerable<string> soundFilesEnum = Directory.EnumerateFiles(directoryPath);

                    // Add each sound file path to the list
                    soundFiles.AddRange(soundFilesEnum);
                }
                else
                {
                    MessageBox.Show("Directory does not exist: " + directoryPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sound files: " + ex.Message);
            }
            return soundFiles;
        }

        Panel CreatePanel(Panel parent, string name, Point location, string imagePath = "", bool circleImage = true)
        {
            Panel panel = new Panel();
            panel.Parent = parent;
            panel.Width = 400;
            panel.Height = 400;
            panel.BackColor = Color.Transparent;
            panel.Location = location;
            //panel.Location.Y = 200;
            panel.Visible = true;
            PictureBox img = new PictureBox();
            if (imagePath != "")
            {
                img = CreatePictureBox(panel, "img" + Convert.ToString(CountPanels), imagePath, new Point(80,80), 250, 230, circleImage);
                panel.Controls.Add(img);

            }
            panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panel.BackgroundImage = framePng;
            PictureBox right = CreatePictureBox(panel, "rightButton" + Convert.ToString(CountPanels), rightImg, new Point(300, 310));

            PictureBox play = CreatePictureBox(panel, "playButton" + Convert.ToString(CountPanels), playImg, new Point(160, 310));

            PictureBox left = CreatePictureBox(panel, "leftButton" + Convert.ToString(CountPanels), leftImg, new Point(10, 310));
            int currentIndex = 0;
            string path = animals.Where(i => i.Name == name).First().Path;
            List<string> images = LoadImagesFromDirectory(path + "\\img\\");
            List<string> sounds = LoadSoundFiles(path + "\\sound\\");

            play.Click += (sender, e) => PlayRandomSound(sounds);
            left.Click += (sender, e) => NavigateImages(img, images, ref currentIndex, -1);
            right.Click += (sender, e) => NavigateImages(img, images, ref currentIndex, 1);


            Label nameLabel = CreateLabel(panel, name, name, new Point(60, 50));
            panel.Controls.Add(play);
            panel.Controls.Add(right);
            panel.Controls.Add(left);
            panel.Controls.Add(nameLabel);
            panel.Refresh();
            CountPanels++;
            return panel;
        }



        private void LoadPics(int i)
        {
            // Определяем размер диапазона
            int rangeSize = 4; // Каждый диапазон содержит 4 числа

            // Вычисляем индекс текущего диапазона
            int rangeIndex = (i) / rangeSize;

            // Возвращаем 0 или 1 в зависимости от четности индекса диапазона
            int side = rangeIndex % 2 == 0 ? 0 : 400;
            int left = i % 4 * 500 + 20;
            string img = animals[i].Path + "/img/img_0";
            if (!File.Exists(img))
                img = "";
            Panel panel = CreatePanel(mainPanel, animals[i].Name, new Point(left, side), img, false);
            mainPanel.Controls.Add(panel);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //mainPanel = new Panel();
            animals = config.GetAnimals();
            for (int i = carusel * 8; i < animals.Count(); i++)
            {
                LoadPics(i);            
            }

            if (animals.Count() > 8)
            {
                SlideAnimalsRight.Visible = true;
                SlideAnimalsLeft.Visible = true;
            }
            else
            {
                SlideAnimalsRight.Visible = false;
                SlideAnimalsLeft.Visible = false;
            }
            this.Controls.Add(mainPanel);
        }
    }
}
