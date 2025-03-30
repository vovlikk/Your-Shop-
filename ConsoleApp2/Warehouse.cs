using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreNamespace
{
    public class Warehouse
    {
        private static Dictionary<string, int> sklad = new Dictionary<string, int>()
        {
            {"Apple",20},
            {"Milk",5},
            {"Sukker",10},
            {"Juice",10},
            {"Meat",2},
            {"Water",15}
        };

        public static void AddTovar(string product, int quantility)
        {
            if (sklad.ContainsKey(product))
            {
                sklad[product] += quantility;
            }
            else
            {
                sklad[product] += quantility;
            }
        }

        public static bool RemoveProduct(string product, int quantility)
        {

            if (quantility <= 0)
            {
                Console.WriteLine("Количество должно быть больше 0.");
                return false;
            }

            if (sklad.ContainsKey(product) && sklad[product] >= quantility)
            {
                sklad[product] -= quantility;
                Console.WriteLine($"Списано! : {quantility} штук {product}/ На складе осталось: {sklad[product]} штук");
                return true;
            }

            else
            {
                Console.WriteLine($"Недостаточно продуктов! {product} на складе нет");
                return false;
            }

        }

        public static void ShowWarehouse()
        {
            foreach (var product in sklad)
            {
                Console.WriteLine($"Name: {product.Key}  Quaily: {product.Value}");
            }
        }

        public static void ShowWarehouseForBuyer()
        {
            Console.Clear();
            if (sklad.Count == 0)
            {
                Console.WriteLine("Склад пуст.");
            }
            else
            {
                Console.WriteLine("Товары на складе:");
                foreach (var product in sklad)
                {
                    Console.WriteLine($"Название: {product.Key}, Количество: {product.Value}");
                }
            }
        }

    }
}
