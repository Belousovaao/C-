using Task_7;

internal class Program
{
    private static void Main(string[] args)
    {
        string? command = "";
        string? command2 = "";
        
        while (command != "0")
        {
            Console.Write("Какую пиццу желаете? На ваш выбор:\n");
            Console.WriteLine("4 сыра - нажмите 1");
            Console.WriteLine("гавайская - нажмите 2");
            Console.WriteLine("пепперони - нажмите 3");
            Console.WriteLine("Или вы можете собрать авторскую пиццу - нажмите 4");
            Console.WriteLine("Я просто посмотреть - нажмите 0");
            command = Console.ReadLine();

            if (command != "0")
            {
                Console.WriteLine("Отлично! Теперь давайте определимся с тестом для пиццы: \n");
                Console.WriteLine("тонкое - нажмите 1");
                Console.WriteLine("толстое - нажмите 2");
                command2 = Console.ReadLine();
                
                DoughBuilder? doughBuilder = null;
                if (command2 == "1")
                {
                    doughBuilder = new ThinDoughBuilder();
                }
                else if (command2 == "2")
                {
                    doughBuilder = new ThickDoughBuilder();
                }

                switch (command)
                {
                    case "1":
                        var fourCheesePizza = new FourCheesePizza(doughBuilder);
                        DisplayPizzaInfo(fourCheesePizza);
                        break;

                    case "2":
                        var hawaiianPizza = new HawaiiPizza(doughBuilder);
                        DisplayPizzaInfo(hawaiianPizza);
                        break;

                    case "3":
                        var pepperoniPizza = new PepperoniPizza(doughBuilder);
                        DisplayPizzaInfo(pepperoniPizza);
                        break;

                    case "4":
                        CustomPizza customPizza = new CustomPizza(doughBuilder);
                        Pizza basePizza = new BasicPizzza(doughBuilder);
                        Console.WriteLine("Выберите ингредиенты для вашей пиццы:");
                        Console.WriteLine("Сыр - нажмите 1");
                        Console.WriteLine("Курица - нажмите 2");
                        Console.WriteLine("Ананас - нажмите 3");
                        Console.WriteLine("Салями - нажмите 4");
                        var ingridients = Console.ReadLine();
                        foreach (var item in ingridients)
                        {
                            switch (item)
                            {
                                case '1':
                                    basePizza = new Cheese(basePizza);
                                    break;
                                case '2':
                                    basePizza = new Chicken(basePizza);
                                    break;
                                case '3':
                                    basePizza = new Pineapple(basePizza);
                                    break;
                                case '4':
                                    basePizza = new Salami(basePizza);
                                    break;
                            }
                        }
                        var finalPizza = customPizza.BuildPizza(basePizza);
                        DisplayPizzaInfo(finalPizza);
                        break;
                }
            }
        }
    }

    static void DisplayPizzaInfo(Pizza pizza)
    {
        Console.WriteLine($"Название: {pizza.Name}");
        Console.WriteLine($"Состав: {pizza.GetComposition()}");
        Console.WriteLine($"Стоимость: {pizza.GetCost()} рублей");
        Console.WriteLine();
    }
}
