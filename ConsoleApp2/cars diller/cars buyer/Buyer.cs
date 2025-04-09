using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сarshowroom;

namespace Buyer
{
    public class BuyerCar
    {
        public static void AllFunction()
        {

            while (true) 
            {
                Console.Clear();  
                Console.WriteLine("Привет покупатель!");
                Console.WriteLine("Выбери что тебе нужно:");
                Console.WriteLine("1 - Посмотреть машины");
                Console.WriteLine("2 - Купить машину");
                Console.WriteLine("3 - Взять в Аренду");
                Console.WriteLine("4 - Попросить помыть машину (Бесплатно)");
                Console.WriteLine("0 - Выйти");

                string choise = Console.ReadLine();
                switch (choise)
                {
                    case "0":
                        Console.WriteLine("Спасибо за визит! До свидания.");
                        return;  // Завершаем программу
                    case "1":
                        SeeAllCars();
                        break;
                    case "2":
                        BuyTheCar();
                        break;
                    case "3":
                        RentCars();
                        break;
                    case "4":
                        AskaboutWashing();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }

        }

        public static void SeeAllCars()
        {
            Console.Clear();
            Console.WriteLine("Все доступные машины:");
            if (Cars.Allcar.Count == 0)
            {
                Console.WriteLine("В данный момент нет доступных машин.");
            }
            else
            {
                for (int i = 0; i < Cars.Allcar.Count; i++)
                {
                    var car = Cars.Allcar[i];
                    Console.WriteLine($"{i} - {car.NameofCar} | Цена: {car.Price} Dkk | Описание: {car.Description}");
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню...");
            Console.ReadKey();
        }

        public static void BuyTheCar()
        {
            SeeAllCars();
            Console.WriteLine("Введите номер машины, которую хотите купить: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < Cars.Allcar.Count)
            {
                var selectedcar = Cars.Allcar[index];
                Console.WriteLine("Подписываем документы...");
                Thread.Sleep(2000);
                Console.WriteLine($"Вы купили: {selectedcar.NameofCar} за {selectedcar.Price} Dkk");
                Cars.Allcar.RemoveAt(index);  
            }
            else
            {
                Console.WriteLine("Неверный номер машины. Попробуйте снова.");
                
            }
            
        }

       
            public static void RentCars()
        {
            SeeAllCars();  

            while (true)
            {
                Console.Write("Введите номер машины, которую хотите взять в аренду: ");
                if (int.TryParse(Console.ReadLine(), out var index) && index >= 0 && index < Cars.Allcar.Count)
                {
                    Console.Write("Введите количество дней аренды: ");
                    if (int.TryParse(Console.ReadLine(), out var days) && days > 0)
                    {
                        var selectedcar = Cars.Allcar[index];
                        var rentalprice = (int)(selectedcar.Price * 0.05) * days;
                        Console.WriteLine($"Вы арендовали {selectedcar.NameofCar} за {rentalprice} Dkk на {days} дней.");
                        break;  
                    }
                    else
                    {
                        Console.WriteLine("Неверное количество дней. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор машины. Попробуйте снова.");
                }
            }

            
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню...");
            Console.ReadKey();
        }

            
        

        public static void AskaboutWashing()
        {
            Console.Clear();
            Console.WriteLine("Вы хотите помыть машину?");
            Thread.Sleep(2000);

            Console.WriteLine("Конечно! Мою вашу машину...");
            Thread.Sleep(1500);
            Console.WriteLine("Пена...");
            Thread.Sleep(1000);
            Console.WriteLine("Полировка...");
            Thread.Sleep(1000);
            Console.WriteLine("Готово!");

            Console.WriteLine("Ваша машина помыта. Хорошего дня!");
        }
    }
}
