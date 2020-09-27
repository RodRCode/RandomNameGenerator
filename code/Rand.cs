using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RandomNameGenerator
{
    internal class Rand
    {
        internal static List<string> ListOfNames(int numberOfNames, List<string> firstNames, List<string> lastNames, List<string> outputListOfNames, bool middleNames)
        {
            var randomNumber = new Random();
            string currentFirstName;
            string currentMiddleName;
            string currentLastName;
            string currentFullName;
            outputListOfNames.Clear();

            for (int i = 0; i < numberOfNames; i++)
            {
                currentFirstName = firstNames[(randomNumber.Next(firstNames.Count - 1))];
                currentMiddleName = firstNames[(randomNumber.Next(firstNames.Count - 1))];
                currentLastName = lastNames[(randomNumber.Next(lastNames.Count - 1))];
                if (middleNames)
                {
                    currentFullName = currentFirstName + " " + currentMiddleName + " " + currentLastName;
                }
                else
                {
                    currentFullName = currentFirstName + " " + currentLastName;
                }
                outputListOfNames.Add(currentFullName);
            }
            return outputListOfNames;
        }

        internal static List<string> MaleAndFemaleNames(int numberOfNames, List<string> firstNamesMale, List<string> firstNamesFemale, List<string> lastNames, List<string> outputListOfNames, bool middleNames)
        {
            var randomNumber = new Random();
            string currentFirstName;
            string currentMiddleName;
            string currentLastName;
            string currentFullName;
            outputListOfNames.Clear();

            for (int i = 0; i < numberOfNames; i++)
            {
                if (randomNumber.Next(2) == 0)
                {
                    currentFirstName = firstNamesMale[(randomNumber.Next(firstNamesMale.Count - 1))];
                    currentMiddleName = firstNamesMale[(randomNumber.Next(firstNamesMale.Count - 1))];
                    currentLastName = lastNames[(randomNumber.Next(lastNames.Count - 1))];
                    if (middleNames)
                    {
                        currentFullName = currentFirstName + " " + currentMiddleName + " " + currentLastName;
                    }
                    else
                    {
                        currentFullName = currentFirstName + " " + currentLastName;
                    }
                    outputListOfNames.Add(currentFullName);
                }
                else
                {
                    currentFirstName = firstNamesFemale[(randomNumber.Next(firstNamesFemale.Count - 1))];
                    currentMiddleName = firstNamesFemale[(randomNumber.Next(firstNamesFemale.Count - 1))];
                    currentLastName = lastNames[(randomNumber.Next(lastNames.Count - 1))];
                    if (middleNames)
                    {
                        currentFullName = currentFirstName + " " + currentMiddleName + " " + currentLastName;
                    }
                    else
                    {
                        currentFullName = currentFirstName + " " + currentLastName;
                    }
                    outputListOfNames.Add(currentFullName);
                }
            }
            return outputListOfNames;
        }
    }
}