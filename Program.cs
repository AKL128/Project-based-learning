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
            if (int.TryParse(arg, out int number) == false) {
                Console.WriteLine($"{arg} is not a valid integer.");
                Console.WriteLine("Program terminated");
                System.Environment.Exit(1);
            }
            else 
            {
                numberList.Add(number);
            }
                
        }
        
        while (true)
        {
            if (args.Length < 2)
            {
                Console.Write("Enter an integer: ");
                input = Console.ReadLine();
            
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                if (int.TryParse(input, out int number))
                {
                    numberList.Add(number);
                }
                else 
                {
                Console.WriteLine("Invalid input! Please enter a valid ineger.");
                }
            }
            else
            {
                break;
            }
        }

        foreach (int number in numberList) {
            Console.WriteLine(number);
        }


            




        }
    }
}