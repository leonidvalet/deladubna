using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delo
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)//Переход на авторизацию
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void registrationButton_Click(object sender, EventArgs e)//Регистрация пользователя
        {
            string filename = "FileForRegistration.txt";
            string path = Directory.GetCurrentDirectory();
            int usersCount;
            try
            {
               usersCount = File.ReadAllLines("FileForRegistration.txt").Count() + 1;
            }catch(Exception ex)
            {
               usersCount = 1;
            }
            User user = new User(FIOTextBox.Text, loginTextBox.Text, passwordTextBox.Text, usersCount);
            File.AppendAllText(path + '\\' + filename, user.getName() + " " + user.getLogin() + " " + user.getPassword() + " " + usersCount.ToString() + "\n");
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void FIOTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
