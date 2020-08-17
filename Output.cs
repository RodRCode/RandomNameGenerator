using System;
using System.Collections.Generic;

namespace RandomNameGenerator
{
    internal class Output
    {

        //Intro text tells the user what this program does
        internal static void Intro()
        {
            ConsoleMenuPainter.TextColor();
            
            Console.WriteLine("Welcome, this is a simple Random Name Generator.\n\nIt gets the last names from the 2010 census.");
            Console.WriteLine("We are only using the last names that show up at least once in \n" +
                "every 100,000 people you would likely meet in the United States.\n");
            Console.WriteLine("For the first and middle names I am using data from the Social Security Administration for the \n" +
                "birth year of 2018 (the latest available at the time the program was written.\n\n" +
                "What would you like to do? (Make your selection with the \n" +
                "arrow or number key and then hit enter)");
        }

        // A final goodbye for the user
        internal static void ClosingMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\nThanks! Have a Great day!\n\n\n");
        }
    }
}