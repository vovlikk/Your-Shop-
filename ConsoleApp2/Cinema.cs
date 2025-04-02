namespace Cinema;
public class UsuallyCinema
{
    private static Dictionary<string, int> firsthall = new Dictionary<string, int>();
    private static Dictionary<string, int> secondhall = new Dictionary<string, int>();
    private static Dictionary<string, int> snacks = new Dictionary<string, int>()
    {
        {"Попкорн с Солью", 15},
        {"Попкорн с Беконом", 17},
        {"Чипсы + Кола", 50},
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

        int totalAmount = 0;  

        switch (choisethefilm)
        {
            case 1:
                totalAmount += FirstHall(); 
                break;
            case 2:
                totalAmount += SecondHall();  
                break;
            case 0:
                Console.WriteLine("Пока!");
                return;
        }

        Console.WriteLine("Теперь, давайте добавим снеки!");
        totalAmount += OrderSnacks(); 

        
        Betale(totalAmount);  
    }

    public static int FirstHall()
    {
        Console.WriteLine("Вы выбрали фильм 'Аквамен'!");
        Console.Write("Введите количество мест, которые хотите забронировать: ");

        int numberofseat;
        while (!int.TryParse(Console.ReadLine(), out numberofseat) || numberofseat <= 0 || numberofseat > 100)
        {
            Console.WriteLine("Ошибка! У нас всего 100 мест в кинотеатре. Введите корректное количество мест: ");
        }

        int totalAmount = 0;  
        if (firsthall.ContainsKey("Аквамен"))
        {
            if (firsthall["Аквамен"] + numberofseat > 100)
            {
                Console.WriteLine("Ошибка! Недостаточно свободных мест.");
            }
            else
            {
                firsthall["Аквамен"] += numberofseat;
                totalAmount += numberofseat * 15;  
                Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Аквамен'.");
            }
        }
        else
        {
            firsthall["Аквамен"] = numberofseat;
            totalAmount += numberofseat * 15;  
            Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Аквамен'.");
        }

        return totalAmount;  
    }

    public static int SecondHall()
    {
        Console.WriteLine("Вы выбрали фильм 'Человек-паук'!");
        Console.Write("Введите количество мест, которые хотите забронировать: ");

        int numberofseat;
        while (!int.TryParse(Console.ReadLine(), out numberofseat) || numberofseat <= 0 || numberofseat > 100)
        {
            Console.WriteLine("Ошибка! У нас всего 100 мест в кинотеатре. Введите корректное количество мест: ");
        }

        int totalAmount = 0; 
        if (secondhall.ContainsKey("Человек-паук"))
        {
            if (secondhall["Человек-паук"] + numberofseat > 100)
            {
                Console.WriteLine("Ошибка! Недостаточно свободных мест.");
            }
            else
            {
                secondhall["Человек-паук"] += numberofseat;
                totalAmount += numberofseat * 15;  
                Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Человек-паук'.");
            }
        }
        else
        {
            secondhall["Человек-паук"] = numberofseat;
            totalAmount += numberofseat * 15; 
            Console.WriteLine($"Вы успешно забронировали {numberofseat} мест(а) на 'Человек-паук'.");
        }

        return totalAmount;  
    }

    public static int OrderSnacks()
    {
        int totalAmount = 0;
        Console.WriteLine("Хотите выбрать снеки?");
        Console.WriteLine("1 - Да / 2 - Нет");
        int snackChoice;
        while (!int.TryParse(Console.ReadLine(), out snackChoice) || snackChoice < 1 || snackChoice > 2)
        {
            Console.WriteLine("Пожалуйста, выберите 1 (Да) или 2 (Нет).");
        }

        if (snackChoice == 1)
        {
            Console.WriteLine("Выберите снеки:");
            int i = 1;
            foreach (var snack in snacks)
            {
                Console.WriteLine($"{i++} - {snack.Key}, Цена: {snack.Value}");
            }

            Console.WriteLine("Введите номер выбранного снека:");
            int snackNumber;
            while (!int.TryParse(Console.ReadLine(), out snackNumber) || snackNumber < 1 || snackNumber > snacks.Count)
            {
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
            }

            var selectedSnack = new List<string>(snacks.Keys)[snackNumber - 1];
            totalAmount += snacks[selectedSnack];
            Console.WriteLine($"Вы выбрали {selectedSnack} за {snacks[selectedSnack]}.");
        }

        return totalAmount;
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
