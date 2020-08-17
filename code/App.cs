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

        //Sets up values to be put into the interactive menu
        private int DetermineWhatUserWants()
        {

            Console.WriteLine("What would you like to do:");
            Console.WriteLine("1) Generate male names");
            Console.WriteLine("2) Generate female names");
            Console.WriteLine("3) Generate male and female names");
            Console.WriteLine("4) Generate male names");
            Console.WriteLine("5) Quit");
            Console.WriteLine();
            Console.Write("Your choice: ");

            int userChoice = Elicit.WholeNumber();
            return userChoice;
        }

        // Main logic hub of the program, stuff branches out from here
        private bool EventLoop()
        {
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

                switch (userChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Generate Male Names\n");
                        GenerateMaleNames();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Generate Female Names\n");
                        GenerateFemaleNames();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Generate Male and Female Names\n");
                        GenerateMaleAndFemaleNames();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Quit");
                        finished = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Default case");
                        break;
                }
            } while (!finished);

            return finished;
        }

        private void GenerateMaleAndFemaleNames()
        {
            Console.Write("How many would you like? ");
            int numberOfNames = Elicit.WholeNumber();
            outputListOfNames = Rand.MaleAndFemaleNames(numberOfNames, firstNamesMale, firstNamesFemale, lastNames, outputListOfNames);
            NowWhat();
        }

        private void PrintNames()
        {
            foreach (var name in outputListOfNames)
            {
                Console.WriteLine(name);
            }
        }

        private void GenerateFemaleNames()
        {
            Console.Write("How many would you like? ");
            int numberOfNames = Elicit.WholeNumber();
            outputListOfNames = Rand.FemaleNames(numberOfNames, firstNamesFemale, lastNames, outputListOfNames);
            NowWhat();
        }

        private void GenerateMaleNames()
        {
            Console.Write("How many would you like? ");
            int numberOfNames = Elicit.WholeNumber();
            outputListOfNames = Rand.MaleNames(numberOfNames, firstNamesMale, lastNames, outputListOfNames);
            NowWhat();
        }

        // After the names have been generated, what does the user want to do with them?
        private void NowWhat()
        {
            bool finished = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"OK, i've generated all {outputListOfNames.Count} names.");
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