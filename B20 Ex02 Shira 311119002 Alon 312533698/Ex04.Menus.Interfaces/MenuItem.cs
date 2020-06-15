using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public interface IClicked
    {
        void Execut();
    }

    public class MenuItem 
    {
        protected string m_Title;
        private int m_Index;
        IClicked m_WhenClicked;

        public MenuItem(int i_Index,string i_Title, IClicked i_WhenClicked)
        {
            m_Index = i_Index;
            m_Title = i_Title;
            m_WhenClicked = i_WhenClicked;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        
        public IClicked WhenClicked
        {
            get { return m_WhenClicked; }
            set { m_WhenClicked = value; }
        }

        public int Index
        {
            get { return m_Index; }
        }

        public void Show()
        {
            Console.WriteLine("{0}. {1}", Index, Title);
        }

        public void Click()
        {
            WhenClicked.Execut();
        }
    }
}