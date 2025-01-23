using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

public class Program
{
    public static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        Laba1 laba = new Laba1(userInput);

        laba.TestFraction();
        Console.WriteLine(laba.TestCharToNum());
        Console.WriteLine(laba.TestIs2Digits());
        Console.WriteLine(laba.TestIsInRange());
        Console.WriteLine(laba.TestIsEqual());
        Console.WriteLine(laba.TestAbs());
        Console.WriteLine(laba.TestIs35());
        Console.WriteLine(laba.TestMax3());
        Console.WriteLine(laba.TestSum2());
        Console.WriteLine(laba.TestDay());
        Console.WriteLine(laba.TestListNums());
        Console.WriteLine(laba.TestEvenNumbers());
        Console.WriteLine(laba.TestNumberLength());
        laba.TestSquare();
        laba.TestRightTriangle();

        laba.TestFindFirst();
        laba.TestMaxAbs();
        laba.TestAdd();
        laba.TestReverseBack();
        laba.TestFindAll();
    }
}

public class UserInput
{
    // Метод для ввода целых чисел с проверкой на корректность
    public int GetIntInput(bool isPositive = false, string prompt = "Введите целое число: ")
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            // Проверка на целое число
            if (int.TryParse(input, out result))
            {
                // Проверка на положительное число, если это требуется
                if (isPositive && result < 0)
                {
                    Console.WriteLine("Число должно быть положительным!");
                    continue;
                }
                return result;
            }
            Console.WriteLine("Введенное значение не является целым числом! Попробуйте еще раз.");
        }
    }

    // Метод для ввода вещественных чисел с проверкой на корректность
    public float GetFloatInput(bool isPositive = false, string prompt = "Введите действительное число: ")
    {
        float result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input.Contains('.')){
                input = input.Replace('.', ',');
            }
            // Проверка на вещественное число
            if (float.TryParse(input, out result))
            {
                // Проверка на положительное число, если это требуется
                if (isPositive && result < 0)
                {
                    Console.WriteLine("Число должно быть положительным!");
                    continue;
                }
                return result;
            }
            Console.WriteLine("Введенное значение не является действительным числом! Попробуйте еще раз.");
        }
    }

    // Метод для ввода одного символа с проверкой на корректность
    public char GetCharInput(string prompt = "Введите символ: ")
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            // Проверка на ввод одного символа
            if (input.Length == 1)
            {
                return input[0];
            }
            Console.WriteLine("Пожалуйста, введите только один символ.");
        }
    }
}

public class Laba1
{
    private UserInput userInput;

    public Laba1(UserInput userInput)
    {
        this.userInput = userInput;
    }

    public double Fraction(double x)
    {
        // Преобразуем число x к целому, отбрасывая дробную часть
        int wholePart = (int)x;

        // Возвращаем разность между исходным числом и его целой частью 
        return x - wholePart;
    }

    public void TestFraction()
    {
        Console.WriteLine("Введите число с плавающей точкой и я выделю его дробную часть:");
        double number = userInput.GetFloatInput(false); // Используем метод ввода
        Console.WriteLine($"Дробная часть числа равна {Fraction(number)}");
    }

    public int CharToNum(char x) // перевод символа числа в цифру типа int
    {
        return x - '0';
    }

    public string TestCharToNum()
    {
        Console.WriteLine("Введите цифру от 0 до 9, и я превращу ее из типа char в тип int:");
        char inputChar = userInput.GetCharInput(); // Используем метод ввода
        int number = CharToNum(inputChar);
        return $"Результат: {number}";
    }

    public bool Is2Digits(int x)
    {
        return NumLen(Convert.ToInt64(x)) == 2;
    }

    public string TestIs2Digits()
    {
        Console.WriteLine("Введите число и я скажу, двузначное ли оно:");
        int number = userInput.GetIntInput(false); // Используем метод ввода
        return Is2Digits(number) ? "Двузначное" : "Не двузначное";
    }

    public bool IsInRange(int a, int b, int num)
    {
        return (a < b) ? (a < num && b > num) : (a > num && b < num);
    }

    public string TestIsInRange()
    {
        Console.WriteLine("Этот метод проверяет, входит ли число n в диапазон (a,b).");
        Console.WriteLine("Введите n:");
        int number = userInput.GetIntInput(false); // Используем метод ввода
        Console.WriteLine("Введите a:");
        int a = userInput.GetIntInput(false); // Используем метод ввода
        Console.WriteLine("Введите b:");
        int b = userInput.GetIntInput(false); // Используем метод ввода
        return IsInRange(a, b, number) ? $"{number} принадлежит данному диапазону" : $"{number} не принадлежит данному диапазону";
    }

