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
            //Loop for input
            while (repeat)
            {
                try
                {
                    DrawMenu();
                    string userInput = Console.ReadLine();
                   
                    //Check for valid input
                    ValidAmount(userInput);
                    ValidYear(userInput);                    
                    ValidMonth(userInput);
                    ValidDay(userInput);
                    ValidControlNum(userInput);
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
                    //break
                    repeat = false;
                }
                else
                {
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
            string y = userInput.Substring(0, 4);
            int year = int.Parse(y);
            
            if (year >= 1753 && year <= 2020)
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
            string m = userInput.Substring(4, 2);
            int month = int.Parse(m);
            
            if (month >= 1 && month <= 12)
            {
                return true;
            }
            else
            {
                return false;
            }              
        }
        //=====Only used in ValidDay=======
        static bool IsLeapYear(string userInput)
        {
            string y = userInput.Substring(0, 4);
            int year = int.Parse(y);

            if (year % 400 == 0 || year % 100 != 0 && year % 4 == 0)
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
            int[] month31days = { 1, 3, 5, 7, 8, 10, 12 };
            int[] month30days = { 4, 6, 9, 11 };
            int[] feb = { 2 };

            if (int.Parse(day) < 1)
            {
                return false;
            }

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
        static bool ValidControlNum(string userInput)
        {
            string num = userInput.Substring(8, 4);
            int cnum = int.Parse(num);
            if (cnum > 1111)
            {
                return true;
            }
            else
            {
                return false;
            }               
        }
        static bool Gender(string userInput)
        {
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
            if (ValidAmount(userInput) && ValidYear(userInput) && ValidMonth(userInput) && ValidDay(userInput) && ValidControlNum(userInput))
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
