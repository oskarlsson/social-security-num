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
            //Loop the input when its not valid
            while (repeat)
            {
                try
                {
                    DrawMenu();
                    
                    //input from user
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
            int amount = 0;
            foreach (char num in userInput)
            {
                amount += 1;
            }
            //Check if input is 12 numbers
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
            string year = userInput.Substring(0, 4);
            int y = int.Parse(year);
            
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
            string month = userInput.Substring(4, 2);
            int m = int.Parse(month);
            
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
            string year = userInput.Substring(0, 4);
            int y = int.Parse(year);

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
            string year = userInput.Substring(0, 4);
            string month = userInput.Substring(4, 2);
            string day = userInput.Substring(6, 2);           
            
            //Array of numbers that match userinput
            int[] month31days = { 1, 3, 5, 7, 8, 10, 12 };
            int[] month30days = { 4, 6, 9, 11 };
            int[] feb = { 2 };

            //Day can't be lower than one
            if (int.Parse(day) < 1)
            {
                return false;
            }
            
            //Checks if the Substring for month matches any of the for-loops
            //Turning it false if second condition is met
            for (int i = 0; i < month31days.Length; i++)
            {
                if (month31days[i] == int.Parse(month))
                {
                    if (int.Parse(day) > 31)
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < month30days.Length; i++)
            {
                if (month30days[i] == int.Parse(month))
                {
                    if (int.Parse(day) > 30)
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < feb.Length; i++)
            {
                if (feb[i] == int.Parse(month))
                {
                    if (IsLeapYear(year) == true)
                    {
                        if (int.Parse(day) > 29)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (int.Parse(day) > 28)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        static bool Gender(string userInput)
        {
            //
            string num = userInput.Substring(10, 1);
            int genNum = int.Parse(num);
            if (genNum % 2 == 0)
            {
                return false;
            }
            else
            {
                return true;
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