    public bool IsEqual(int a, int b, int c)
    {
        return a == b && b == c;
    }

    public string TestIsEqual()
    {
        Console.WriteLine("Этот метод проверяет равенство чисел a, b и n.");
        Console.WriteLine("Введите n:");
        int number = userInput.GetIntInput(false); // Используем метод ввода
        Console.WriteLine("Введите a:");
        int a = userInput.GetIntInput(false); // Используем метод ввода
        Console.WriteLine("Введите b:");
        int b = userInput.GetIntInput(false); // Используем метод ввода
        return IsEqual(a, b, number) ? "Все три числа равны" : "Как минимум одно число отличается от остальных";
    }

    public int Abs(int x)
    {
        return x >= 0 ? x : -x;
    }

    public string TestAbs()
    {
        Console.WriteLine("Этот метод возводит число в модуль.");
        Console.WriteLine("Введите число:");
        int number = userInput.GetIntInput(false); 
        return Abs(number).ToString();
    }

    public bool Is35(int x)
    {
        return (x % 5 == 0) ^ (x % 3 == 0); // Используем XOR для проверки
    }

    public string TestIs35()
    {
        Console.WriteLine("Этот метод проверяет, делится ли x нацело на 3 или 5, но не на оба сразу.");
        Console.WriteLine("Введите число:");
        int number = userInput.GetIntInput(false); 
        return Is35(number).ToString();
    }

    public static int Max3(int x, int y, int z)
    {
        return Math.Max(x, Math.Max(y, z));
    }

    public string TestMax3()
    {
        Console.WriteLine("Этот метод находит тройной максимум чисел a, b и c.");
        Console.WriteLine("Введите a:");
        int a = userInput.GetIntInput(false); 
        Console.WriteLine("Введите b:");
        int b = userInput.GetIntInput(false); 
        Console.WriteLine("Введите c:");
        int c = userInput.GetIntInput(false); 
        return $"Максимум равен: {Max3(a, b, c)}";
    }

    public static int Sum2(int x, int y)
    {
        int sum = x + y;
        return (sum >= 10 && sum <= 19) ? 20 : sum;
    }

    public string TestSum2()
    {
        Console.WriteLine("Этот метод считает сумму двух чисел, но если сумма лежит в диапазоне от 10 до 19, то метод возвращает 20.");
        Console.WriteLine("Введите a:");
        int a = userInput.GetIntInput(false); 
        Console.WriteLine("Введите b:");
        int b = userInput.GetIntInput(false); 
        return $"Результат работы метода: {Sum2(a, b)}";
    }

    public string Day(int week)
    {
        return week switch
        {
            1 => "Понедельник",
            2 => "Вторник",
            3 => "Среда",
            4 => "Четверг",
            5 => "Пятница",
            6 => "Суббота",
            7 => "Воскресенье",
            _ => "ошибка, такого дня недели нет "
        };
    }

    public string TestDay()
    {
        Console.WriteLine("Этот метод показывает название дня недели по заданному номеру дня недели.");
        Console.WriteLine("Введите номер дня:");
        int num = userInput.GetIntInput(false); 
        return Day(num);
    }

    public string ListNums(int x)
    {
        return string.Join(" ", Enumerable.Range(0, x));
    }

    public string TestListNums()
    {
        Console.WriteLine("Этот метод выводит все натуральные числа от 0 до x.");
        Console.WriteLine("Введите x:");
        int num = userInput.GetIntInput(false); 
        return ListNums(num);
    }

    public string EvenNumbers(int x)
    {
        return string.Join(" ", Enumerable.Range(0, x + 1).Where(i => i % 2 == 0));
    }

    public string TestEvenNumbers()
    {
        Console.WriteLine("Этот метод выводит все четные натуральные числа от 0 до x.");
        Console.WriteLine("Введите x:");
        int num = userInput.GetIntInput(false);
        return EvenNumbers(num);
    }

    public int NumLen(long x)
    {
        return x.ToString().Length;
    }

    public string TestNumberLength()
    {
        Console.WriteLine("Этот метод выводит длину числа.");
        Console.WriteLine("Введите x:");
        long num = userInput.GetIntInput(false); 
        return NumLen(num).ToString();
    }

