﻿using Admin.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using Store.classes;
using Cinema.classes;
using Primary.classes;
using ListAboutUser;
using Entertaiment;
using Сarshowroom;

class Program
{

        static AdminAction admin = new AdminAction();
        static List<string> history = new List<string>();
        static List<string> addtovar = new List<string>();
        static List<string> korzina = new List<string>();
       

         static Dictionary<string, int> balance = new Dictionary<string, int>()
        {
            {"MasterCard", 2000},
            {"Visa", 100},
            {"Money", 200},
        };

        static Dictionary<string, double> loginmearbejder = new Dictionary<string, double>
        {
            { "vova", 23102005 },
            { "employee1", 112233 },
            { "user123", 223344 }
        };

    static void Main(string[] args)
    {
        BuyerUser.LoadUsersFromJson("users.json");

        Console.WriteLine("Добро пожаловать в наш Торговый центр!");

        Console.Write("Куда хотите пойти? 1 - Магазин с Продуктами / 2 - Кинотеатр / 3 - Аптека / 4 - Развлекательный центр / 5 - Автосалон / 0 - Пойти домой");
        int placechoise;

        while (!int.TryParse(Console.ReadLine(), out placechoise) || placechoise <= 0 || placechoise > 5)
        {
            Console.WriteLine("Введите корректный выбор");
        }

        switch (placechoise)
        {
            case 0:
                Console.WriteLine("Пока");
                break;
            case 1:
                GotoStore();
                break;
            case 2:
                Cinema.classes.UsuallyCinema.AvailiblePlace();
                break;
            case 3:
                new Primary.classes.Primary().ManagePharmacy();
                break;
            case 4:
                new Entertaiment.EntertaimentforChild().AllFunction();
                break;
            case 5:
                Сarshowroom.Cars.Allfunction();
                break;
            
        }

        BuyerUser.SaveUsersToJson("users.json");




        static void GotoStore()
        {

            while (true)
            {
                Console.WriteLine("Добро пожаловать в магазин!");
                Console.Write("Выберите кто вы: 1 - Сотрудник / 2 - Админ / 3 - Покупатель / 0 - Выход: ");

                int choise;
                while (!int.TryParse(Console.ReadLine(), out choise) || (choise < 0 || choise > 4))
                {
                    Console.WriteLine("Ошибка! Введите 1 (Сотрудник), 2 (Покупатель) или 0 (Выход): ");
                }

                switch (choise)
                {
                    case 1:
                        Medarbdejder();
                        break;

                    case 2:
                        admin.AdminMenu();
                        break;

                    case 3:
                        Buyer();
                        break;

                    case 0:
                        Console.WriteLine("Выход из программы...");
                        return;
                }
            }
        }

        static void Medarbdejder()
        {
            Console.Clear();
            Login();
            Console.WriteLine("Добро пожаловать в личный кабинет!");

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.Write("1 - Логин / 2 - Добавить товары / 3 - Просмотреть все товары / 4 - Зарплата / 0 - Вернуться в меню: ");

                int choisemed;
                while (!int.TryParse(Console.ReadLine(), out choisemed) || choisemed < 0 || choisemed > 4)
                {
                    Console.WriteLine("Ошибка! Введите число от 0 до 4.");
                }

                switch (choisemed)
                {
                    case 0:
                        return;
                    case 1:
                        Login();
                        break;
                    case 2:
                        Addtovar();
                        break;
                    case 3:
                        CheckallTovar();
                        break;
                    case 4:
                        Salary();
                        break;
                }
            }
        }

