using System;
using System.Collections;
using System.CommandLine;
using System.CommandLine.Parsing;
using System.CommandLine.Builder;
using System.CommandLine.Help;

using System.IO;

namespace mathApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {

            var intArgument = new Argument<int>();




            var cmd = new RootCommand(@"This is a program that calculates the 
average, median, maximum and minimum 
of a set of values given at the command line
or from one entry at a time followed by an enter key.")
            {

            };

            cmd.Add(intArgument);




            string? input;
            List<int> numberList = new List<int>();


            if (args.Length == 0)
            {
                while (true)
                {
                    if (args.Length < 1)
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
            }
            else
            {
                foreach (string arg in args)
                {
                    if (args[0].Equals("-h"))
                    {
                        await cmd.InvokeAsync(args);
                        System.Environment.Exit(0);
                    }
                    if (int.TryParse(arg, out int number) == false)
                    {


                        Console.WriteLine($"{arg} is not a valid integer.");
                        Console.WriteLine("Program terminated");
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        numberList.Add(number);
                    }
                }
            }


            if (numberList.Count == 0)
            {
                Console.WriteLine("No numbers added.");
                Console.WriteLine("Program terminated");
                System.Environment.Exit(1);
            }

            int maxNumber = numberList.Max();
            int maxOccurrence = 0;

            int minNumber = numberList.Min();
            int minOccurrence = 0;
            int total = 0;
            foreach (int number in numberList)
            {

                if (maxNumber == number)
                {
                    maxOccurrence += 1;
                }
                if (minNumber == number)
                {
                    minOccurrence += 1;
                }

                total += number;

            }

            static decimal getMedian(List<int> medianList)
            {
                int totalNumbers = medianList.Count;
                medianList.Sort();

                if (totalNumbers % 2 == 0)
                {
                    int index1 = (totalNumbers / 2) - 1;
                    int index2 = (totalNumbers / 2);
                    return (medianList[index1] + medianList[index2]) / 2.0m;
                }
                else
                {
                    return medianList[totalNumbers / 2];
                }
            }


            decimal averageLibrary = (decimal)numberList.Average();
            Console.WriteLine($"Average using Library: {averageLibrary}");

            decimal average = (decimal)total / numberList.Count;
            Console.WriteLine($"Average Manual: {average}");
            Console.WriteLine($"Median: {getMedian(numberList)}");
            Console.WriteLine($"Max: {maxNumber} ({maxOccurrence})");
            Console.WriteLine($"Min: {minNumber} ({minOccurrence})");




        }
    }
}