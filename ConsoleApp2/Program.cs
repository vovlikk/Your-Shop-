class Program
{
    static List<string> addtovar = new List<string>();
    static List<string> korzina = new List<string>();
    static Dictionary<string, int> login = new Dictionary<string, int>
    {
        { "vova", 23102005 },
        { "employee1", 112233 },
        { "user123", 223344 }
    };
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в магазин!");
        Console.Write("Выберите кто вы: 1 - Сотрудник / 2 - Покупатель");
        int choise = Convert.ToInt32(Console.ReadLine());
       

        switch (choise)
        {
            case 1:
                Medarbdejder();
                break;
            case 2:
                Buyer();
                break;
        }
    }

    static void Medarbdejder()
    {
        Login();
        Console.WriteLine($"Добро пожаловать в личный кабинет!");

        while (true)
        {

            Console.WriteLine("Что вы хотите сделать?");
            Console.Write(" 1 - Логин: 2 - Добавить товары  / 3 - Просмотреть все актульные товары / 4 - Зарплату / 0 - Выход");
            int choisemed = Convert.ToInt32(Console.ReadLine());

            switch (choisemed)
            {
                case 0:
                    Console.WriteLine("Пока");
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

    static void Login()
    {
        
        Console.WriteLine("Добро пожаловать в system!");
        Console.WriteLine("Введите ваше имя: ");
        string namemed = Console.ReadLine();

        Console.WriteLine("Введите ваш пароль: ");
        int password = Convert.ToInt32(Console.ReadLine());

        if (login.TryGetValue(namemed, out int Storepassword))
        {
            if (Storepassword == password)
            {
                Console.WriteLine("Доступ разрешен!");
            }
            else
            {
                Console.WriteLine("Неверный пароль: ");
            }
        }
        else
        {
            Console.WriteLine("Логин не найден (");
        }
    }
    static void Addtovar()
    {
        string nameoftovar;
        string prise;

       
        Console.WriteLine("Вы выбрали добавить товар: ");
        Console.WriteLine("Название продукта: ");
        nameoftovar = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nameoftovar))
        {
            Console.WriteLine("Название товара не может быть пустым. Пожалуйста, введите название");
            nameoftovar = Console.ReadLine();
        }

        
        Console.WriteLine("Стоимость товара: ");
        prise = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(prise) || !double.TryParse(prise, out _))
        {
            Console.WriteLine("Введите корректную стоимость товара (число).");
            prise = Console.ReadLine();
        }

        
        addtovar.Add($"Название: {nameoftovar} Цена: {prise}");
        Console.WriteLine("Товар успешно добавлен!");
    }


    static void CheckallTovar()
    {
        if (addtovar.Count == 0)
        {
            Console.WriteLine("Нет добавленых товаров");
        }
        else
        {
            Console.WriteLine("Все товары: ");
            foreach (string bim in addtovar)
            {
                Console.WriteLine($"{bim}");
            }
        }
    }

    static void Salary()
    {
        Console.WriteLine("Ваша Зарплата: ");
        Console.Write("Сколько часов вы отработали?: ");
        int hourse = Convert.ToInt32(Console.ReadLine());
        double sum;
        double stavka = 1.5;

        int normalt = 100;

        if (hourse < 0 || hourse > 200)
        {
            throw new Exception("Введите корректное время отработанного вами: > 0  < 200");
        }

        if (hourse > 100)
        {
            sum = (100 * normalt) + ((hourse - 100) * (normalt * 1.5));
            Console.WriteLine($"Ваша зарплата: {sum}");
        }
        
        else
        {
            sum = normalt * hourse;
            Console.WriteLine($"Ваша Зарплата: {sum}");
        }
    }

    static void Buyer()
    {
        Console.WriteLine("Здравствуйте покупатель!");
        Console.Write("Выберите что вы хотите: 1 - Купить товар: 2 - Корзина:  0 - Выход");
        int choisebuyer = Convert.ToInt32(Console.ReadLine());

        switch (choisebuyer)
        {
            case 1:
                BuyTovar();
                break;
            case 2:
                ItemsinKorzin();
                break;
        }
    }
    static void BuyTovar()
    {
        Console.WriteLine("Все товары которые у нас есть: ");
        
        if (addtovar.Count == 0)
        {
            Console.WriteLine("Магазин Пуст(");
        }
        
        for (int i = 0; i < addtovar.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {addtovar[i]}");
        }

        Console.WriteLine("Введите номер товара который хотите купить: ");
        int choisebuyer;

        if (!int.TryParse(Console.ReadLine(), out choisebuyer) && choisebuyer > 0 || choisebuyer < addtovar.Count)
        {
            string selecttovar = addtovar[choisebuyer - 1];
            korzina.Add(selecttovar);
            Console.WriteLine($"Товар: {choisebuyer} Успешно добавлен в вашу корзину");
        }
    }

    static void ItemsinKorzin()
    {
        Console.WriteLine("Все что в вашей корзине: ");
        foreach (var item in korzina)
        {
            Console.WriteLine(item);
        }

        Console.Write("Готовы ли переходить к оплате? Да/Нет");
        Console.Write("Да/Нет");
        string betale = Console.ReadLine();

        if (betale.ToLower() == "да")
        {
            Console.WriteLine("Вы перешли к оплате");
        }
        else
        {
            Console.WriteLine("Вы не перешли к оплате");
        }
    }
}