using Ex04.Menus.Delegates;
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
            Ex04.Menus.Delegates.MainMenu myManu = new Ex04.Menus.Delegates.MainMenu("Main Manu");  
            Ex04.Menus.Delegates.MainMenu subMenu1 = new Ex04.Menus.Delegates.MainMenu("Version and Digits");
            Ex04.Menus.Delegates.MainMenu subMenu2 = new Ex04.Menus.Delegates.MainMenu("Show Date/Time"); 


            subMenu1.AddOption("Count Capitals", Methods.CountCapitals); 
            subMenu1.AddOption("Show Version", Methods.ShowVersion);
            
            myManu.AddOption("Version and Digits", subMenu1); 
            myManu.AddOption("Show Date/Time", subMenu2);

            subMenu2.AddOption("Show Time", Methods.ShowTime);
            subMenu2.AddOption("Show Date", Methods.ShowDate);

            myManu.Show();

            
        }              

        
    }
}
