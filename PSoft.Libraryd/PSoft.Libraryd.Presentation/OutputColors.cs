using System;

namespace PSoft.Libraryd.Presentation
{
    public class OutputColors
    {
        public static void Sucess(string stringSucess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stringSucess);
            Console.ResetColor();
        }
        public static void Warning(string stringWarning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(stringWarning);
            Console.ResetColor();
        }
        public static void Error(string stringError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(stringError);
            Console.ResetColor();
        }

        public static void ColorGray(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static void ColorYellow(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static void ColorBlue(string s)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}
