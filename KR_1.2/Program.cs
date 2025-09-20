using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число обналичивания: ");
        int n = Convert.ToInt32(Console.ReadLine());
        while (n % 100 != 0 || n > 150000 || n <= 0)
        {
            Console.WriteLine($"Ошибка, Выдать {n} рублей невозможно.\n" +
                              $"Введите другую сумму (кратную 100 и не более 150.000)");
            n = Convert.ToInt32(Console.ReadLine());
        }
        

        if (n >= 5000)
        {
            Console.WriteLine($"{n / 5000} по 5000");
            n -= 5000 * (n / 5000);
        }
        if (n >= 2000)
        {
            Console.WriteLine($"{n / 2000} по 2000");
            n -= 2000 * (n / 2000);
        }
        if (n >= 1000)
        {
            Console.WriteLine($"{n / 1000} по 1000");
            n -= 1000 * (n / 1000);
        }
        if (n >= 500)
        {
            Console.WriteLine($"{n / 500} по 500");
            n -= 500 * (n / 500);
        }
        if (n >= 200)
        {
            Console.WriteLine($"{n / 200} по 200");
            n -= 200 * (n / 200);
        }
        if (n >= 100)
        {
            Console.WriteLine($"{n / 100} по 100");
        }
    }
}