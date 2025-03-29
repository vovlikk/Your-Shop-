using System;
using System.Collections.Generic;

namespace AdminNamespace
{
    public class AdminAction
    {
        private List<string> todolist = new List<string>();

        public void AdminMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Добро пожаловать в личный кабинет!");
                Console.Write("Выберите: 1 - Добавить задачу / 2 - Удалить / 3 - Активные / 4 - Выход: ");
                int adminchoise;

                while (!int.TryParse(Console.ReadLine(), out adminchoise) || adminchoise < 1 || adminchoise > 4)
                {
                    Console.WriteLine("Ошибка! Введите число от 1 до 4.");
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
                    case 4:
                        Console.WriteLine("Выход в главное меню...");
                        Thread.Sleep(1000);
                        return;
                }
            }
        }

        public void AddAction()
        {
            Console.Clear();
            Console.Write("\nВведите название задачи: ");
            string nameofaction = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nameofaction))
            {
                Console.WriteLine("Ошибка: задача не может быть пустой!");
                return;
            }

            todolist.Add(nameofaction);
            Console.WriteLine("Задача успешно добавлена!");
        }

        public void RemoveAction()
        {
            Console.Clear();
            Console.WriteLine("Удаление задачи");

            if (todolist.Count == 0)
            {
                Console.WriteLine(" Нет задач для удаления!");
                return;
            }

            ViewAllAction();
            Console.Write("Введите номер задачи для удаления: ");
            int choiseremoveaction;

            while (!int.TryParse(Console.ReadLine(), out choiseremoveaction) || choiseremoveaction <= 0 || choiseremoveaction > todolist.Count)
            {
                Console.WriteLine("Ошибка! Введите корректный номер задачи.");
            }

            todolist.RemoveAt(choiseremoveaction - 1);
            Console.WriteLine("Задача удалена!");
        }

        public void ViewAllAction()
        {
            Console.Clear();
            Console.WriteLine("Список задач:");

            if (todolist.Count == 0)
            {
                Console.WriteLine(" Активных задач нет!");
                return;
            }

            for (int i = 0; i < todolist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {todolist[i]}");
            }
        }
    }
}
