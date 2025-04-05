using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Primary.classes
{
    public class Apotek
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool RequiresPrescription { get; set; }

        public Apotek(string name, int price, string description, bool requiresPrescription)
        {
            Name = name;
            Price = price;
            Description = description;
            RequiresPrescription = requiresPrescription;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name} | Цена: {Price} DKK | Описание: {Description} | Рецепт: {(RequiresPrescription ? "Да" : "Нет")}");
        }
    }

    public class Primary
    {
        private List<Apotek> list;

        public Primary()
        {
            list = new List<Apotek>()
            {
                new Apotek("Парацетамол", 20, "Обезболивающее и жаропонижающее", false),
                new Apotek("Антибиотик", 200, "Антибактериальный препарат", true),
                new Apotek("Витамин С", 100, "Поддержка иммунитета", false)
            };
        }

        public void ManagePharmacy()
        {
            while (true)
            {
                Console.WriteLine("Вы в аптеке. 1 - Посмотреть лекарства / 2 - Купить лекарство / 0 - Выйти");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllMedicine();
                        break;
                    case "2":
                        BuyMedicine();
                        break;
                    case "0":
                        Console.WriteLine("Выход из аптеки...");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        public void ShowAllMedicine()
        {
            Console.WriteLine("Список доступных лекарств:");
            Thread.Sleep(1000);

            foreach (Apotek item in list)
            {
                item.DisplayInfo();
            }
        }

        public void BuyMedicine()
        {
            Console.Write("Введите название лекарства для покупки: ");
            string userChoice = Console.ReadLine().ToLower();

            var selectedMed = list.FirstOrDefault(m => m.Name.ToLower() == userChoice);

            if (selectedMed == null)
            {
                Console.WriteLine("Такого лекарства нет.");
                return;
            }

            if (selectedMed.RequiresPrescription)
            {
                Console.Write("Для этого лекарства нужен рецепт. У вас есть рецепт? (да/нет): ");
                if (Console.ReadLine()?.ToLower() != "да")
                {
                    Console.WriteLine("Извините, но мы не можем вам продать это лекарство.");
                    return;
                }
            }

            Console.WriteLine("Выберите способ оплаты: 1 - Наличные / 2 - Карта");
            string paymentMethod = Console.ReadLine();

            if (paymentMethod == "1")
            {
                Console.WriteLine($"Вы успешно купили {selectedMed.Name} за {selectedMed.Price} DKK наличными.");
            }
            else if (paymentMethod == "2")
            {
                Console.Write("Введите тип карты (MasterCard/Visa): ");
                string cardType = Console.ReadLine();

                Console.Write("Введите 8 цифр карты: ");
                string cardNumber = Console.ReadLine();

                if (!ValidateCard(cardNumber))
                {
                    Console.WriteLine("Ошибка: Неверный номер карты.");
                    return;
                }

                if (ProcessPayment(cardType, selectedMed.Price))
                {
                    Console.WriteLine($"Вы успешно купили {selectedMed.Name} за {selectedMed.Price} DKK картой.");
                }
                else
                {
                    Console.WriteLine("Ошибка: Недостаточно средств на карте.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Неверный способ оплаты.");
            }
        }

        private bool ValidateCard(string cardNumber)
        {
            return cardNumber.Length == 8 && cardNumber.All(char.IsDigit);
        }

        private bool ProcessPayment(string cardType, int amount)
        {
            var cards = new Dictionary<string, int>
            {
                { "MasterCard", 2000 },
                { "Visa", 1500 }
            };

            if (!cards.ContainsKey(cardType))
            {
                Console.WriteLine("Ошибка: Карта не найдена.");
                return false;
            }

            if (cards[cardType] < amount)
            {
                return false;
            }

            cards[cardType] -= amount;
            return true;
        }
    }
}
