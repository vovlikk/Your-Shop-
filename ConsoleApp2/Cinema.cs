using System;
using System.Collections.Generic;

namespace Cinema
{
    public class UsuallyCinema
    {
        private static Dictionary<string, int> firsthall = new Dictionary<string, int>();
        private static Dictionary<string, int> secondhall = new Dictionary<string, int>();
        private static Dictionary<string, int> snacks = new Dictionary<string, int>()
        {
            {"Попкорн c Солью",15},
            {"Попкорн с Беконом",17},
            {"Чипсы + Кола", 50 },
            {"Вода", 10}
        };

        static Dictionary<string, int> balance = new Dictionary<string, int>()
        {
            {"MasterCard", 2000},
            {"Visa", 100},
            {"Money", 200},
        };

        public static void AvailiblePlace()
        {
            Console.WriteLine("Здравствуйте!");

            Console.WriteLine("Выберите фильм для просмотра:");
            Console.WriteLine("1 - Аквамен");
            Console.WriteLine("2 - Человек-паук");
            Console.WriteLine("0 - Выход");

            int choisethefilm;
            while (!int.TryParse(Console.ReadLine(), out choisethefilm) || choisethefilm < 0 || choisethefilm > 2)
            {
                Console.WriteLine("Ошибка! Введите корректный номер фильма 1 - Аквамен / 2 - Человек-паук / 0 - Выход: ");
            }

            switch (choisethefilm)
            {
                case 1:
                    FirstHall();
                    break;
                case 2:
                    SecondHall();
                    break;
                case 0:
                    Console.WriteLine("Пока!");
                    break;
            }
        }

        public static void FirstHall()
        {
            Console.WriteLine("Вы выбрали фильм 'Аквамен'!");
            Console.Write("Введите количество мест, которые хотите забронировать: ");

            int numberofseat;
            while (!int.TryParse(Console.ReadLine(), out numberofseat) || numberofseat <= 0 || numberofseat > 100)
            {
                Console.WriteLine("Ошибка! У нас всего 100 мест в кинотеатре. Введите корректное количество мест: ");
            }

            if (firsthall.ContainsKey("Аквамен"))
            {
                if (firsthall["Аквамен"] + numberofseat > 100)
                {
                    Console.WriteLine("Ошибка! Недостаточно свободных мест.");
                }
                else
                {
                    firsthall["Аквамен"] += numberofseat;
                    Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Аквамен'.");
                }
            }
            else
            {
                firsthall["Аквамен"] = numberofseat;
                Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Аквамен'.");
            }

            Console.WriteLine("Так же у нас есть снеки!");
            Console.Write("Хотите просмотреть наличие? да/нет: ");
            string choise = Console.ReadLine(); 

            if (choise != null && choise.Equals("да", StringComparison.OrdinalIgnoreCase))
            {
                if (snacks.Count > 0)
                {
                    Console.WriteLine("Доступные снеки:");
                    foreach (var snack in snacks)
                    {
                        Console.WriteLine($"Название: {snack.Key}, Цена: {snack.Value} ");
                    }
                }
                else
                {
                    Console.WriteLine("Извините, но снеки закончились.");
                }
            }
            else if (choise != null && choise.Equals("нет", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Хорошего просмотра фильма!");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите да или нет");
            }


        }

        public static void SecondHall()
        {
            Console.WriteLine("Вы выбрали фильм 'Человек-паук'!");
            Console.Write("Введите количество мест, которые хотите забронировать: ");

            int numberofseat;
            while (!int.TryParse(Console.ReadLine(), out numberofseat) || numberofseat <= 0 || numberofseat > 100)
            {
                Console.WriteLine("Ошибка! У нас всего 100 мест в кинотеатре. Введите корректное количество мест: ");
            }

            if (secondhall.ContainsKey("Человек-паук"))
            {
                if (secondhall["Человек-паук"] + numberofseat > 100)
                {
                    Console.WriteLine("Ошибка! Недостаточно свободных мест.");
                }
                else
                {
                    secondhall["Человек-паук"] += numberofseat;
                    Console.WriteLine($"Вы успешно забронировали {numberofseat} на Человек-паука.");
                }
            }
            else
            {
                secondhall["Человек-паук"] = numberofseat;
                Console.WriteLine($"Вы успешно забронировали {numberofseat} на Человек-паук'");
            }


            Console.WriteLine("Так же у нас есть снеки!");
            Console.Write("Хотите просмотреть наличие? да/нет: ");
            string choise = Console.ReadLine();

            if (choise != null && choise.Equals("да", StringComparison.OrdinalIgnoreCase))
            {
                if (snacks.Count > 0)
                {
                    Console.WriteLine("Доступные снеки:");
                    foreach (var snack in snacks)
                    {
                        Console.WriteLine($"Название: {snack.Key}, Цена: {snack.Value} ");
                    }
                }
                else
                {
                    Console.WriteLine("Извините, но снеки закончились.");
                }
            }
            else if (choise != null && choise.Equals("нет", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Хорошего просмотра фильма!");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите да или нет");
            }
        }

        public static void Betale(int totalbalance)
        {
            Console.WriteLine("Оплачиваем товар...");
            Console.Write("Выберите способ оплаты: 1 - MasterCard / 2 - Visa / 3 - Наличка: ");

            int choisebetale;
            while (!int.TryParse(Console.ReadLine(), out choisebetale) || choisebetale < 1 || choisebetale > 3)
            {
                Console.WriteLine("Введите корректный способ оплаты: 1 - MasterCard / 2 - Visa / 3 - Наличка");
            }

            string choisemetod = choisebetale switch
            {
                1 => "MasterCard",
                2 => "Visa",
                3 => "Наличка",
                _ => throw new Exception("Неверный способ оплаты")
            };

            if (!balance.ContainsKey(choisemetod))
            {
                Console.WriteLine($"Ошибка! Способ оплаты {choisemetod} отсутствует в системе.");
                return;
            }

            if (balance[choisemetod] >= totalbalance)
            {
                balance[choisemetod] -= totalbalance;
                Console.WriteLine("Проходит оплата...");
                Thread.Sleep(2000); 

                Console.WriteLine($"Оплата прошла успешно! Использовано: {choisemetod}, Остаток: {balance[choisemetod]}");
            }
            else
            {
                Console.WriteLine("Ошибка! Недостаточно средств на выбранном способе оплаты.");
            }
        }

    }
}
