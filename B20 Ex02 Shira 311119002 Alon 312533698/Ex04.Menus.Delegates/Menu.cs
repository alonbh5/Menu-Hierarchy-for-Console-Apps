using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{    
    public delegate void Clicked(); // sdad void sdaas ()
    
    public class MainMenu
    {
        public List<Menu> m_Main = new List<Menu>();
    }

    public delegate void UpdateLevelSubMenu(); // sdad void sdaas ()

    public class Menu
    { 
        private int s_Index = 0;
        string m_Title;
        int m_level = 0;
        //public event Action Clicked;
        public List<Option> Options = new List<Option>();
        public event UpdateLevelSubMenu BecameSubMenu;



        public Menu(string title)
        {
            Option newOption = new Option(s_Index++);
            m_Title = title;

            
            newOption.Do += ExitSystem;
            //newOption.Do -= ManuOption_Do;
            //newOption.Do += pro;
            newOption.Text = "Exit";                  

            Options.Add(newOption);
        }

        public static void pro ()
        {
            Console.WriteLine("Go GO ");
        }

        //public int Index
       // {
        //    get { return s_Index++; }
        //}

        //public void MakeBack (Action Func)
        //{
        //    Options[0].Text = "Back";
        //    Options[0].Do -= ManuOption_Do;
        //    Options[0].Do += Func;
        //}

        public void AddOption (string title, Action func) 
        {
            Option newOption = new Option(s_Index++);
            newOption.Do += func;
            newOption.Text = title;

            Options.Add(newOption);
        }

        public void AddOption(string title, Menu subManu)
        {
            subManu.Options[0].Text = "Back";
            
            
            subManu.Options[0].Do -= subManu.ExitSystem;
            subManu.Options[0].Do += Show;

            AddOption(title, subManu.Show);

            subManu.UpdateLevel();
            BecameSubMenu += subManu.UpdateLevel;

        }

        public void UpdateLevel()
        {
            m_level++;
            if (BecameSubMenu != null)
            {
                BecameSubMenu.Invoke();
            }
        }

        private void ExitSystem()
        {
            Environment.Exit(-1);
        }

        public void Show()
        {
            Console.Clear();
            int x = 0;
            bool flag = true;

            Console.WriteLine("Menu level: {0}{1}====={2}=====", m_level, Environment.NewLine, m_Title);

            foreach (Option curOption in Options)
            {
                Console.WriteLine("{0} - {1}", curOption.m_Index, curOption.Text);
                               
            }
            while (flag)
            {
                getInput(out x);
                Options[x].Invoke();                
            }

            

        }

        private void getInput (out int io_input)
        {
            Console.WriteLine("Please choose option");
            int.TryParse(Console.ReadLine(), out io_input);
            //check valid 
        }
    }

    public class Option
    {      
        public event Action Do;
        internal int m_Index;
        protected string m_Text;

        public Option(int index)
        {
            m_Index = index;
        }

        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

         public void Invoke()
        {
            if (Do != null)
            {
                Do.Invoke();
            }
        }

        
        /*public void TellMeIWasClicked()
        {
            //if (m_ClickNotifyDelegate != null)
            {
            //    m_ClickNotifyDelegate.Invoke(this);
            }
        }*/
    }
}
