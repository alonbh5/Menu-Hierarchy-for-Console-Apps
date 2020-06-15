using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface ISubMenu
    {
        void UpdateLevel(int i_NewLevel);
    }

    public class MainMenu : IClicked, ISubMenu
    {        
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly List<ISubMenu> r_SubMenus = new List<ISubMenu>();
        private int m_Index = 0;
        private string m_Title;
        private int m_Level;        

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_Level = 0;
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

        public void AddMenuItem(string i_Title, IClicked i_Item)
        {
            MenuItems.Add(new MenuItem(Index++, i_Title, i_Item));         
        }

        public void AddMenuItem(string i_Title, MainMenu io_SubMenu)
        {
            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].WhenClicked = this;

            AddMenuItem(i_Title, io_SubMenu as IClicked);

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
                Console.Clear();
                MenuItems[choice].Click();
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                printMenu();
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

        void IClicked.Execut()
        {
            this.Show();
        }

        public void UpdateLevel(int i_NewLevel)
        {
            Level = i_NewLevel;

            if (r_SubMenus != null)
            {
                foreach (ISubMenu curSubMenu in r_SubMenus)
                {
                    curSubMenu.UpdateLevel(Level + 1);
                }
            }
        }
    }
}