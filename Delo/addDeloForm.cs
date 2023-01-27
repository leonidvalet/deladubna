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
    public partial class addDeloForm : Form
    {
        public User user;
        public addDeloForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void addButton_Click(object sender, EventArgs e)//Добавляет дело в список "Сделать"
        {
            string filename = "Dels.txt";
            string path = Directory.GetCurrentDirectory();
            Dels dels = new Dels(descriptionTextBox.Text, dateTimePicker.Text, executorTextBox.Text);
            File.AppendAllText(path + '\\' + filename, dels.getDescription() + " " + dels.getDate() + " " + dels.getExecutor() + " " + user.getId() + " " + dels.getStatus() + "\n");
            Hide();
        }

        private void addDeloForm_Load(object sender, EventArgs e)
        {

        }
    }
}
