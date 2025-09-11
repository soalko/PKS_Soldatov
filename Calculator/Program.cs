using System;

namespace ClassicCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentValue = 0;
            double memoryValue = 0;
            double previousValue = 0;
            char operation = ' ';
            bool isNewCalculation = true;

            Console.WriteLine("Классический калькулятор");
            Console.WriteLine(
                "Доступные операции: +, -, *, /, %, ^ (квадрат), s (корень), r (1/x), m (M+), n (M-), p (MR), c (Очистка), e (Выход)");

            while (true)
            {
                if (isNewCalculation)
                {
                    Console.Write("Введите число: ");
                    string input = Console.ReadLine();
                    
                    if (input.ToLower() == "e")
                        break;
                    
                    if (!double.TryParse(input, out currentValue))
                    {
                        Console.WriteLine("Ошибка: введите число или команду");
                        continue;
                    }

                    isNewCalculation = false;
                }
                else
                {
                    Console.WriteLine($"Текущий результат: {currentValue}");
                }
                
                Console.Write("Введите операцию (+, -, *, /, %, ^, s, r, m, n, p, c, e): ");
                string opInput = Console.ReadLine();
                
                if (opInput.ToLower() == "e")
                    break;
                
                switch (opInput.ToLower())
                {
                    case "c":
                        currentValue = 0;
                        previousValue = 0;
                        operation = ' ';
                        isNewCalculation = true;
                        Console.WriteLine("Калькулятор очищен");
                        continue;

                    case "s":
                        if (currentValue < 0)
                        {
                            Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа");
                        }
                        else
                        {
                            currentValue = Math.Sqrt(currentValue);
                        }

                        break;

                    case "^":
                        currentValue = Math.Pow(currentValue, 2);
                        break;

                    case "r":
                        if (currentValue == 0)
                        {
                            Console.WriteLine("Ошибка: деление на ноль");
                        }
                        else
                        {
                            currentValue = 1.0 / currentValue;
                        }

                        break;

                    case "m":
                        memoryValue += currentValue;
                        Console.WriteLine($"Значение в памяти: {memoryValue}");
                        isNewCalculation = true;
                        continue;

                    case "n":
                        memoryValue -= currentValue;
                        Console.WriteLine($"Значение в памяти: {memoryValue}");
                        isNewCalculation = true;
                        continue;

                    case "p":
                        currentValue = memoryValue;
                        break;
                    
                    default:
                        if (opInput.Length == 1 && "+-*/%".Contains(opInput))
                        {
                            previousValue = currentValue;
                            operation = opInput[0];
                            isNewCalculation = true;

                            Console.Write("Введите следующее число: ");
                            string nextInput = Console.ReadLine();

                            if (nextInput.ToLower() == "e")
                                goto endLoop;

                            double nextNumber;
                            if (!double.TryParse(nextInput, out nextNumber))
                            {
                                Console.WriteLine("Ошибка: введите число");
                                isNewCalculation = false;
                                currentValue = previousValue;
                                continue;
                            }
                            
                            switch (operation)
                            {
                                case '+':
                                    currentValue = previousValue + nextNumber;
                                    break;
                                case '-':
                                    currentValue = previousValue - nextNumber;
                                    break;
                                case '*':
                                    currentValue = previousValue * nextNumber;
                                    break;
                                case '/':
                                    if (nextNumber == 0)
                                    {
                                        Console.WriteLine("Ошибка: деление на ноль");
                                        currentValue = previousValue;
                                    }
                                    else
                                    {
                                        currentValue = previousValue / nextNumber;
                                    }

                                    break;
                                case '%':
                                    currentValue = previousValue % nextNumber;
                                    break;
                            }
                            
                            isNewCalculation = false;
                        }
                        else
                        {
                            Console.WriteLine("Неизвестная операция. Попробуйте снова");
                        }

                        break;
                }
            }
            endLoop:
            Console.WriteLine("Выход");
        }
    }
}