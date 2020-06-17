using System;

namespace Ex04.Menus.Delegates
{
    public delegate void ClickInvoker();  
    
    public class MenuItem
    {
        private readonly int r_Index;

        internal event ClickInvoker Clicked;

        private string m_Title;        
        private bool m_IsMenu = false;

        internal MenuItem(int i_Index)
        {
            r_Index = i_Index;
        }

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        internal bool IsMenu
        {
            get { return m_IsMenu; }
            set { m_IsMenu = value; }
        }

        internal int Index
        {
            get { return r_Index; }
        }

        public void Show()
        {
            Console.WriteLine("{0}. {1}", Index, Title);
        }

        internal void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke();
            }
        }
    }
}