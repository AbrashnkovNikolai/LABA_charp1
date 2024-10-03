using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

public class Laba1
{

    public static void Main(string[] args)
    {
        test_fraction();
        Laba1 Laba = new Laba1();
        Console.WriteLine(Laba.test_CharToNum());
        Console.WriteLine(Laba.test_3());
        Console.WriteLine(Laba.test_4());
        Console.WriteLine(Laba.test_5());
        Console.WriteLine(Laba.test_2_1());
        Console.WriteLine(Laba.test_2_3());
        Console.WriteLine(Laba.test_2_5());
        Console.WriteLine(Laba.test_2_7());
        Console.WriteLine(Laba.test_2_9());
        Console.WriteLine(Laba.test_3_1());
        Console.WriteLine(Laba.test_3_3());
        Console.WriteLine(Laba.test_3_5());
        Laba.test_3_7();
        Laba.test_3_9();

    }
    public static double fraction(double x)
    {
        // Преобразуем число x к целому, отбрасывая дробную часть
        int wholePart = (int)x;

        // Возвращаем разность между исходным числом и его целой частью 
        return x - wholePart;
    }
    public static void test_fraction()
    {
        Console.WriteLine("Введите число с плавающей точкой и я выделю его дробную часть:");
        string default_str = Console.ReadLine();
        string string_with_points = default_str.Replace(".", ",");              //замена точек на запятые в строке от очень умных
        double number = double.Parse(string_with_points);
        Console.WriteLine($"дробная часть числа равна {fraction(number)}");
    }
    public int charToNum(char x) // перевод символа числа в цифру типа int
    {
        int num = x - '0';
        return num;
    }
    public string test_CharToNum()
    {
        Console.WriteLine("Введите цифру от 0 до 9 , и я превращу ее из типа char в тип int :");
        string default_str = Console.ReadLine();

        int number = charToNum(default_str[0]);
        return $" я не понимаю смысл писать для теста этого заданая метод но ладно {(number)}";
    }

    public bool Is2Digits(int x)
    { return numLen(Convert.ToInt64(x)) == 2; }

