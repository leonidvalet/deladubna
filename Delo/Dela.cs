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
   
    public partial class Dela : Form
    {
        public User user;
        public Dela(User user)
        {
            InitializeComponent();
            this.user = user;
            
        }

        public string[] sortDels(User user, string status)//Метод, сортирует в зависимости от статуса и кода дела
        {
            string search = user.getId() + " " + status;
            string filename = "Dels.txt";
            string path = Directory.GetCurrentDirectory();
            List<string> dels = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path + '\\' + filename))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(search))
                        {
                            dels.Add(line);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка в прочтении файла");
            }
            return dels.ToArray();
        }

        public void changeStatus(string search, string status)//Данный метод, меняет статус дела
        {
            string filename = "Dels.txt";
            string path = Directory.GetCurrentDirectory();
            int index = 0;
            int i = 0;
            using (StreamReader sr = new StreamReader(path + '\\' + filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line == search)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
            }
            string[] dels = File.ReadAllLines("Dels.txt");
            try
            {
                string[] words = dels[index].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string str = "";
                switch (status)
                {
                    case "В процессе":
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (j == words.Length - 2)
                            {
                                str += user.getId() + " ";
                            }
                            else if (j == words.Length - 1)
                            {
                                str += status + "\n";
                            }
                            else
                            {
                                str += words[j] + " ";
                            }
                        }
                        break;
                    case "Готово":
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (j == words.Length - 3)
                            {
                                str += user.getId() + " ";
                            }
                            else if (j == words.Length - 2)
                            {
                                str += status + "\n";
                                
                            } else if(j == words.Length - 1)
                            {
                                str += "";
                            }
                            else
                            {
                                str += words[j] + " ";
                            }
                        }
                        break;

                }
               
                dels[index] = str;
                File.WriteAllText("Dels.txt", "");
                StreamWriter sw = File.AppendText("Dels.txt");
                foreach (string delo in dels)
                {
                    sw.WriteLine(delo);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не выделили дело");
            }
        }

        private void Dela_Load(object sender, EventArgs e)//Метод, обновляет списки
        {
            doListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            DoneListBox.Items.Clear();
            doListBox.Items.AddRange(sortDels(user, "Сделать").ToArray());
            inProgressListBox.Items.AddRange(sortDels(user, "В процессе").ToArray());
            DoneListBox.Items.AddRange(sortDels(user, "Готово").ToArray());
        }

        private void addButton_Click(object sender, EventArgs e)//Переход на окно добавления дела
        {
            addDeloForm add = new addDeloForm(user);
            add.Show();
        }

        private void Dela_Activated(object sender, EventArgs e)//Метод, обновляет списки
        {
            doListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            DoneListBox.Items.Clear();
            doListBox.Items.AddRange(sortDels(user, "Сделать").ToArray());
            inProgressListBox.Items.AddRange(sortDels(user, "В процессе").ToArray());
            DoneListBox.Items.AddRange(sortDels(user, "Готово").ToArray());
        }

        private void changeButton_Click(object sender, EventArgs e)//Метод кнопки, изменяющий статус на в "В процессе"
        {
            string stroka = Convert.ToString(doListBox.SelectedItem);
            changeStatus(stroka, "В процессе");
            doListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            DoneListBox.Items.Clear();
            doListBox.Items.AddRange(sortDels(user, "Сделать").ToArray());
            inProgressListBox.Items.AddRange(sortDels(user, "В процессе").ToArray());
            DoneListBox.Items.AddRange(sortDels(user, "Готово").ToArray());
            
        }

        private void DoneTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Метод кнопки, изменяющий статус на в "Готово"
        {
            string stroka = Convert.ToString(inProgressListBox.SelectedItem);
            changeStatus(stroka, "Готово");
            doListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            DoneListBox.Items.Clear();
            doListBox.Items.AddRange(sortDels(user, "Сделать").ToArray());
            inProgressListBox.Items.AddRange(sortDels(user, "В процессе").ToArray());
            DoneListBox.Items.AddRange(sortDels(user, "Готово").ToArray());
           
        }

        private void button2_Click(object sender, EventArgs e)//Метод, удаляющий из готово
        {
            string item = Convert.ToString(DoneListBox.SelectedItem);
            var lines = File.ReadAllLines("Dels.txt").ToList();
            string filename = "Dels.txt";
            string path = Directory.GetCurrentDirectory();
            int index = 0;
            int i = 0;
            using (StreamReader sr = new StreamReader(path + '\\' + filename))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line == item)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
            }
            lines.RemoveAt(index);
            File.WriteAllLines("Dels.txt", lines);
            doListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            DoneListBox.Items.Clear();
            doListBox.Items.AddRange(sortDels(user, "Сделать").ToArray());
            inProgressListBox.Items.AddRange(sortDels(user, "В процессе").ToArray());
            DoneListBox.Items.AddRange(sortDels(user, "Готово").ToArray());
        }
    }
}
