using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delo
{
    public class User//Класс пользователь
    {
        private string name;//Поле имя
        private string login;//Поле логин
        private string password;//Поле пароль
        private int id;//Поле код

        public User(string name, string login, string password, int id)//Конструктор пользователя
        {
            this.name = name;   
            this.login = login;
            this.password = password;
            this.id = id;
        }

        public string getName()//Получить имя
        {
            return name;
        }
         
        public int getId()//Получить код
        {
         return id;
        }

        public void setId(int id)//Присвоить код
        { 
        this.id=id;
        }
        public string getLogin()//Получить логин
        {
            return login;
        }

        public string getPassword()//Получить пароль
        {
            return password;    
        }

        public void setName(string name)//Присвоить имя
        {
            this.name = name;
        }

        public void setPassword(string password)//Присвоить пароль
        {
            this.password = password;
        }

        public void setLogin(string login)//Присвоить пароль
        {
            this.login = login;
        }

    }
}
