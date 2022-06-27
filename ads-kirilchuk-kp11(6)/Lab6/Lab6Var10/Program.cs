using System;

namespace Lab6Var10
{
    class Program
    {
        private static string DefaultCode = "<html><body><code>Комп'ютерний код</code><br /><kbd>Ввід с клавіатури</kbd><br /><tt>Текст</tt><br /><samp>Текст примера</samp><br /><var>Комп'ютерна змінна</var><br /><p><b>Доповнення:</b> Ці теги часто використовуюся для відображення ком'ютерного кода.</p></body></html>";
        
        static void Main(string[] args)
        {
            HTMLParser parser = new HTMLParser();
            int Choice = 0;
            do
            {
                Console.WriteLine("Оберiть:");
                Console.WriteLine("1 - ввести код з клавiатури");
                Console.WriteLine("2 - контрольний приклад");
                Console.WriteLine("Введiть будь-який iнший символ, чтоб вийти");
                string Input = Console.ReadLine();
                if (Int32.TryParse(Input, out Choice))
                {
                    if (Choice != 1 && Choice != 2)
                        return;

                    string HTMLCode = "";
                    if (Choice == 1)
                    {
                        HTMLCode = InputFromKeyboard();
                    }
                    else if (Choice == 2)
                    {
                        HTMLCode = DefaultCode;
                    }
                    try
                    {
                        parser.ParseString(HTMLCode);
                        Console.WriteLine("HTML код дійсний");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        parser.ClearStack();
                    }
                }
            }
            while (Choice == 1 || Choice == 2);
        }
        private static string InputFromKeyboard()
        {
            Console.WriteLine("Введіть HTML код:");
            string htmlCode = Console.ReadLine();
            return htmlCode;
        }
    }
}