    public string test_3() // тест метода Is2Digits
    {
        Console.WriteLine("введите число и я скажу двузначно ли оно  ");
        int number = int.Parse(Console.ReadLine());
        if (Is2Digits(number))
        {
            return "двухзначное ";
        }

        else
        {
            return "не двухзначное";
        }

    }
    public bool isInRange(int a, int b, int num) // метод для проверки того входит ли число в диапозон от а до б или от б до а  или не входит никуда    {
        if (a < b)
        {
            return a < num && b > num;
        }
        else
        {
            return a> num && b < num;
        }
    }
    public string test_4() // проверка работы isInRange
    {
        Console.WriteLine("этот метод проверяет входит ли число n в диапозон (a,b)");
        Console.WriteLine("введите n:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("введите a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("введите b:");
        int b = int.Parse(Console.ReadLine());
        if (isInRange(a,b, number))
        {
            return $"{number} принадлежит данному диапозону";
        }

        else
        {
            return $"{number} не принадлежит данному диапозону";
        }
    }    public bool isEqual(int a, int b, int c) //метод для проверки равенства трех чисел    {
        if (a == c)
        {
            return a == b;
        }
        else 
        {
            return false;
        }
    }
    public string test_5() //тест для метода isEqual н а проверку одинаковости трех чисел
    {
        Console.WriteLine("этот метод проверяет равенство чисел a b n ");
        Console.WriteLine("введите n:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("введите a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("введите b:");
        int b = int.Parse(Console.ReadLine());
        if (isEqual(a, b, number))
        {
            return $"все три числа равны";
        }

        else
        {
            return $"как минимум одно число отличается от остальных";
        }
    }
    public int abs(int x) // модуль 
    {
        if (x > 0)
            {
            return x;
        }
        else 
        {
            return -x; 
        }

    }
    public string test_2_1() //тест метода фозведения в модуль
    {
        Console.WriteLine("этот метод возводит число в модуль ");
        Console.WriteLine("введите число:");
        int number = int.Parse(Console.ReadLine());
        return Convert.ToString(abs(number));
        
    }
    public bool is35(int x) // не или для (mod x 3) и (mod x5)
    {
        if (x % 5 != 0 && x % 3 != 0)
        {
            return false;
        }
        else if (x % 5 == 0 && x % 3 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
        }
    public string test_2_3()
    {
        Console.WriteLine("этот метод проверяет что  x делится нацело на 3 или 5, но не на оба сразу");
        Console.WriteLine("введите число:");
        int number = int.Parse(Console.ReadLine());
        return Convert.ToString(is35(number));

    }
    public static int max3(int x, int y, int z) //тройной максимум
    {
        int max = x; // Предполагаем, что x - максимальное, дальше два сравнения и готово

        if (y > max)
        { 
            max = y;
        }

        if (z > max)
        { 
            max = z;
        }

        return max;
    }
    public string test_2_5() //тест для метода max3 (максимум из трех)
    {
        Console.WriteLine("этот метод находит тройной максимум чисел a b с ");
        Console.WriteLine("введите a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("введите b:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("введите c:");
        int c = int.Parse(Console.ReadLine());
        return $"максимум равен : {max3(a, b, c)}";
    }
    public static int sum2(int x, int y)
    {
        int sum = x + y;
        if (sum >= 10 && sum <= 19)
        {
            return 20;
        }
        else
        {
            return sum;
        }
    }
    public string test_2_7() //тест для метода sum2
    {
        Console.WriteLine("этот метод считает сумму двух чисел но если сумма лежит в диапозоне от 10 до 19 то метод возвращает 20(это не я придумал так по тз сказано)");
        Console.WriteLine("введите a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("введите b:");
        int b = int.Parse(Console.ReadLine());
        return $"результат работы метода {sum2(a, b)}";
    }
    public String day(int week)
    {
        String day = "";

        switch (week)
        {
            case 1:
                day = "Понедельник";
                break;
            case 2:
                day = "Вторник";
                break;
            case 3:
                day = "Среда";
                break;
            case 4:
                day = "Четверг";
                break;
            case 5:
                day = "Пятница";
                break;
            case 6:
                day = "Суббота";
                break;
            case 7:
                day = "Воскресенье";
                break;
            default:
                day = "---";
                break;
        }
        return day;
    }
    public string test_2_9() //тест метода day(дни недели)
    {
        Console.WriteLine("этот метод показывает название дня недели по заданному номеру дня недели  ");
        Console.WriteLine("введите номер дня :");
        int num = int.Parse(Console.ReadLine());
        return day(num);

    }
    public String listNums(int x)
    {
        string res = "";
        for (int i = 0; i < x; i++) 
        {
            res += Convert.ToString(i);
            if (i != x - 1)  
            { 
                res += " ";
            }
        }
        return res;

    }
    public string test_3_1() //тест метода day(дни недели)
    {
        Console.WriteLine("этот метод выводит все натуральные числа от 0 до x");
        Console.WriteLine("введите x:");
        int num = int.Parse(Console.ReadLine());
        return listNums(num);

    }
    public String chet(int x)
    {
        string res = "";
        for (int i = 0; i <= x; i+=2)
        {
            res += Convert.ToString(i);
            if (i != x - 1)
            {
                res += " ";  
            }
        }
        return res;
    }
    public string test_3_3() //тест метода day(дни недели)
    {
        Console.WriteLine("этот метод выводит все четные натуральные числа от 0 до x");
        Console.WriteLine("введите x:");
        int num = int.Parse(Console.ReadLine());
        return chet(num);

    }
    public int numLen(long x)
    {
        int res = 0;
        while (x > 0)
        {
            x = x / 10L;
            res++;
        }
        return res;
    }
    public string test_3_5() //тест метода длинны числа 
    {
        Console.WriteLine("этот метод выводит длинну числа");
        Console.WriteLine("введите x:");
        long num = long.Parse(Console.ReadLine());
        return numLen(num).ToString();
    }
    public static void Square(int x)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine(); // Переход на новую строку после каждой строки квадрата
        }
    }
    public void test_3_7() //тест метода длинны числа 
    {
        Console.WriteLine("этот метод выводит квадрат со стороной x ");
        Console.WriteLine("введите x:");
        int x = int.Parse(Console.ReadLine());
        Square(x);
    }
    public static void RightTriangle(int x)
    {
        for (int i = 1; i <= x; i++)
        {
            // Вывод пробелов
            for (int j = 1; j <= x - i; j++)
            {
                Console.Write(" ");
            }
            // Вывод символов "*"
            for (int k = 1; k <= i; k++)
            {
                Console.Write("*");
            }
            Console.WriteLine(); // Переход на новую строку
        }
    }
    public void test_3_9() //тест метода написания правого треугольника
    {
        Console.WriteLine("этот метод выводит правый треугольник с правой стороной размером в x ");
        Console.WriteLine("введите x:");
        int x = int.Parse(Console.ReadLine());
        RightTriangle(x);
    }
}