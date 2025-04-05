using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace ListAboutUser
{
    public class BuyerUser
    {
        static List<BuyerUser> buyerUsers = new List<BuyerUser>();
        static BuyerUser currentUser = null;

        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> PurchaseHistory { get; set; } = new List<string>();

        public BuyerUser(string username, string password)
        {
            Username = username;
            Password = password;
            PurchaseHistory = new List<string>();
        }

        public static void SaveUsersToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(buyerUsers, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

      
        public static void LoadUsersFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                buyerUsers = JsonConvert.DeserializeObject<List<BuyerUser>>(json);
            }
        }

        public static void AllFunction()
        {
            Console.WriteLine("Выберите, что вы хотите...");
            Console.Write("1 - Логин / 2 - Регистрация / 0 - выйти: ");
            string choiseuser = Console.ReadLine();

            switch (choiseuser)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "0":
                    Console.WriteLine("Пока");
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    AllFunction();
                    break;
            }
        }

        private static void Login()
        {
            Console.Write("Введите имя: ");
            string username = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            var user = buyerUsers.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                currentUser = user;
                Console.WriteLine($"Поздравляю, вы успешно авторизовались как {currentUser.Username}.");
            }
            else
            {
                Console.WriteLine("Неверное имя пользователя или пароль.");
                return;
            }
        }

        private static void Register()
        {
            Console.Write("Введите ваше имя: ");
            string registename = Console.ReadLine();

            if (buyerUsers.Exists(user => user.Username == registename))
            {
                Console.WriteLine("Извините, но этот ник уже занят");
                Console.WriteLine("Попробуйте другой: ");
                return;
            }

            Console.Write("Введите ваш пароль: ");
            string registepassword = Console.ReadLine();

            BuyerUser newuser = new BuyerUser(registename, registepassword);

            buyerUsers.Add(newuser);
            Console.WriteLine("Пользователь успешно зарегистрирован!");
        }


        public void AddToPurchaseHistory(string product)
        {
            if (currentUser != null)
            {
                currentUser.PurchaseHistory.Add(product);
                Console.WriteLine("Товар добавлен в историю покупок.");
            }
            else
            {
                Console.WriteLine("Пожалуйста, войдите в систему для добавления товаров.");
            }
        }

        public void HistoryViews()
        {
            if (currentUser != null)
            {
                Console.WriteLine("Ваша история покупок");
                foreach (var item in currentUser.PurchaseHistory)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Пожалуйста, войдите в систему для просмотра истории покупок.");
            }
        }
    }
    
}