using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace little_zoologist
{
    public partial class CRUDForm : Form
    {
        private static Configuration _config;
        private static CRUDForm _inst;
        private bool _addMode = false;
        private List<Animal> _animals;
        private List<string> _images;
        private List<string> _sounds;
        private Form _mainForm;

        public static CRUDForm GetForm(Configuration config)
        {
            if (_inst == null || _inst.IsDisposed)
                _inst = new CRUDForm(config);

            return _inst;
        }
        private CRUDForm(Configuration config)
        {
            InitializeComponent();
            SetRoundForm();
            this.Show();
            _config = config;
            _animals = _config.GetAnimals();
            _sounds = new List<string>();
            _images = new List<string>();
            foreach (Animal animal in _animals)
            {
                AnimalsListBox.Items.Add(animal.Name);
            }
            AddAndEditPanel.Visible = false;
            ChangeImagesCheckBox.Visible = false;
            ChangeSoundsCheckBox.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _mainForm = new MainWindow();
            _mainForm.Show();
            Close();
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
        }

        private List<string> LoadFiles(string filter)
        {
            List<string> result = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true; // Разрешаем выбор нескольких файлов
            openFileDialog.Filter = filter;
            DialogResult dialog = openFileDialog.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                string[] selectedFiles = openFileDialog.FileNames;
                foreach (string file in selectedFiles)
                    result.Add(file);
            }
            return result;
        }

        private int DeleteFiles(string dir)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo file in di.GetFiles())
                file.Delete();
            return 0;
        }

        private void SetRoundForm()
        {
            // Создаем GraphicsPath для определения формы с закругленными углами
            GraphicsPath path = new GraphicsPath();
            int radius = 45; // Радиус закругления углов

            // Верхний левый угол
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);

            // Верхний правый угол
            path.AddArc(ClientSize.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);

            // Нижний правый угол
            path.AddArc(ClientSize.Width - radius * 2, ClientSize.Height - radius * 2, radius * 2, radius * 2, 0, 90);

            // Нижний левый угол
            path.AddArc(0, ClientSize.Height - radius * 2, radius * 2, radius * 2, 90, 90);

            // Закрываем путь
            path.CloseFigure();

            // Устанавливаем полученный GraphicsPath в качестве региона формы
            Region = new Region(path);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (AnimalsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите животное из списка для удаления");
                return;
            }
            string name = AnimalsListBox.SelectedItem.ToString();//.GetItemText(AnimalsListBox.SelectedItem);
            if (_config.RemoveAnimal(name) != 0)
            {
                MessageBox.Show("Ошибка удаления записи");
                return;
            }
            AnimalsListBox.Items.Remove(name);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _addMode = true;
            AddAndEditPanel.Visible = true;
            ChangeImagesCheckBox.Visible = false;
            ChangeSoundsCheckBox.Visible = false;
            _sounds.Clear();
            _images.Clear();
            AnimalClassComboBox.Text = "";
            AnimalNameTextBox.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();
            if (AnimalsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите животное из списка для изменения");
                return;
            }
            animal = _animals.Where(i => i.Name.Equals(AnimalsListBox.SelectedItem.ToString())).First();
            AnimalNameTextBox.Text = animal.Name;
            AnimalClassComboBox.Text = animal.Class;
            _sounds.Clear();
            _images.Clear();
            _addMode = false;
            AddAndEditPanel.Visible = true;
            ChangeImagesCheckBox.Visible = true;
            ChangeSoundsCheckBox.Visible = true;
        }


        private int SaveAnimalFiles(Animal currentAnimal, List<string> files,  string fileType, int firstId = 0, bool delFiles = false)
        {
            string path = "/" + fileType + "/";
            string fileNameTemplate = fileType + "_";
            if (files.Count() < 1)
            {
                MessageBox.Show("Файлы не выбраны");
                return 1;
            }
            if (currentAnimal == null)
            {
                MessageBox.Show("Животное не выбрано");
                return 1;
            }
            if (!_addMode && delFiles)
                DeleteFiles(currentAnimal.Path + "/" + path);
             
            for (int i = firstId; i < files.Count() + firstId; i++)
            {
                File.Copy(files[i - firstId], currentAnimal.Path + "/" + path + "/" + fileNameTemplate + Convert.ToString(i), true);
            }
            return 0;
        }

        private void LoadPicsButton_Click(object sender, EventArgs e)
        {
            // TODO: only load in memory no save
             _images = LoadFiles("\"Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp\"");
            if (_images.Count() < 1)
            {
                MessageBox.Show("Изображения не выбраны");
                return;
            }
        }

        private void LoadSoundsButton_Click(object sender, EventArgs e)
        {
            _sounds = LoadFiles("\"Sound Files|*.wav;*.mp3;*.ogg;*.flac\"");
            if (_sounds.Count() < 1)
            {
                MessageBox.Show("Звуки не выбраны");
                return;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Animal animal = null;
            if (_addMode)
            {
                if (AnimalNameTextBox.Text == "" || AnimalClassComboBox.Text == "" || _sounds.Count() == 0 || _images.Count() == 0)
                {
                    MessageBox.Show("Некоторые поля не заполнены");
                    return;
                }
                if(_animals.Where(i => i.Name.Equals(AnimalNameTextBox.Text)).Count() != 0)
                {
                    MessageBox.Show("Данное животное уже существует в программе");
                    return;
                }
                animal = new Animal(AnimalNameTextBox.Text, AnimalClassComboBox.Text);
                if (SaveAnimalFiles(animal, _images, "img") != 0)
                    MessageBox.Show("Не удалось загрузить изображения");
                if (SaveAnimalFiles(animal, _sounds, "sound") != 0)
                    MessageBox.Show("Не удалось загрузить звуки");
                if (_config.AddAnimal(animal) != 0)
                {
                    MessageBox.Show("Не удалось добавить животное");
                    return;
                }

                AnimalsListBox.Items.Add(animal.Name);
                MessageBox.Show("Сохранение прошло успешно");
            }
            else
            {
                //TODO: change animal logic
                Animal oldAnimal = _animals.Where(i => i.Name == AnimalsListBox.SelectedItem.ToString()).First();
                animal = new Animal(AnimalNameTextBox.Text, AnimalClassComboBox.Text, false);
                int soundLastElement = ChangeSoundsCheckBox.Checked ? 0 : _config.GetSoundsCount(oldAnimal.Name);
                int imagesLastElement = ChangeImagesCheckBox.Checked ? 0 : _config.GetImagesCount(oldAnimal.Name);

                if (AnimalNameTextBox.Text == "" || AnimalClassComboBox.Text == "")
                {
                    MessageBox.Show("Некоторые поля не заполнены");
                    return;
                }
                if (ChangeImagesCheckBox.Checked && _images.Count() == 0)
                {
                    MessageBox.Show("Изображения не выбраны");
                    return;
                }
                if (ChangeSoundsCheckBox.Checked && _sounds.Count() == 0)
                {
                    MessageBox.Show("Звуки не выбраны");
                    return;
                }

                //todo: move prev dir and remove prev dir
                if (oldAnimal.Name != animal.Name)
                    _config.RenameAnimalFolder(oldAnimal, AnimalNameTextBox.Text);

                animal.Name = AnimalNameTextBox.Text;
                animal.Class = AnimalClassComboBox.Text;
                animal.Path = _config.GetAnimalPath(animal.Name);
                if (_images.Count() > 0)
                    if (SaveAnimalFiles(animal, _images, "img", imagesLastElement, ChangeImagesCheckBox.Checked) != 0)
                        MessageBox.Show("Не удалось загрузить изображения");

                if (_sounds.Count() > 0)
                    if (SaveAnimalFiles(animal, _sounds, "sound", soundLastElement, ChangeSoundsCheckBox.Checked) != 0)
                        MessageBox.Show("Не удалось загрузить звуки");

                if (_config.ChangeAnimal(oldAnimal, animal) != 0)
                {
                    MessageBox.Show("Не удалось изменить запись");
                    return;
                }
                MessageBox.Show("Изменение прошло успешно");
                ChangeImagesCheckBox.Checked = false;
                ChangeSoundsCheckBox.Checked = false;
            }
            _animals = _config.GetAnimals();
            AnimalsListBox.Items.Clear();
            foreach (Animal toList in _animals)
                AnimalsListBox.Items.Add(toList.Name);
            _sounds.Clear();
            _images.Clear();
            AnimalClassComboBox.Text = "";
            AnimalNameTextBox.Clear();
        }

        private void AnimalsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_addMode || AnimalsListBox.SelectedIndex == -1 )
                return;

            Animal animal = new Animal();
            animal = _animals.Where(i => i.Name.Equals(AnimalsListBox.SelectedItem.ToString())).First();
            AnimalNameTextBox.Text = animal.Name;
            AnimalClassComboBox.Text = animal.Class;
            _sounds.Clear();
            _images.Clear();
        }
    }
}
