using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Personnummer3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            //Loop the input
            while (repeat)
            {
                try
                {
                    DrawMenu();

                    //Input from user
                    string userInput = Console.ReadLine();

                    //Check for valid input
                    ValidAmount(userInput);
                    ValidYear(userInput);
                    ValidMonth(userInput);
                    ValidDay(userInput);
                    Output(userInput);
                }
                catch
                {
                    Console.WriteLine("*************************");
                    Console.WriteLine("* Ogiltigt personnummer *");
                    Console.WriteLine("*************************");
                }

                Console.Write("Prova igen? Y/N: ");
                string go = Console.ReadLine();
                if (go.ToUpper() != "Y")
                {
                    //Breaks the loop
                    repeat = false;
                }
                else
                {
                    //Clears console when retrying
                    Console.Clear();
                }
            }
        }
        static bool ValidAmount(string userInput)
        {
            //Check if input is 12 numbers
            int amount = 0;
            foreach (char num in userInput)
            {
                amount += 1;
            }
            //Returns false if amount of chars in input is not equal to 12
            if (amount != 12)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool ValidYear(string userInput)
        {
            //Picks and converts the year from the input to interger
            string year = userInput.Substring(0, 4);
            int y = int.Parse(year);
            //Return true if year is within range
            if (y >= 1753 && y <= 2020)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool ValidMonth(string userInput)
        {
            //Picks and converts the month from the input to interger
            string month = userInput.Substring(4, 2);
            int m = int.Parse(month);
            //Returns true if month is  within range
            if (m >= 1 && m <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool IsLeapYear(string userInput)
        {
            //Picks and converts the year from the input to interger
            string year = userInput.Substring(0, 4);
            int y = int.Parse(year);
            //Returns true if the year is a leap year
            if (y % 400 == 0 || y % 100 != 0 && y % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool ValidDay(string userInput)
        {
            //Picks the year, month and day to substrings
            //<string year is only used in the IsLeapYear method so it does not require conversion>
            string year = userInput.Substring(0, 4);
            string m = userInput.Substring(4, 2);
            int month = int.Parse(m);
            string d = userInput.Substring(6, 2);
            int day = int.Parse(d);

            //Array of numbers that match userinput for months with 30 days
            int[] month30days = { 4, 6, 9, 11 };
            //No need for array since february is the one case with less than 30 days
            int feb = 2;

            //Day can't be lower than 1 or higher than 31
            if (day < 1 && day > 31)
            {
                return false;
            }

            //Checks if the Substring for month matches the array 
            //Turning it false if second condition is met            
            for (int i = 0; i < month30days.Length; i++)
            {
                if (month30days[i] == month)
                {
                    if (day > 30)
                    {
                        return false;
                    }
                }
            }

            if (feb == month)
            {
                if (IsLeapYear(year) == true)
                {
                    if (day > 29)
                    {
                        return false;
                    }
                }
                else
                {
                    if (day > 28)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool Gender(string userInput)
        {
            //Pick and converts the number speciyfing the gender, then is divided by 2 to return outcome.
            string num = userInput.Substring(10, 1);
            int genNum = int.Parse(num);
            if (genNum % 2 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Output(string userInput)
        {
            if (ValidAmount(userInput) && ValidYear(userInput) && ValidMonth(userInput) && ValidDay(userInput))
            {
                Console.WriteLine("*************************");
                Console.WriteLine("* Giltigt personnummer  *");
                if (Gender(userInput))
                {
                    Console.WriteLine("*     Juridisk man      *");
                    Console.WriteLine("*************************");
                }

                else
                {
                    Console.WriteLine("*    Juridisk kvinna    *");
                    Console.WriteLine("*************************");
                }
            }
            else
            {
                Console.WriteLine("*************************");
                Console.WriteLine("* Ogiltigt personnummer *");
                Console.WriteLine("*************************");
            }
        }
        static void DrawMenu()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("*                       *");
            Console.WriteLine("* Ange ett personnummer *");
            Console.WriteLine("*    med 12 siffror     *");
            Console.WriteLine("*                       *");
            Console.WriteLine("*************************");
        }
    }
}
