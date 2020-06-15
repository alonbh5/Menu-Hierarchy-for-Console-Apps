using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action Do;

        protected string m_Title;
        private int m_Index;

        public MenuItem(int i_Index)
        {
            m_Index = i_Index;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int Index
        {
            get { return m_Index; }
        }

        public void Invoke()
        {
            if (Do != null)
            {
                Do.Invoke();
            }
        }
    }
}
