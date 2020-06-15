using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{    
    public delegate void UpdateLevelSubMenuDelegate(int i_NewLevel); 

    public class MainMenu
    {
        public event UpdateLevelSubMenuDelegate BecameSubMenu;

        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private int m_Index = 0;
        private string m_Title;
        private int m_Level;

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_Level = 0;
            AddMenuItem("Exit", ExitSystem);           
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        private int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        public List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public void AddMenuItem(string i_MenuItemTitle, Action i_FunctionToAdd)
        {
            MenuItem newMenuItem = new MenuItem(Index++);

            newMenuItem.Do += i_FunctionToAdd;
            newMenuItem.Title = i_MenuItemTitle;
            MenuItems.Add(newMenuItem);
        }

        public void AddMenuItem(string i_MenuItemTitle, MainMenu io_SubMenu)
        {
            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].Do -= io_SubMenu.ExitSystem;
            io_SubMenu.MenuItems[0].Do += Show;

            AddMenuItem(i_MenuItemTitle, io_SubMenu.Show);
            io_SubMenu.OnBecameSubMenu(Level + 1);
            BecameSubMenu += io_SubMenu.OnBecameSubMenu;
        }

        public void OnBecameSubMenu(int io_NewLevel)
        {            
            Level = io_NewLevel;

            if (BecameSubMenu != null)
            {
                BecameSubMenu.Invoke(io_NewLevel + 1);
            }
        }

        private void ExitSystem()
        {
            Environment.Exit(-1);
        }

        public void Show()
        {
            bool show = true;            

            printScreen();

            while (show)
            {
                getInput(out int choice);
                Console.Clear();
                MenuItems[choice].Invoke();
                Console.WriteLine("Press any key to continue..");                
                Console.ReadKey();
                printScreen();
            }
        }

        private void printScreen()
        {
            Console.Clear();
            Console.WriteLine("Menu level: {0}{1}====={2}=====", Level, Environment.NewLine, Title);

            foreach (MenuItem currMenuItem in MenuItems)
            {
                Console.WriteLine("{0}. {1}", currMenuItem.Index, currMenuItem.Title);
            }
        }

        private void getInput(out int io_Input)
        {
            io_Input = -1;

            Console.WriteLine("Please choose one of these options or press 0 to Quit/Back:");

            while (!int.TryParse(Console.ReadLine(), out io_Input) || io_Input < 0 || io_Input >= MenuItems.Count())
            {
                Console.WriteLine("Wrong Input - Try Again!");
            }
        }
    }
}
