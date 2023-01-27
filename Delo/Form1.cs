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

namespace Delo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registrationButton_Click(object sender, EventArgs e)//Переход на окно регистрации
        {
            Registration registration = new Registration();
            registration.Show();
            Hide();
        }

        private void autorizationTextBox_Click(object sender, EventArgs e)//Метод, производящий авторизация
        {
            string search = loginTextBox.Text + " " + passwordTextBox.Text + " "; 
            string filename = "FileForRegistration.txt";
            string path = Directory.GetCurrentDirectory();

            try
            {
                using (StreamReader sr = new StreamReader(path + '\\' + filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(search))
                        {
                            string[] words = line.Split(' ');
                            User user = new User(words[0], words[1], words[2], Convert.ToInt16(words[3]));
                            Dela dela = new Dela(user);
                            dela.Show();
                            Hide();
                        }
                    }
                }
            }
            catch (Exception )
            {
                Console.WriteLine("Ошибка в прочтении файла");
            }
          
        }
    }
}
