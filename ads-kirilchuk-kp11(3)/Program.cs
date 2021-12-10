using System;
using System.Linq;
class Program
{
    // перевірка, чи значення є тризначним
    static bool IsThreeDigitValueOfNumber(int value)
    {
        return value / 100 > 0 && value / 1000 == 0;
    }

    // перевірка, чи значення є двозначним
    static bool IsTwoDigitValueOfNumber(int value)
    {
        return value / 100 == 0 && value / 10 > 0;
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int length;
        Console.Write("Input the length for the array: = "); length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = random.Next(0, 200);
        }
        Console.WriteLine();

        for (int i = 0; i < length; i++)
        {
            if (IsThreeDigitValueOfNumber(array[i]))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else if (array[i] / 100 == 0 && array[i] / 10 > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(array[i].ToString() + " ");
            }
        }

        for (int i = 0; i < length; i++)
        {
            if (IsThreeDigitValueOfNumber(array[i]))
            {
                int maxIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (IsThreeDigitValueOfNumber(array[j]) && array[j] > array[maxIndex])
                    {
                        maxIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[maxIndex];
                array[maxIndex] = tmp;
            }
            else if (IsTwoDigitValueOfNumber(array[i]))
            {
                int minIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (IsTwoDigitValueOfNumber(array[j]) && array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }
        Console.WriteLine();
        for (int i = 0; i < length; i++)
        {
            if (IsThreeDigitValueOfNumber(array[i]))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else if (array[i] / 100 == 0 && array[i] / 10 > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(array[i].ToString() + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(array[i].ToString() + " ");
            }
        }
    }
}