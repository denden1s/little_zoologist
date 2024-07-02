using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Text;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;

namespace little_zoologist
{
    static class DataFolder
    {
#if DEBUG
        public static string defaultPath = @"C:\\Users\\Diana\\source\\repos\\little_zoologist\\little_zoologist\\.data\\";
#else
        public static string defaultPath = ".data\\";
#endif
    };


    public class Animal
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("class")]
        public string Class { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }


        public Animal() { }
        public Animal(string name, string animalClass, bool createFolder = true)
        {
            Name = name;
            Class = animalClass;
            Path = DataFolder.defaultPath + name + "\\";
            if (!createFolder)
                return;
            System.IO.Directory.CreateDirectory(Path);
            System.IO.Directory.CreateDirectory(Path + "/img/");
            System.IO.Directory.CreateDirectory(Path + "/sound/");


        }
    }

    public  class Configuration
    {
        private string defaultPath = DataFolder.defaultPath + "/animals.json";
        public class Root 
        {
            [JsonProperty("animals")]
            public List<Animal> Animals { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }
        Root animals;
        bool setupPassword = false;



        private string ComputeMD5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to a hexadecimal string.
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private int SerializeAnimals()
        {
            string json = JsonConvert.SerializeObject(animals);
            File.WriteAllText(defaultPath, json);
            return 0;
        }

        public Configuration()
        {
            if (!File.Exists(defaultPath))
                return;
            string json = File.ReadAllText(defaultPath);
           
            animals = JsonConvert.DeserializeObject<Root>(json);
            setupPassword = animals.Password != "";
        }

        public int AddAnimal(Animal animal)
        {
            animals.Animals.Add(animal);
            return SerializeAnimals();
        }

        public int ChangeAnimal(Animal oldAnimal, Animal newAnimal)
        {
            int index = animals.Animals.FindIndex(s => s == oldAnimal);

            if (index != -1)
                animals.Animals[index] = newAnimal;
            return SerializeAnimals();
        }

        public int GetSoundsCount(string name)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(DataFolder.defaultPath + name + "/sound/");
            return dir.GetFiles().Length;
        }

        public int GetImagesCount(string name)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(DataFolder.defaultPath  + name + "/img/");
            return dir.GetFiles().Length;
        }

        public List <Animal> GetAnimals()
        {
            return this.animals.Animals;
        }

        public bool PasswordStatus()
        {
            return setupPassword;
        }

        public int RemoveAnimal(string name)
        {
            Animal toDelete = null;
            foreach(Animal animal in animals.Animals)
            {
                if (name.Equals(animal.Name))
                {
                    toDelete = animal;
                    break;
                }
            }
            if (toDelete != null)
            {
                Directory.Delete(toDelete.Path, true);
                animals.Animals.Remove(toDelete);
                SerializeAnimals();
            }
            return 0;
        }

        public int SetPassword(string password)
        {
            if (setupPassword || password == null) return 1;
            animals.Password = ComputeMD5Hash(password);
            setupPassword = true;
            SerializeAnimals();
            return 0;
        }

        public string GetAnimalPath(string name)
        {
            return DataFolder.defaultPath + name;
        }

        public int RenameAnimalFolder(Animal animal, string newName)
        {
            string SourcePath = animal.Path;
            string DestinationPath = DataFolder.defaultPath + newName;
            Directory.Move(SourcePath, DestinationPath);
            return 0;
        }

        public int VerifyPassword(string password)
        {
            return ComputeMD5Hash(password) == animals.Password ? 0 : 1;
        }
    }
}
