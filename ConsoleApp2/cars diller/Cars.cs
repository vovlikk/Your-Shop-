using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AboutSales;
using Buyer;

namespace Сarshowroom
{
    public class Cars
    {
        public string NameofCar {  get; set; }
        public int Price {  get; set; }

        public string Description { get; set; }

        public static List<Cars> Allcar = new List<Cars>();

        public Cars(string nameofcar, int price, string description )
        {
            NameofCar = nameofcar;
            Price = price;
            Description = description;

            Allcar.Add(this);
        }

        static Cars()
        {
            new Cars("BMW M5", 950000, "Скоростная и комфортная");
            new Cars("Audi A6", 850000, "Надёжный немецкий автомобиль");
            new Cars("Toyota Corolla", 500000, "Экономичная и практичная");
        }



        public static void Allfunction()
        {
            Console.WriteLine("Спасибо что посетили наш автосалон");
            Console.Write("Кто вы? 1 - Продавец / 2 - Покупатель / 0 - Выход");
            string choise = Console.ReadLine();

            switch (choise)
            {
                case "0":
                    break;
                case "1":
                    Salesman();
                    break;
                case "2":
                    Buyer();
                    break;
                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова");
                    Allfunction(); 
                    break;
            }
        }

        public static  void Salesman()
        {
            AboutSales.AboutSalesMan.AllFunction();
        }

        public static void Buyer()
        {
            BuyerCar.AllFunction();
        }

    }

    
    
}
