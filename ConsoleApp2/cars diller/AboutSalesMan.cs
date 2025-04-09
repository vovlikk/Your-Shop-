using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сarshowroom;

namespace AboutSales
{
    public class AboutSalesMan
    {
        public static void AllFunction()
        {
            while (true)
            {
                Console.WriteLine("Здравствуй, Продавец!");
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("1 - Добавить машину");
                Console.WriteLine("2 - Показать все машины");
                Console.WriteLine("3 - Удалить машину по имени");
                Console.WriteLine("0 - Назад");

                string choisesales = Console.ReadLine();

                switch (choisesales)
                {
                    case "0":
                        return;
                    case "1":
                        AddCars();
                        break;
                    case "2":
                        ShowAllCars();
                        break;
                    case "3":
                        RemoveCar();
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод. Повторите.");
                        break;
                }
            }
        }


        public static  void AddCars()
        {
            Console.Write("Введите название машины: ");
            string nameofcar = Console.ReadLine();

            Console.Write("Введите прайс машины: ");
            int price = int.Parse(Console.ReadLine());

            Console.Write("Введите описание машины: ");
            string discription = Console.ReadLine();

            new Cars(nameofcar, price, discription);
            Console.WriteLine("Машина добавлена в список");
        }

        public static void ShowAllCars()
        {
            Console.WriteLine("Все доступные машины");
            foreach (var all in Cars.Allcar)
            {
                Console.WriteLine($"Name: {all.NameofCar}  Price: {all.Price} Description: {all.Description}");
            }
            AllFunction();
        }
        public static void RemoveCar()
        {
            Console.Write("Введите имя машины которую удалить: ");
            string name = Console.ReadLine();

            var carremove = Cars.Allcar.FirstOrDefault(c => c.NameofCar ==  name);
            if (carremove != null)
            {
                Cars.Allcar.Remove(carremove);
                Console.WriteLine("Машина удалена");
            }
            else
            {
                Console.WriteLine("Машина не найдена");
            }
        }
    }
}
