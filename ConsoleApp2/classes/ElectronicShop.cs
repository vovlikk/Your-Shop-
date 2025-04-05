using System;
using Database;

namespace ConsoleApp2.classes
{
    public class ElectronicShop
    {
        private DatabaseManager db;

        // Конструктор класса ElectronicShop
        public ElectronicShop()
        {
            db = new DatabaseManager();
            db.CreateDatabase(); // Создание базы данных при запуске
        }

        // Метод для взаимодействия с пользователем
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1 - Добавить продукт");
                Console.WriteLine("2 - Показать все продукты");
                Console.WriteLine("0 - Выйти");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Введите название продукта:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите цену продукта:");
                    double price = double.Parse(Console.ReadLine());

                    db.AddProduct(name, price);
                    Console.WriteLine("Продукт добавлен.");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Список продуктов:");
                    db.DisplayProducts();
                }
                else if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}