    public static void Square(int x)
    {
        for (int i = 0; i < x; i++)
        {
            Console.WriteLine(new string('*', x));
        }
    }

    public void TestSquare()
    {
        Console.WriteLine("Этот метод выводит квадрат со стороной x.");
        Console.WriteLine("Введите x:");
        int x = userInput.GetIntInput(true); 
        Square(x);
    }

    public static void RightTriangle(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            Console.WriteLine(new string(' ', x - i) + new string('*', i));
        }
    }

    public void TestRightTriangle()
    {
        Console.WriteLine("Этот метод выводит правый треугольник с правой стороной размером в x.");
        Console.WriteLine("Введите x:");
        int x = userInput.GetIntInput(true); 
        RightTriangle(x);
    }

    public static int FindFirst(int[] arr, int x)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                return i;
            }
        }
        return -1; // Если x не найден
    }

    public static int MaxAbs(int[] arr)
    {
        int max = 0;
        foreach (int num in arr)
        {
            if (Math.Abs(num) > max)
            {
                max = Math.Abs(num);
            }
        }
        return max;
    }

    public static int[] Add(int[] arr, int[] ins, int pos)
    {
        int[] result = new int[arr.Length + ins.Length];
        Array.Copy(arr, 0, result, 0, pos);
        Array.Copy(ins, 0, result, pos, ins.Length);
        Array.Copy(arr, pos, result, pos + ins.Length, arr.Length - pos);
        return result;
    }

    public static int[] ReverseBack(int[] arr)
    {
        int[] result = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            result[i] = arr[arr.Length - 1 - i];
        }
        return result;
    }

    public static int[] FindAll(int[] arr, int x)
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == x)
            {
                indices.Add(i);
            }
        }
        return indices.ToArray();
    }

    public void TestFindFirst()
    {
        Console.WriteLine("Введите размер массива:");
        int size = userInput.GetIntInput(true);
        int[] arr = new int[size];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = userInput.GetIntInput(false); 
        }

        Console.WriteLine("Введите число для поиска в массиве:");
        int x = userInput.GetIntInput(false); 
        int index = FindFirst(arr, x);
        Console.WriteLine(index != -1 ? $"Индекс первого вхождения {x}: {index}" : $"{x} не найден в массиве.");
    }

    public void TestMaxAbs()
    {
        Console.WriteLine("Введите размер массива:");
        int size = userInput.GetIntInput(true); 
        int[] arr = new int[size];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = userInput.GetIntInput(false); 
        }

        int maxAbsValue = MaxAbs(arr);
        Console.WriteLine($"Максимальное абсолютное значение в массиве: {maxAbsValue}");
    }

    public void TestAdd()
    {
        Console.WriteLine("Введите размер исходного массива:");
        int size = userInput.GetIntInput(true); 
        int[] arr = new int[size];

        Console.WriteLine("Введите элементы исходного массива:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = userInput.GetIntInput(false); 
        }

        Console.WriteLine("Введите размер массива для вставки:");
        int insertSize = userInput.GetIntInput(true); 
        int[] ins = new int[insertSize];

        Console.WriteLine("Введите элементы массива для вставки:");
        for (int i = 0; i < insertSize; i++)
        {
            ins[i] = userInput.GetIntInput(false); 
        }

        Console.WriteLine("Введите позицию для вставки:");
        int pos = userInput.GetIntInput(true); 
        int[] resultArray = Add(arr, ins, pos);
        Console.WriteLine("Массив после вставки: " + string.Join(", ", resultArray));
    }

    public void TestReverseBack()
    {
        Console.WriteLine("Введите размер массива:");
        int size = userInput.GetIntInput(true); 
        int[] arr = new int[size];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = userInput.GetIntInput(false); 
        }

        int[] reversedArray = ReverseBack(arr);
        Console.WriteLine("Перевернутый массив: " + string.Join(", ", reversedArray));
    }

    public void TestFindAll()
    {
        Console.WriteLine("Введите размер массива:");
        int size = userInput.GetIntInput(true); 
        int[] arr = new int[size];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = userInput.GetIntInput(false); 
        }

        Console.WriteLine("Введите число для поиска всех вхождений в массиве:");
        int x = userInput.GetIntInput(false); 
        int[] indices = FindAll(arr, x);

        if (indices.Length > 0)
        {
            Console.WriteLine($"Индексы всех вхождений {x}: " + string.Join(", ", indices));
        }
        else
        {
            Console.WriteLine($"{x} не найден в массиве.");
        }
    }

}
