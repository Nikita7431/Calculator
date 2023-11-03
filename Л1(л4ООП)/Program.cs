using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using Л1;

namespace Л1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            People people = new People();
            while (true)
            {
                Console.Write("Ввести нового пользователя? да/нет ");
                string st = Console.ReadLine();
                if (st == "да")
                {
                    Console.WriteLine("\n\nВвод данных пользователя ");
                    Console.Write($"Имя: ");
                    people.Name = Console.ReadLine();
                    Console.Write($"Фамилия: ");
                    people.Family = Console.ReadLine();
                    Console.Write($"Возраст: ");
                    people.Age = Convert.ToInt32(Console.ReadLine());


                    Console.Write("Выводить ли возраст? Введите да/нет ");
                    string s = Console.ReadLine();
                    if (s == "да")
                    {
                        Console.WriteLine(people.GetInfo());
                    }
                    else if (s == "нет")
                    {
                        Console.WriteLine(people.GetInfo(false));
                    }
                }
                else break;

            }



        }

    }

    class People
    {
        private string name, family;
        private int age;
        private bool age25;

        public string Name { get => name; set => name = value; }
        public string Family
        {
            get { return family; }
            set { family = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age >= 0)
                    age = value;
            }
        }

        public bool Age25
        {
            get
            {
                if (Age < 25)
                    return true;
                else
                    return false;
            }
        }

        
        public string GetInfo(bool includeIntProperty)
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            StringBuilder str = new StringBuilder();


            foreach (PropertyInfo property in properties)
            {
                if (!includeIntProperty && property.PropertyType == typeof(int))
                {
                    continue;
                }

                var value = property.GetValue(this);
                str.Append($"{value} ");
            }
            Console.WriteLine();
            return str.ToString();
        }






    }
}





