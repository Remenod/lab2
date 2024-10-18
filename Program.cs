using System;
using static System.ConsoleColor;
namespace Lab2
{
    class Custom
    {  
        public static Type ReadLine<Type>(Converter<string, Type> convert, bool antiMoron, ConsoleColor color = White, bool check = false) => ReadLine(convert, antiMoron, "", White, color, check);
        public static Type ReadLine<Type>(Converter<string, Type> convert, bool antiMoron, string antiMoronMsg, ConsoleColor antiMoronMsgColor, ConsoleColor color = White, bool check = false)
        {          
            string input;
            void Do()
            {
                if (check) Console.Write(">");
                Console.ForegroundColor = color;
                input = Console.ReadLine();
                Console.ResetColor();
            }
            if (antiMoron)
            {
                do
                {
                    Do();
                    try { return convert(input);}
                    catch { Custom.WriteColored(antiMoronMsg + (antiMoronMsg == "" ? ("") : ("\n")), antiMoronMsgColor); }
                } while (true);
            }
            else 
            { 
                Do();
                try { return convert(input);}
                catch { throw new ArgumentException("wrong input type");}
            }
        }
        public static string ReadLine(ConsoleColor color, bool check = false)
        {
            if (check) Console.Write(">");
            Console.ForegroundColor = color;
            string output = Console.ReadLine();
            Console.ResetColor();
            return output;
        }
        public static void WriteColored(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void WriteColored(params object[] input)
        {
            for (int i = 0; i < input.Length; i += 2)
            {
                Console.ForegroundColor = (ConsoleColor)input[i + 1];
                Console.Write(Convert.ToString(input[i]));
            }
            Console.ResetColor();
        }
    }
    class Program
    {
        static string taskNum, cycleType;
        static void HelpChooseCycle() => Custom.WriteColored(
            "help", Yellow, " - відобразити список налаштованого введення.\n", White,
            "clear", Yellow, " - очистити консоль.\n", White,
            "0", Yellow, " - повернутися до попереднього меню.\n", White,
            "1", Yellow, " - виконати завдання за допомогою циклу ", White, "while\n", Yellow,
            "2", Yellow, " - виконати завдання за допомогою циклу ", White, "do while\n", Yellow,
            "3", Yellow, " - виконати завдання за допомогою циклу ", White, "for\n", Yellow);
        static void HelpChooseTask() => Custom.WriteColored(
            "help", Yellow, " - відобразити список налаштованого введення.\n", White,
            "clear", Yellow, " - очистити консоль.\n", White,
            "0", Yellow, " - завершити роботу програми.\n", White,
            "1", Yellow, " - Варіант 16. Знайти кількість елементів послідовності що кратні числу K1 і не кратні числу K2.\n", White,
            "2", Yellow, " - Варіант 27. Знайти суму мінімального і максимального елементів послідовності.\n", White,
            "3", Yellow, " - Варіант 46. Знайти номер першого від’ємного числа або з’ясувати, що таких нема.\n", White,
            "4", Yellow, " - Варіант 60. Знайти значення виразу √3 + √(6 + √(9 + ... + √(3n))\n", White,
            "5", Yellow, " - Варіант 61. Знайти значення виразу sin(x + sin(2x − sin(3x + sin(4x + sin(5x − sin(6x + ...\n", White,
            "6", Yellow, " - Варіант 62. Знайти значення виразу sin(x + cos(2x + sin(3x + cos(4x + sin(5x + cos(6x + ...\n", White,
            "7", Yellow, " - Варіант 63. Знайти значення виразу sin(x + cos(2x − sin(3x + cos(4x + sin(5x − cos(6x + ...\n", White);
        static void ChooseCycle()
        {
            while (true)
            {              
                Custom.WriteColored("Введіть тип циклу для виконання задачі", White, $" {taskNum}", Yellow, "(або help для показу допустимого вводу в меню вибору типу циклу)", DarkGray, ":\n", White);
                cycleType = Custom.ReadLine(Yellow, true);
                switch (cycleType)
                {
                    case "1" or "2" or "3":
                        Custom.WriteColored("Виконую завдання ", White, taskNum, Yellow, ", тип циклу ", White, $"{cycleType switch { "1" => "while", "2" => "do while", "3" => "for"}}\n", Yellow);
                        return;
                    case "help":
                        HelpChooseCycle();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "0":
                        return;
                    default:
                        Custom.WriteColored("Введене неналаштоване значення.\n", Red);
                        break;
                }
            }
        }
        static void ChooseTask()
        {
            Custom.WriteColored("Введіть номер задачі", White, "(або help для показу допустимого вводу в меню вибору задачі)", DarkGray, ":\n", White);
            taskNum = Custom.ReadLine(Yellow, true);
            switch (taskNum)
            {
                case "help": HelpChooseTask();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "0":
                    Custom.WriteColored("Робота програми завершена.\n", Yellow, "Натисніть Enter для закриття консолі.\n", White);
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
                case "1":
                    ChooseCycle();
                    Tasks.Task1(cycleType);
                    break;
                case "2":
                    ChooseCycle();
                    Tasks.Task2(cycleType);
                    break;
                case "3":
                    ChooseCycle();
                    Tasks.Task3(cycleType);
                    break;
                case "4":
                    ChooseCycle();
                    Tasks.Task4(cycleType);
                    break;
                case "5":
                    ChooseCycle();
                    Tasks.Task5(cycleType);
                    break;
                case "6":
                    ChooseCycle();
                    Tasks.Task6(cycleType);
                    break;
                case "7":
                    ChooseCycle();
                    Tasks.Task7(cycleType);
                    break;
                default:
                    Custom.WriteColored("Введене неналаштоване значення.\n", Red);
                    break;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            HelpChooseTask();        
            while (true) { ChooseTask(); }
        }
    }
    class Tasks
    {
        public static void Task1(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть число K1:\n", White);
            double K1 = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            Custom.WriteColored("Введіть число K2:\n", White);
            double K2 = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            Custom.WriteColored("Введіть кількість чисел:\n", White);
            uint numCount = Custom.ReadLine(uint.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            if (numCount > 0)
            {
                Custom.WriteColored("Введіть послідовність чисел:\n", White);
                uint divi1Count = 0;
                uint nonDivK2Count = 0;
                void Task1Helper()
                {
                    double num = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
                    divi1Count += (num % K1 == 0) ? (1u) : (0u);
                    nonDivK2Count += (num % K2 == 0) ? (0u) : (1u);
                }
                switch (cycType)
                {
                    case "1":
                        uint i = 0;
                        while (i++ < numCount) Task1Helper();
                        break;
                    case "2":
                        uint a = 0;
                        do Task1Helper(); while (++a < numCount);
                        break;
                    case "3":
                        for (uint c = 0; c < numCount; c++) Task1Helper();
                        break;
                }
                Custom.WriteColored("Успіх\n", Green);
                Custom.WriteColored("Кількість чисел що діляться на K1:", White, $"{divi1Count}\n", Yellow);
                Custom.WriteColored("Кількість чисел що не діляться на K2:", White, $"{nonDivK2Count}\n", Yellow);
            }
            else
            {
                Custom.WriteColored("Помилка!\n", Red, "Кількість чисел має бути більшою за нуль.\n", White);
            }
        }
        public static void Task2(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть послідовність чисел:\n", White);
            double num = 1;
            double maxNum = double.MinValue;
            double minNum = double.MaxValue;
            void Task2Helper()
            {
                num = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
                if (num != 0)
                {
                    maxNum = (num > maxNum) ? (num) : (maxNum);
                    minNum = (num < minNum) ? (num) : (minNum);
                }
            }
            switch (cycType)
            {
                case "1":
                    while (num != 0) Task2Helper();
                    break;
                case "2":
                    do Task2Helper(); while (num != 0);
                    break;
                case "3":
                    for (; num != 0;) Task2Helper();
                    break;
            }
            if (maxNum == double.MinValue && minNum == double.MaxValue)
                Custom.WriteColored("Помилка!\n", Red, "Програма отримала замало чисел до введення нуля.\n", White);
            else
                Custom.WriteColored("Успіх!\n", Green, "Сума мінімального і максимального елементів: ", White, $"{maxNum + minNum}\n", Yellow);            
        }
        public static void Task3(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть кількість чисел:\n", White);
            uint numCount = Custom.ReadLine(uint.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            uint currNumIndex = 0;
            uint ngNumIndex = 0;
            void Task3Helper()
            {
                double num;
                do
                {
                    try
                    {
                        Console.Write($"{currNumIndex}: ");
                        num = Custom.ReadLine(double.Parse, false, Yellow);
                        break;
                    }
                    catch { Custom.WriteColored("Неправильно введене число.\n", Red); }
                } while (true);
                if (num < 0 && ngNumIndex == 0) ngNumIndex = currNumIndex;
            }
            if (numCount > 0)
            {
                Custom.WriteColored("Введіть послідовність чисел:\n", White);
                switch (cycType)
                {
                    case "1":
                        while (currNumIndex++ < numCount) Task3Helper();
                        break;
                    case "2":
                        do
                        {
                            currNumIndex++;
                            Task3Helper();
                        }
                        while (currNumIndex < numCount);
                        break;
                    case "3":
                        for (currNumIndex = 1; currNumIndex <= numCount; currNumIndex++) Task3Helper();
                        break;
                }
                if (ngNumIndex == 0) Custom.WriteColored("Успіх!\n", Green, "Серед ряду чисел немає жодного від'ємного числа.\n", White);
                else Custom.WriteColored("Успіх!\n", Green, "Номер першого від'ємного числа: ", White, $"{ngNumIndex}\n", Yellow);
            }
            else Custom.WriteColored("Помилка!\n", Red, "Програма отримала замало чисел до введення нуля.\n", White);
        }
        public static void Task4(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть число n:\n", White);
            int n = Custom.ReadLine(int.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            double sum;
            if(n>0)sum = Math.Sqrt(3 * n--);
            else
            {
                Custom.WriteColored("Помилка!\n", Red, "Довжина рівняння дорівнює нулю.\n", White);
                return;
            }
            switch (cycType)
            {
                case "1":
                    while (n > 0) sum = Math.Sqrt(3 * n-- + sum);
                    break;
                case "2":
                    do sum = Math.Sqrt(3 * n-- + sum); while (n > 0);
                    break;
                case "3":
                    for (; n>0; n--) sum = Math.Sqrt(3 * n + sum);
                    break;
            }
            Custom.WriteColored("Успіх!\n", Green, "Відповідь:",White,$"{sum}\n",Yellow);
        }
        public static void Task5(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть число x:\n", White);
            double x = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            Custom.WriteColored("Введіть число n:\n", White);
            int n = Custom.ReadLine(int.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            double sum;
            if(n>0)sum = Math.Sin(x*n);
            else
            {
                Custom.WriteColored("Помилка!\n", Red, "Довжина рівняння дорівнює нулю.\n", White);
                return;
            }
            switch (cycType)
            {
                case "1":
                    while (--n > 0) sum = (n % 3 == 2) ? Math.Sin(x * n - sum) : Math.Sin(x * n + sum);
                    break;
                case "2":
                    n--;
                    do sum = (n % 3 == 2) ? Math.Sin(x * n - sum) : Math.Sin(x * n + sum);
                    while (--n > 0);
                    break;
                case "3":
                    for (; --n > 0; ) sum = (n % 3 == 2) ? Math.Sin(x * n - sum) : Math.Sin(x * n + sum);
                    break;
            }            
            Custom.WriteColored("Успіх!\n", Green, "Відповідь:", White, $"{sum}\n", Yellow);
        }   
        public static void Task6(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть число x:\n", White);
            double x = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            Custom.WriteColored("Введіть число n:\n", White);
            int n = Custom.ReadLine(int.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            double sum;
            if(n>0) sum = n%2==1 ? Math.Sin(x * n): Math.Cos(x*n);
            else
            {
                Custom.WriteColored("Помилка!\n", Red, "Довжина рівняння дорівнює нулю.\n", White);
                return;
            }
            switch (cycType) 
            {
                case "1":
                    while (--n > 0) sum = n % 2 == 1 ? Math.Sin(x * n + sum) : Math.Cos(x * n + sum);
                    break;
                case "2":
                    n--;
                    do sum = n % 2 == 1 ? Math.Sin(x * n + sum) : Math.Cos(x * n + sum);
                    while (--n > 0);
                    break;
                case "3":
                    for (; --n > 0;) sum = n % 2 == 1 ? Math.Sin(x * n + sum) : Math.Cos(x * n + sum);
                    break;
            }
            Custom.WriteColored("Успіх!\n", Green, "Відповідь:", White, $"{sum}\n", Yellow);
        }
        public static void Task7(string cycType)
        {
            if (cycType == "0") return;
            Custom.WriteColored("Введіть число x:\n", White);
            double x = Custom.ReadLine(double.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            Custom.WriteColored("Введіть число n:\n", White);
            int n = Custom.ReadLine(int.Parse, true, "Неправильно введене число.", Red, Yellow, true);
            double sum;
            if (n>0) sum = n % 2 == 1 ? Math.Sin(x * n) : Math.Cos(x * n);
            else
            {
                Custom.WriteColored("Помилка!\n", Red, "Довжина рівняння дорівнює нулю.\n", White);
                return;
            }
            void Task7Helper() => sum = (n % 2, n % 3) switch{
                (0, 0) or (0, 1) => Math.Cos(x * n + sum),
                (1, 1) or (1, 0) => Math.Sin(x * n + sum),
                (0, 2) => Math.Cos(x * n - sum),
                (1, 2) => Math.Sin(x * n - sum)};
            switch (cycType) 
            {
                case "1":
                    while (--n > 0) Task7Helper();
                    break;
                case "2":
                    n--;
                    do Task7Helper(); while (--n > 0);
                    break;
                case "3":
                    for (; --n > 0;) Task7Helper();
                    break;
            }            
            Custom.WriteColored("Успіх!\n", Green, "Відповідь:", White, $"{sum}\n", Yellow);
        }
    }
}