        static void Buyer()
        {
            
            Console.Clear();
            BuyerUser.AllFunction();
            Console.WriteLine("Здравствуйте, покупатель!");

            while (true)
            {
                Console.Write("Выберите действие: 1 - Просмотреть склад / 2 - Купить товар / 3 - Корзина / 4 - История покупок / 0 - Вернуться в меню: ");
                int choisebuyer;
                while (!int.TryParse(Console.ReadLine(), out choisebuyer) || choisebuyer < 0 || choisebuyer > 4)
                {
                    Console.WriteLine("Ошибка! Введите число от 0 до 4 (0 - Вернуться в меню, 1 - Просмотреть склад, 2 - Купить товар, 3 - Корзина, 4 - История покупок).");
                }


                switch (choisebuyer)
                {
                    case 0:
                        return;
                    case 1:
                        Warehouse.ShowWarehouseForBuyer();
                        break;
                    case 2:
                        BuyTovar();
                        break;
                    case 3:
                        ItemsinKorzin();
                        break;
                    case 4:
                        ViewPurchaseHistory();
                        break;
                }
            }
        }
    }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Введите ваше имя: ");
            string namemed = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(namemed))
            {
                Console.WriteLine("Ваше имя не может быть пустым!");
                namemed = Console.ReadLine();
            }

            Console.WriteLine("Введите ваш пароль: ");
            int password;
            while (!int.TryParse(Console.ReadLine(), out password))
            {
                Console.WriteLine("Ошибка! Введите числовой пароль.");
            }

            if (loginmearbejder.TryGetValue(namemed, out double Storepassword))
            {
                if (Storepassword == password)
                {
                    Console.WriteLine("Доступ разрешен!");
                }
                else
                {
                    Console.WriteLine("Неверный пароль!");
                }
            }
            else
            {
                Console.WriteLine("Логин не найден!");
            }
        }

        static void Addtovar()
        {
            Console.Clear();
            Console.WriteLine("Название продукта: ");
            string nameoftovar = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(nameoftovar))
            {
                Console.WriteLine("Название товара не может быть пустым. Пожалуйста, введите название:");
                nameoftovar = Console.ReadLine();
            }

            Console.WriteLine("Стоимость товара: ");
            string prise = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(prise) || !double.TryParse(prise, out _))
            {
                Console.WriteLine("Введите корректную стоимость товара (число).");
                prise = Console.ReadLine();
            }

            addtovar.Add($"Название: {nameoftovar} | Цена: {prise}");
            Console.WriteLine("Товар успешно добавлен!");
        }

        static void CheckallTovar()
        {
            Console.Clear();
            if (addtovar.Count == 0)
            {
                Console.WriteLine("Нет добавленных товаров.");
            }
            else
            {
                Console.WriteLine("Все товары:");
                foreach (string item in addtovar)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void Salary()
        {
            Console.Clear();
            Console.Write("Сколько часов вы отработали?: ");
            int hourse;
            while (!int.TryParse(Console.ReadLine(), out hourse) || hourse < 0 || hourse > 200)
            {
                Console.WriteLine("Введите корректное количество часов (от 0 до 200).");
            }

            double normalt = 100;
            double sum = (hourse > 100)
                ? (100 * normalt) + ((hourse - 100) * (normalt * 1.5))
                : normalt * hourse;

            Console.WriteLine($"Ваша зарплата: {sum}");
        }

        static void BuyTovar()
        {
            Console.Clear();
            if (addtovar.Count == 0)
            {
                Console.WriteLine("Магазин пуст!");
                return;
            }

        Warehouse.ShowWarehouseForBuyer();
        Console.WriteLine("Все товары:");
            for (int i = 0; i < addtovar.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {addtovar[i]}");
            }

            Console.Write("Введите номер товара, который хотите купить: ");
            int choisebuyer;
            while (!int.TryParse(Console.ReadLine(), out choisebuyer) || choisebuyer <= 0 || choisebuyer > addtovar.Count)
            {
                Console.WriteLine("Ошибка! Введите корректный номер товара.");
            }

            string selectedTovar = addtovar[choisebuyer - 1];
            korzina.Add(selectedTovar);
            Console.WriteLine($"Товар \"{selectedTovar}\" добавлен в корзину!");
        }

        static void ItemsinKorzin()
        {
            Console.Clear();
            if (korzina.Count == 0)
            {
                Console.WriteLine("Корзина пуста.");
                return;
            }

            Console.WriteLine("Товары в вашей корзине:");
            foreach (var item in korzina)
            {
                Console.WriteLine(item);
            }

            CleartheKorzin();
            Console.Write("Перейти к оплате? (Да/Нет): ");
            string betale = Console.ReadLine().ToLower();

            if (betale == "да")
            {
                Console.WriteLine("Вы перешли к оплате.");
            }
            else
            {
                Console.WriteLine("Вы остались в магазине.");
            }
            Betale(CalculateTotalBalance());
            Discaunt();

        }

        static void Discaunt()
        {
            Console.WriteLine("У вас есть Скидочная карта нашего магазина? ");
            Console.Write("Да/Нет");
            string discountcard = Console.ReadLine();

            if (discountcard.ToLower() == "да")
            {
                Console.Write("Введите сколько денег на вашей скидочной карте: 100/200/300/400");
                int howmanymoney;

                 while (!int.TryParse(Console.ReadLine(), out howmanymoney) || howmanymoney < 100 || howmanymoney > 400)
            {
                    Console.WriteLine("Введите корректную сумму");
                }

                int totalprice = CalculateTotalBalance();

                if (howmanymoney > totalprice)
                {
                    Console.WriteLine("Скидка больше стоимости покупок! Вы ничего не платите");
                    korzina.Clear();
                    return;
                }

                totalprice -= howmanymoney;
                Console.WriteLine($"После скидки ваша сумма состяет: {totalprice}");

                Betale(totalprice);
            }
            else
            {
                Console.WriteLine("Вы продолжите без скидочной карты");
            }
        }

        static void CleartheKorzin()
        {
            Console.Clear();
            Console.WriteLine("Хотите ли вы убрать все товары с вашей корзины?");
            Console.Write("1 - да 2 - нет");
            int clear;

            while (!int.TryParse(Console.ReadLine(), out clear) || clear < 0 || clear > 3)
            {
                Console.WriteLine("Проверьте ваш ввод! От 1 до 2!");
            }

            if (clear == 1)
            {
                korzina.Clear();
                Console.WriteLine("Ваша корзина пуста");
                return;
            }
            else if (clear == 2)
            {
                Console.WriteLine("Вы оставили все товары в корзине");
                Betale(CalculateTotalBalance());
            }
        }

        static int CalculateTotalBalance()
        {
            Console.Clear();
            int total = 0;
            foreach (var item in korzina)
            {
                string priceString = item.Split("Цена: ")[1];
                total += int.Parse(priceString);
            }
            return total;
        }

    static void Betale(int totalbalance)
    {
        Console.WriteLine($"Выберите ваш способ оплаты..");
        Console.Write("1 - MasterCard / 2 - Visa / 3 - Наличка: ");
        int choisebetale;

        while (!int.TryParse(Console.ReadLine(), out choisebetale) || choisebetale < 1 || choisebetale > 3)
        {
            Console.WriteLine("Введите корректный способ оплаты!");
        }

        string choisemetod = choisebetale switch
        {
            1 => "MasterCard",
            2 => "Visa",
            3 => "Money",
            _ => throw new Exception("Неверный выбор способа оплаты!")
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

            history.AddRange(korzina);
            korzina.Clear();
        }
        else
        {
            Console.WriteLine("Недостаточно средств! Выберите другой способ оплаты.");
            Betale(totalbalance);
        }
    }

    static void ViewPurchaseHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("Истории покупок нет");
            }
            else
            {
                foreach (var item in history)
                {
                    Console.WriteLine($"Все товары: {item}");
                }
            }
        }
    }

        
