using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;


namespace Ex04.Menus.Test
{
    class Menus
    {
        public static Delegates.MainMenu CreateMainMenuDelegate ()
        {

            Delegates.MainMenu myMenu = new Delegates.MainMenu("Main Menu - Delegates");
            Delegates.MainMenu subMenu1 = new Delegates.MainMenu("Version and Digits");
            Delegates.MainMenu subMenu2 = new Delegates.MainMenu("Show Date/Time");

            subMenu1.AddMenuItem("Count Capitals", MethodsDelegates.CountCapitals);
            subMenu1.AddMenuItem("Show Version", MethodsDelegates.ShowVersion);
            myMenu.AddMenuItem("Version and Digits", subMenu1);
            myMenu.AddMenuItem("Show Date/Time", subMenu2);
            subMenu2.AddMenuItem("Show Time", MethodsDelegates.ShowTime);
            subMenu2.AddMenuItem("Show Date", MethodsDelegates.ShowDate);

            return myMenu;
        }

        public static Interfaces.MainMenu CreateMainMenuInterfaces()
        {

            Interfaces.MainMenu myMenu = new Interfaces.MainMenu("Main Menu - Interfaces");
            Interfaces.MainMenu subMenu1 = new Interfaces.MainMenu("Version and Digits");
            Interfaces.MainMenu subMenu2 = new Interfaces.MainMenu("Show Date / Time");


            subMenu1.AddMenuItem("Count Capitals", new CountCapitalsInterface());
            subMenu1.AddMenuItem("Show Version", new ShowVersionInterface());
            myMenu.AddMenuItem("Version and Digits", subMenu1);
            myMenu.AddMenuItem("Show Date/Time", subMenu2);


            subMenu2.AddMenuItem("Show Time", new ShowTimeInterface());
            subMenu2.AddMenuItem("Show Date", new ShowDateInterface());

            return myMenu;
        }
    }
}
