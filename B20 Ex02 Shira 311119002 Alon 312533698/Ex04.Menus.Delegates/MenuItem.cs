using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action Clicked;

        protected string m_Title;
        private readonly int r_Index;

        public MenuItem(int i_Index)
        {
            r_Index = i_Index;
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int Index
        {
            get { return r_Index; }
        }

        public void Show()
        {
            Console.WriteLine("{0}. {1}", Index, Title);
        }

        public void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke();
            }
        }
    }
}