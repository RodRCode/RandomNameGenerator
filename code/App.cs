using System;
using System.Collections.Generic;

namespace RandomNameGenerator
{
    public class App
    {
        List<String> lastNames = new List<string>();
        List<String> firstNamesMale = new List<string>();
        List<String> firstNamesFemale = new List<string>();
        List<String> outputListOfNames = new List<string>();
        public App() // kept this here in case I want to add variables or a default construction
        {
        }

        // Main entry point for the application
        public void Run()
        {
            FileStuff.ReadFiles(firstNamesFemale, firstNamesMale, lastNames);

            EventLoop();
            Output.ClosingMessage();
            Console.ResetColor();
        }

        // Main logic hub of the program, stuff branches out from here
        private bool EventLoop()
        {
            ConsoleMenuPainter.TextColor();
            bool finished = false;
            do
            {
                string[] menuItems = new string[] {
                "1) Generate male names",
                "2) Generate female names",
                "3) Generate male and female names",
                "4) Quit" };
                Console.Clear();
                Output.Intro();
                int userChoice = Menu.Selection(menuItems, 0, 12); // the two digits are to place the menu on the x and y axis

                if (userChoice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Quit");
                    finished = true;
                }
                else
                {
                    GenerateNames(userChoice);
                }
            } while (!finished);

            return finished;
        }

        private void GenerateNames(int userChoice)
        {
            Console.Clear();
            ConsoleMenuPainter.TextColor();
            int numberOfNames;
            bool middleNames;

            switch (userChoice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("Generate Male Names\n");
                    (numberOfNames, middleNames) = GetNumberAndMiddleNameInput();
                    outputListOfNames = Rand.ListOfNames(numberOfNames, firstNamesMale, lastNames, outputListOfNames, middleNames);
                    NowWhat();
                    break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("Generate Female Names\n");
                    (numberOfNames, middleNames) = GetNumberAndMiddleNameInput();
                    outputListOfNames = Rand.ListOfNames(numberOfNames, firstNamesFemale, lastNames, outputListOfNames, middleNames);
                    NowWhat();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Generate Male and Female Names\n");
                    (numberOfNames, middleNames) = GetNumberAndMiddleNameInput();
                    outputListOfNames = Rand.MaleAndFemaleNames(numberOfNames, firstNamesMale, firstNamesFemale, lastNames, outputListOfNames, middleNames);
                    NowWhat();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Default case");
                    break;
            }
        }

        private (int, bool) GetNumberAndMiddleNameInput()
        {
            Console.Write("How many would you like? ");
            int numberOfNames = Elicit.WholeNumber();
            Console.Write("Now, do you want middle names as well (y/n)? ");
            bool middleNames = GetYesOrNoAnswer();
            return (numberOfNames, middleNames);
        }

        private bool GetYesOrNoAnswer()
        {
            do
            {
                var answer = Console.ReadKey(true);
                switch (answer.Key)
                {
                    case ConsoleKey.Y:
                        Console.Write("y");
                        return true;
                    case ConsoleKey.N:
                        Console.Write("n");
                        return false;
                    default:
                        break;
                }
            } while (true);
        }

        private void PrintNames()
        {
            foreach (var name in outputListOfNames)
            {
                ConsoleMenuPainter.TextColor();
                Console.WriteLine(name);
            }
        }

        // After the names have been generated, what does the user want to do with them?
        private void NowWhat()
        {
            ConsoleMenuPainter.TextColor();
            bool finished = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"OK, I've generated all {outputListOfNames.Count} names.");
                Console.WriteLine("What would you like to do?\n");
                int userChoice = Elicit.WhatNowMenu(0, 5); // the two digits are to place the menu on the x and y axis

                switch (userChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Print the names to the screen\n");
                        PrintNames();
                        Console.WriteLine("\n\nHit enter to continue");
                        Console.ReadLine();
                        finished = true;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Print the names to a file\n");
                        FileStuff.WriteToFile(outputListOfNames, "ListOfNames.txt");
                        finished = true;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Both\n");
                        PrintNames();
                        FileStuff.WriteToFile(outputListOfNames, "ListOfNames.txt");
                        finished = true;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Quit");
                        Console.ResetColor();
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Default case");
                        finished = true;
                        break;
                }
            } while (!finished);
        }
    }
}