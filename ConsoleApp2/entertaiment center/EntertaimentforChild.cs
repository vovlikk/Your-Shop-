using System;
using System.Collections.Generic;

namespace Entertaiment
{
    public class EntertaimentforChild
    {
        public void AllFunction()
        {
            Console.WriteLine("Добро пожаловать в развлекательный центр");
            Console.Write("Какие горки хотите посетить? 1 - Батуты + Горки / 2 - ChillZone / 3 - Выход: ");

            string choisetheintertaiment = Console.ReadLine();

            switch (choisetheintertaiment)
            {
                case "1":
                    TrampolinesSlides();
                    break;
                case "2":
                    ChillZone();
                    break;
                case "3":
                    Console.WriteLine("Пока!");
                    break;
                default:
                    Console.WriteLine("Введите правильное число от 1 до 3");
                    break;
            }
        }

        private static void TrampolinesSlides()
        {
            Console.WriteLine("Вы выбрали тариф Батуты + Горки");
            Console.Write("Сколько времени хотите провести на площадке? 1 час - 50 dkk: ");

            if (int.TryParse(Console.ReadLine(), out int hours))
            {
                int oneHourPrice = 50;
                int totalPrice = hours * oneHourPrice;

                Console.WriteLine($"Ваш чек выходит на: {totalPrice} dkk за {hours} ч.");
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите корректное количество часов.");
            }
        }

        private static void ChillZone()
        {
            Console.WriteLine("\nВы выбрали ChillZone.");
            Console.WriteLine("Что у нас есть:");
            Console.WriteLine("1 - PS5");
            Console.WriteLine("2 - Настольный футбол");
            Console.WriteLine("3 - Выйти в меню");

            Queue<string> ps5Queue = new Queue<string>();
            Queue<string> footballQueue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Встать в очередь на PS5");
                Console.WriteLine("2 - Встать в очередь на настольный футбол");
                Console.WriteLine("3 - Вызвать следующего на PS5");
                Console.WriteLine("4 - Вызвать следующего на футбол");
                Console.WriteLine("5 - Назад в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя для очереди на PS5: ");
                        string psName = Console.ReadLine();
                        ps5Queue.Enqueue(psName);
                        Console.WriteLine($"{psName} добавлен в очередь на PS5.");
                        break;

                    case "2":
                        Console.Write("Введите имя для очереди на футбол: ");
                        string footballName = Console.ReadLine();
                        footballQueue.Enqueue(footballName);
                        Console.WriteLine($"{footballName} добавлен в очередь на футбол.");
                        break;

                    case "3":
                        if (ps5Queue.Count > 0)
                        {
                            string nextPs5 = ps5Queue.Dequeue();
                            Console.WriteLine($"Следующий на PS5: {nextPs5}");
                        }
                        else
                        {
                            Console.WriteLine("Очередь на PS5 пуста.");
                        }
                        break;

                    case "4":
                        if (footballQueue.Count > 0)
                        {
                            string nextFootball = footballQueue.Dequeue();
                            Console.WriteLine($"Следующий на футбол: {nextFootball}");
                        }
                        else
                        {
                            Console.WriteLine("Очередь на футбол пуста.");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
