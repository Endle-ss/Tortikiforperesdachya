using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tortiki
{
    public class Zakaz
    {
        private decimal lastsold = 0;
        private string userchoice = "";
        private decimal[][] priiice = {
        new decimal[] { 350, 450, 200, 700 },
        new decimal[] { 100, 200, 300, 400 },
        new decimal[] { 150, 150, 300, 500 },
        new decimal[] { 200, 300, 400, 500 }
    };
        private string[][] cakes = {
        new string[] { "Круг - 500 рублей", "Квадрат - 600 рублей", "Овал - 300 рублей", "Невероятная звезда - 1000 рублей" },
        new string[] { "3 порции - 100 рублей", "5 порций - 200 рублей", "10 порций - 300 рублей", "15 порций - 500 рублей" },
        new string[] { "Шоколадный - 150 рублей", "Ванильный - 150 рублей", "Клубничный - 300 рублей", "Комбо из вкусов (любой на выбор) - 500 рублей" },
        new string[] { "5 коржей - 200 рублей", "8 коржей - 400 рублей", "10 коржей -550 рублей", "15 коржей - 800 рублей" }
    };
        private string[] specifications = { "Форма торта", "Количество порций", "Вкус коржей", "Количество коржей", "Сделать новый заказ" };
        public void Createzakaz()
        {
            int portion = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ДОБРО ПОЖАЛОВАТЬ В КОНДИТЕРСКУЮ ПЕРЕСДАЧ!!!!");
                Console.WriteLine("Выберите что хотите выбрать:");
                Console.WriteLine(new string('*', 50));
                for (int i = 0; i < specifications.Length; i++)
                {
                    if (i == portion)
                    {
                        Console.Write("-> ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                    Console.WriteLine(specifications[i]);
                }
                Console.WriteLine(new string('*', 50));
                Console.WriteLine($"Цена тортика: {lastsold} руб.");
                Console.WriteLine(new string('*', 50));
                Console.WriteLine("Ваш торт: " + userchoice);
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        if (portion > 0)
                        {
                            portion--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (portion < specifications.Length - 1)
                        {
                            portion++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (portion == specifications.Length - 1)
                        {
                            saveinfile();
                            lastsold = 0;
                            userchoice = "";
                        }
                        else
                        {
                            int menuchoice = Classmenu.shouuu(cakes[portion]);
                            decimal price = priiice[portion][menuchoice];
                            lastsold += price;
                            if (!string.IsNullOrEmpty(userchoice))
                            {
                                userchoice += ", ";
                            }
                            userchoice += $"{specifications[portion]} - {cakes[portion][menuchoice]}";
                        }
                        break;
                    case ConsoleKey.Escape:
                        userchoice = "";
                        break;
                }
            }
        }
        public void saveinfile()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = Path.Combine(desktopPath, "Заказ.txt");
            string orderDetails = $"{DateTime.Now}: Ваш торт: {userchoice}, Итоговая цена: {lastsold} руб.";
            File.AppendAllText(fileName, orderDetails + Environment.NewLine);
            Console.WriteLine($"Заказ сохранен в файле 'Заказ.txt'");
        }
    }
}
