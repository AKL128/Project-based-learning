using System;
using System.Collections;
namespace mathApp
{
    class Program
    {
        public static void Main(string[] args)
        {
        string input;
        List<int> numberList = new List<int>();

        foreach (string arg in args)
        {
            if (int.TryParse(arg, out int number))
            {
                numberList.Add(number);
            }
        }
        


        }
    }
}