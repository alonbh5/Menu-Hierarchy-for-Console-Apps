﻿using Ex04.Menus.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    class Program
    {
        public static void Main()
        {

            Ex04.Menus.Delegates.Menu myManu = new Ex04.Menus.Delegates.Menu("Main Manu");                       
            Ex04.Menus.Delegates.Menu subMenu1 = new Ex04.Menus.Delegates.Menu("Version and Digits");
            Ex04.Menus.Delegates.Menu subMenu2 = new Ex04.Menus.Delegates.Menu("Show Date/Time");
            Ex04.Menus.Delegates.Menu subsubMenu3 = new Ex04.Menus.Delegates.Menu("subsubMenu3");


            //subMenu1.Options.Add(new Option("Show Time", ShowTime, myManu2.Index));
            subMenu1.AddOption("Count Capitals", CountCapitals); //1
            subMenu1.AddOption("Show Version", ShowVersion);
            subMenu1.AddOption("Sub 3", subsubMenu3); //2

           // myManu.AddOption("Version and Digits", subMenu1.Show); //0
            myManu.AddOption("Version and Digits", subMenu1); //0
            myManu.AddOption("Show Date/Time", subMenu2); //1

            
            
            subMenu2.AddOption("Show Time", ShowTime);
            subMenu2.AddOption("Show Date", ShowDate);

            
            myManu.Show();

            
        }              

        public static void CountCapitals()
        {
            Console.WriteLine("Please enter your sentence:");
            string input = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    count++;
                }
            }

            Console.WriteLine("There are {0} upper case letters in your sentence.", count);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 20.2.4.30620");
        }

        public static void ShowTime()
        {
            Console.WriteLine(DateTime.Now.ToString());
        }

        public static void ShowDate()
        {
            Console.WriteLine(DateTime.Today.ToString());
        }
    }
}
