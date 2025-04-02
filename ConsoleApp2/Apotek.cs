using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Apotek
{
    public class Apotek
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public bool RequiesPrescription { get; set; }

        public Apotek(string name, int price, string discription, bool requiesprescription)
        {
            Name = name;
            Price = price;
            Discription = discription;
            RequiesPrescription = requiesprescription;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Название: {Name} Цена: {Price} Описание: {Discription}  Рецепт: {RequiesPrescription}");
        }
    }

    public class Primary
    {
        private List<Apotek> list;

        public Primary()
        {
            list = new List<Apotek>()
            {
                new Apotek("Парацетамол", 20, "Обезбаливающее и жаропонижающее", false),
                new Apotek("Антибиотик", 200, "Актибактериальный препарат", false),
                new Apotek("Витамин С", 100, "Поддержка иммунитета", true)
            };
        }

        public void ShowAllMedecine()
        {
            Console.WriteLine("Наличие в нашей аптеке...");
            Console.WriteLine("Минуточку");
            Thread.Sleep(2000);

            foreach (Apotek item in list)
            {
                item.DisplayInfo();
            }
        }

        public void BuyMedicine()
        {
            Console.Write("Введите Название лекарства для покупки: ");
            string UserChoise = Console.ReadLine();

            var selectedmed = list.FirstOrDefault(m => m.Name.ToLower() == UserChoise.ToLower());

            if (selectedmed != null)
            {
                if (selectedmed.RequiesPrescription)
                {
                    Console.WriteLine($"Для {selectedmed.Name} нужен рецепт. У вас есть рецепт? (да/нет) ");
                    string hasPrescription = Console.ReadLine().ToLower();

                    if (hasPrescription != "да")
                    {
                        Console.WriteLine("Извините, но мы не можем вам продать это лекарство.");
                        return;
                    }
                }

                Console.WriteLine("Выберите способ оплаты: 1 - Наличка / 2 - Карта");
                string choisemetodpay = Console.ReadLine();

                if (choisemetodpay == "1")
                {
                    Console.WriteLine($"Вы успешно купили {selectedmed.Name} за {selectedmed.Price} dkk наличными.");
                }
                else if (choisemetodpay == "2")
                {
                    Console.Write("Введите тип карты (например, MasterCard): ");
                    string cardType = Console.ReadLine();

                    Console.Write("Введите 16 цифр карты: ");
                    string cardNumber = Console.ReadLine();

                    if (ValidateCard(cardNumber))
                    {
                        if (ProcessPayment(cardType, selectedmed.Price))
                        {
                            Console.WriteLine($"Вы успешно купили {selectedmed.Name} за {selectedmed.Price} dkk Картой.");
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Недостаточно средств на карте.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Неверный номер карты.");
                    }
                }
                else
                {
                    Console.WriteLine("Такого лекарства нет.");
                }
            }
            else
            {
                Console.WriteLine("Такого лекарства нет.");
            }
        }

        private bool ValidateCard(string cardNumber)
        {
            return cardNumber.Length == 16 && cardNumber.All(char.IsDigit);
        }

        private bool ProcessPayment(string cardType, int amount)
        {
            Dictionary<string, int> cards = new Dictionary<string, int>()
            {
                {"MasterCard", 2000},
                {"Visa", 1500},
                {"Money", 100}
            };

           
            if (cards.ContainsKey(cardType))
            {
                int balance = cards[cardType];

                if (balance >= amount)
                {
                    
                    cards[cardType] -= amount;
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Карта не найдена.");
                return false;
            }
        }
    }
}
