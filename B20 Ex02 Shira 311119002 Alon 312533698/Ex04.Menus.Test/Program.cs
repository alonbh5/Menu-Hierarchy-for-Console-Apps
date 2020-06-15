using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            MainMenu myMenu = new MainMenu("Main Menu");  
            MainMenu subMenu1 = new MainMenu("Version and Digits");
            MainMenu subMenu2 = new MainMenu("Show Date/Time"); 

            subMenu1.AddMenuItem("Count Capitals", Methods.CountCapitals); 
            subMenu1.AddMenuItem("Show Version", Methods.ShowVersion);            
            myMenu.AddMenuItem("Version and Digits", subMenu1);
            myMenu.AddMenuItem("Show Date/Time", subMenu2);
            subMenu2.AddMenuItem("Show Time", Methods.ShowTime);
            subMenu2.AddMenuItem("Show Date", Methods.ShowDate);

            myMenu.Show();            
        }              
    }
}
