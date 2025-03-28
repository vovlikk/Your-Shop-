using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminNamespace
{
    public class AdminAction
    {
        static List<string> todolist = new List<string>();

        public void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Добро пожаловать в личный кабинет!");
                Console.Write("Выберите: 1 - Добавить задачу / 2 - Удалить / 3 - Активные / 3 - Выход");
                int adminchoise;

                if (!int.TryParse(Console.ReadLine(), out adminchoise) || adminchoise < 0 || adminchoise > 4)
                {
                    Console.WriteLine("Неправильный выбор!");
                    return;
                }


                switch (adminchoise)
                {
                    case 1:
                        AddAction();
                        break;
                    case 2:
                        RemoveAction();
                        break;
                    case 3:
                        ViewAllAction();
                        break;
                }
            }
        }

        static void AddAction()
        {
            Console.WriteLine("Добавить задачу");
            Console.WriteLine("Название задачи: ");
            string nameofaction = Console.ReadLine();

           if (string.IsNullOrEmpty(nameofaction))
            {
                Console.WriteLine("Задача не может быть пустой");
            }
           else
            {
                todolist.Add(nameofaction);
                Console.WriteLine("Задача успешно добавлена!");
            }
        }

        static void RemoveAction()
        {
            Console.WriteLine("Удалание задач");

            Console.WriteLine("Введите номер задачи: ");
            int choiseremoveaction;

            while (int.TryParse(Console.ReadLine(), out choiseremoveaction) || choiseremoveaction < 0 || choiseremoveaction > todolist.Count)
            {
                Console.WriteLine("Введите корректный индекс");
            }

            todolist.RemoveAt(choiseremoveaction - 1);
            Console.WriteLine("Задача Удалена!");
        }

        static void ViewAllAction()
        {
            Console.WriteLine("Просмотр всех задач!");

            if (todolist.Count == 0)
            {
                Console.WriteLine("Активных задач нет!");
            }

            else
            {
                for (int i = 0; i < todolist.Count; i++)
                {
                    Console.WriteLine($"Index: {i + 1}. {todolist[i]}");
                }
            }
        }
    }
}
