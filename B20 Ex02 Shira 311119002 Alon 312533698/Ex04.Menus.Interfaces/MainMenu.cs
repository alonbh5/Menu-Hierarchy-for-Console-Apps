using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    internal interface ISubMenu
    {
        void UpdateLevel(int i_NewLevel);
    }

    public class MainMenu : IClicked, ISubMenu
    {        
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly List<ISubMenu> r_SubMenus = new List<ISubMenu>();
        private string m_Title;
        private int m_Index = 0;
        private int m_Level;        

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_Level = 1;
            AddMenuItem("Exit", new ExitInterface());
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

        internal List<ISubMenu> SubMenus
        {
            get { return r_SubMenus; }
        }

        public void AddMenuItem(string i_Title, IClicked i_Item)
        {
            MenuItems.Add(new MenuItem(Index++, i_Title, i_Item));         
        }

        public void AddMenuItem(MainMenu io_SubMenu)
        {
            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].WhenClicked = this;
            io_SubMenu.MenuItems[0].IsMenu = true;

            AddMenuItem(io_SubMenu.Title, io_SubMenu as IClicked);
            MenuItems[MenuItems.Count() - 1].IsMenu = true;

            io_SubMenu.UpdateLevel(Level + 1);
            r_SubMenus.Add(io_SubMenu);
        }

        public void Show()
        {
            bool quit = false;             

            printMenu();

            while (!quit)
            {
                getInput(out int choice);

                ////**This condition added only for The drill demonstration**
                ////**in order to "bypass" Main menu 'exit' (Environment.Exit) option**
                
                if (choice == 0 && Level == 1)
                {
                    quit = true;
                }
                else 
                {
                    Console.Clear();
                    MenuItems[choice].Click();

                    if (MenuItems[choice].IsMenu)
                    {
                        quit = true;
                    }
                    else
                    {
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        printMenu();
                    }
                }
            }  
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu level: {0}{1}====={2}=====", Level, Environment.NewLine, Title);

            foreach (MenuItem currMenuItem in MenuItems)
            {
                currMenuItem.Show();                
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

        void IClicked.Execute()
        {
            this.Show();
        }

        public void UpdateLevel(int i_NewLevel)
        {
            Level = i_NewLevel;

            if (SubMenus != null)
            {
                foreach (ISubMenu currSubMenu in SubMenus)
                {
                    currSubMenu.UpdateLevel(Level + 1);
                }
            }
        }
    }
}