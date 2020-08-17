using System;
using System.Collections.Generic;
using System.IO;

namespace RandomNameGenerator
{
    internal class FileStuff
    {
        internal static void WriteToFile(List<string> outputListOfNames, string fileName) //writes data to a file on the disk
        {
            Console.WriteLine("\nThe default file name is 'ListOfNames.txt', if you want something different");
            Console.Write("Enter it here, or just hit return for the default name: ");
            string newFileName = Console.ReadLine();
            string newFileNameTest = RemoveInvalidChars(newFileName);
            if(newFileName != newFileNameTest)
            {
                newFileName = newFileNameTest;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"That filename had invalid characters in it.  It was changed to \"{newFileNameTest}\"");
                Console.ResetColor();
            }
            if (newFileName != "")
            {
                fileName = newFileName;
            }
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(fileName);
                int i = 0;
                foreach (var item in outputListOfNames)
                {
                    sw.WriteLine(item);
                    i++;
                }
                //Close the file
                sw.Close();
                Console.WriteLine($"List saved successfully to {fileName}");
                Console.Write("Hit enter to continue back and start a new list");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Hitting the writing finally block");
            }
        }

        private static string RemoveInvalidChars(string newFileName)
        {
            return string.Concat(newFileName.Split(Path.GetInvalidFileNameChars()));
        }

        internal static void ReadFiles(List<string> firstNamesFemale, List<string> firstNamesMale, List<string> lastNames)
        {
            string femaleFirstNamesFile = "FemaleFirstNames.csv";
            string maleFirstNamesFile = "MaleFirstNames.csv";
            string lastNamesFile = "LastNames.csv";

            try
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(femaleFirstNamesFile))
                {
                    while (sr.Peek() >= 0)
                    {
                        firstNamesFemale.Add(sr.ReadLine());
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading the Female First Names File failed: {0}", e.ToString());
            }

            try
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(maleFirstNamesFile))
                {
                    while (sr.Peek() >= 0)
                    {
                        firstNamesMale.Add(sr.ReadLine());
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading the Male First Names File failed: {0}", e.ToString());
            }

            try
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(lastNamesFile))
                {
                    while (sr.Peek() >= 0)
                    {
                        lastNames.Add(sr.ReadLine());
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Reading the Last Names File failed: {0}", e.ToString());
            }
        }
    }
}
