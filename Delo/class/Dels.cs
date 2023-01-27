using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delo
{
    public class Dels//Класс Дела
    {

        private string description;//Поле текстовое описание
        private string date;//Поле дата
        private string executor;//Поле исполнитель
        private string status;//Поле статус

        public Dels(string description, string date, string executor, string status)//Конструктор, с добавлением статуса
        {
            this.description = description;
            this.date = date;
            this.executor = executor;
            this.status = status;
        }

        public Dels(string description, string date, string executor)//Конструктор, со статусом "Сделать"
        {
            this.description = description;
            this.date = date;
            this.executor = executor;
            this.status = "Сделать";
        }

        public string getDescription()//Получить текстовое описание
        {
            return description;
        }

        public string getDate()//Получить дату
        {
            return date;
        }

        public string getExecutor()//Получить исполнителя
        {
            return executor;
        }

        public string getStatus()//Получить статус
        {
            return status;
        }

        public void setDescription(string description)//Присвоить текстовое описание
        {
            this.description = description;
        }

        public void setDate(string date)//Присвоить дату
        {
            this.date = date;
        }

        public void setExecutor(string executor)//Присвоить исполнителя
        {
            this.executor = executor;
        }

        public void setStatus(string status)//Присвоить статус
        {
            this.status = status;
        }
        
    }
}
