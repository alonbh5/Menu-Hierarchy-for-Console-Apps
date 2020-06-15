/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    interface IMenu
    {
        void Show();
        void GetChoice();
        bool Chosen();
        void AddOption();
        string Title { get; set; }
    }

    interface IAction
    {
        void Do();
    }

    public class MainMenu : IMenu
    {
        string m_Title;
        
        IAction x;
        List<MainMenu> m_MainMenu = new List<MainMenu>();

        MainMenu()
        {
            m_MainMenu.Show();
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public bool Chosen()
        {
            throw new NotImplementedException();
        }

        public void GetChoice()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            while(Chosen())
            {

            }
        }
    }
}*/