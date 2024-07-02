namespace little_zoologist
{
    partial class CRUDForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CRUDForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddModePictureBox = new System.Windows.Forms.PictureBox();
            this.EditModePictureButton = new System.Windows.Forms.PictureBox();
            this.RemovePictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnimalsListBox = new System.Windows.Forms.ListBox();
            this.AddAndEditPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadSoundsButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.LoadPicsButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AnimalClassComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AnimalNameTextBox = new System.Windows.Forms.TextBox();
            this.ChangeImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.ChangeSoundsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddModePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditModePictureButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemovePictureBox)).BeginInit();
            this.AddAndEditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(692, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AddModePictureBox
            // 
            this.AddModePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.AddModePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AddModePictureBox.Image")));
            this.AddModePictureBox.Location = new System.Drawing.Point(2, 55);
            this.AddModePictureBox.Name = "AddModePictureBox";
            this.AddModePictureBox.Size = new System.Drawing.Size(107, 107);
            this.AddModePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddModePictureBox.TabIndex = 2;
            this.AddModePictureBox.TabStop = false;
            this.AddModePictureBox.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // EditModePictureButton
            // 
            this.EditModePictureButton.BackColor = System.Drawing.Color.Transparent;
            this.EditModePictureButton.Image = ((System.Drawing.Image)(resources.GetObject("EditModePictureButton.Image")));
            this.EditModePictureButton.Location = new System.Drawing.Point(115, 55);
            this.EditModePictureButton.Name = "EditModePictureButton";
            this.EditModePictureButton.Size = new System.Drawing.Size(107, 107);
            this.EditModePictureButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EditModePictureButton.TabIndex = 3;
            this.EditModePictureButton.TabStop = false;
            this.EditModePictureButton.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // RemovePictureBox
            // 
            this.RemovePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.RemovePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("RemovePictureBox.Image")));
            this.RemovePictureBox.Location = new System.Drawing.Point(228, 55);
            this.RemovePictureBox.Name = "RemovePictureBox";
            this.RemovePictureBox.Size = new System.Drawing.Size(107, 107);
            this.RemovePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RemovePictureBox.TabIndex = 4;
            this.RemovePictureBox.TabStop = false;
            this.RemovePictureBox.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(223, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = " Редактирование списка животных";
            // 
            // AnimalsListBox
            // 
            this.AnimalsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AnimalsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AnimalsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnimalsListBox.FormattingEnabled = true;
            this.AnimalsListBox.ItemHeight = 24;
            this.AnimalsListBox.Location = new System.Drawing.Point(12, 186);
            this.AnimalsListBox.Name = "AnimalsListBox";
            this.AnimalsListBox.Size = new System.Drawing.Size(323, 480);
            this.AnimalsListBox.TabIndex = 6;
            this.AnimalsListBox.SelectedIndexChanged += new System.EventHandler(this.AnimalsListBox_SelectedIndexChanged);
            // 
            // AddAndEditPanel
            // 
            this.AddAndEditPanel.Controls.Add(this.ChangeSoundsCheckBox);
            this.AddAndEditPanel.Controls.Add(this.ChangeImagesCheckBox);
            this.AddAndEditPanel.Controls.Add(this.SaveButton);
            this.AddAndEditPanel.Controls.Add(this.LoadSoundsButton);
            this.AddAndEditPanel.Controls.Add(this.label5);
            this.AddAndEditPanel.Controls.Add(this.LoadPicsButton);
            this.AddAndEditPanel.Controls.Add(this.label4);
            this.AddAndEditPanel.Controls.Add(this.AnimalClassComboBox);
            this.AddAndEditPanel.Controls.Add(this.label3);
            this.AddAndEditPanel.Controls.Add(this.label2);
            this.AddAndEditPanel.Controls.Add(this.AnimalNameTextBox);
            this.AddAndEditPanel.Location = new System.Drawing.Point(341, 293);
            this.AddAndEditPanel.Name = "AddAndEditPanel";
            this.AddAndEditPanel.Size = new System.Drawing.Size(447, 358);
            this.AddAndEditPanel.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(8, 322);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(436, 33);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadSoundsButton
            // 
            this.LoadSoundsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadSoundsButton.Location = new System.Drawing.Point(193, 270);
            this.LoadSoundsButton.Name = "LoadSoundsButton";
            this.LoadSoundsButton.Size = new System.Drawing.Size(251, 33);
            this.LoadSoundsButton.TabIndex = 11;
            this.LoadSoundsButton.Text = "Загрузить";
            this.LoadSoundsButton.UseVisualStyleBackColor = true;
            this.LoadSoundsButton.Click += new System.EventHandler(this.LoadSoundsButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Звуки";
            // 
            // LoadPicsButton
            // 
            this.LoadPicsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadPicsButton.Location = new System.Drawing.Point(193, 182);
            this.LoadPicsButton.Name = "LoadPicsButton";
            this.LoadPicsButton.Size = new System.Drawing.Size(254, 33);
            this.LoadPicsButton.TabIndex = 8;
            this.LoadPicsButton.Text = "Загрузить";
            this.LoadPicsButton.UseVisualStyleBackColor = true;
            this.LoadPicsButton.Click += new System.EventHandler(this.LoadPicsButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Изображения";
            // 
            // AnimalClassComboBox
            // 
            this.AnimalClassComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnimalClassComboBox.FormattingEnabled = true;
            this.AnimalClassComboBox.Items.AddRange(new object[] {
            "Домашнее",
            "Дикое"});
            this.AnimalClassComboBox.Location = new System.Drawing.Point(193, 99);
            this.AnimalClassComboBox.Name = "AnimalClassComboBox";
            this.AnimalClassComboBox.Size = new System.Drawing.Size(251, 28);
            this.AnimalClassComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Класс";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Название";
            // 
            // AnimalNameTextBox
            // 
            this.AnimalNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnimalNameTextBox.Location = new System.Drawing.Point(193, 3);
            this.AnimalNameTextBox.Name = "AnimalNameTextBox";
            this.AnimalNameTextBox.Size = new System.Drawing.Size(251, 26);
            this.AnimalNameTextBox.TabIndex = 0;
            // 
            // ChangeImagesCheckBox
            // 
            this.ChangeImagesCheckBox.AutoSize = true;
            this.ChangeImagesCheckBox.Location = new System.Drawing.Point(172, 193);
            this.ChangeImagesCheckBox.Name = "ChangeImagesCheckBox";
            this.ChangeImagesCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ChangeImagesCheckBox.TabIndex = 13;
            this.ChangeImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChangeSoundsCheckBox
            // 
            this.ChangeSoundsCheckBox.AutoSize = true;
            this.ChangeSoundsCheckBox.Location = new System.Drawing.Point(172, 281);
            this.ChangeSoundsCheckBox.Name = "ChangeSoundsCheckBox";
            this.ChangeSoundsCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ChangeSoundsCheckBox.TabIndex = 14;
            this.ChangeSoundsCheckBox.UseVisualStyleBackColor = true;
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 682);
            this.Controls.Add(this.AddAndEditPanel);
            this.Controls.Add(this.AnimalsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemovePictureBox);
            this.Controls.Add(this.EditModePictureButton);
            this.Controls.Add(this.AddModePictureBox);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CRUDForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUDForm";
            this.Load += new System.EventHandler(this.CRUDForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddModePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditModePictureButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RemovePictureBox)).EndInit();
            this.AddAndEditPanel.ResumeLayout(false);
            this.AddAndEditPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox AddModePictureBox;
        private System.Windows.Forms.PictureBox EditModePictureButton;
        private System.Windows.Forms.PictureBox RemovePictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox AnimalsListBox;
        private System.Windows.Forms.Panel AddAndEditPanel;
        private System.Windows.Forms.TextBox AnimalNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AnimalClassComboBox;
        private System.Windows.Forms.Button LoadSoundsButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LoadPicsButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox ChangeSoundsCheckBox;
        private System.Windows.Forms.CheckBox ChangeImagesCheckBox;
    }
}