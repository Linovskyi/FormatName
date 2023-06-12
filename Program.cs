using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Please enter your full name:");
            string inputWithPrefix = Console.ReadLine();

            if (inputWithPrefix.ToLower() == "exit")
            {
                exit = true;
            }
            else
            {
                string formattedNameWithPrefix = FormatNameWithPrefix(inputWithPrefix);
                Console.WriteLine("Formatted name: " + formattedNameWithPrefix);
            }
        }

        Console.ReadLine();
    }

    static string FormatNameWithPrefix(string input)
    {
        string[] parts = input.ToLower().Split(' ');
        string formattedName = "";

        foreach (string part in parts)
        {
            string formattedPart = "";

            bool isPrefix = Regex.IsMatch(part, @"^(von|der|de|van|le)$", RegexOptions.IgnoreCase);

            if (isPrefix)
            {
                formattedPart = part.ToLower();
            }
            else
            {
                formattedPart = part.Substring(0, 1).ToUpper() + part.Substring(1);
            }

            formattedName += formattedPart + " ";
        }

        return formattedName.Trim();
    }
}
