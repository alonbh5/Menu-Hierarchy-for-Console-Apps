using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{    
    public delegate void UpdateLevelSubMenu(int i_NewLevel); 

    public class MainMenu
    { 
        private int s_Index = 0;
        internal string m_Title;
        internal int m_Level;
        internal List<Option> Options = new List<Option>();
        public event UpdateLevelSubMenu BecameSubMenu;

        public MainMenu(string i_Title)
        {
            m_Title = i_Title;
            m_Level = 0;
            AddOption("Exit", ExitSystem);           
        }

        public string Title
        {
            get { return m_Title;}
            set { m_Title = value;}
        }
        public int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }   

        public void AddOption (string i_OptionTitle, Action i_FunctionToAdd) 
        {
            Option newOption = new Option(s_Index++);
            newOption.Do += i_FunctionToAdd;
            newOption.Text = i_OptionTitle;
            Options.Add(newOption);
        }

        public void AddOption(string i_OptionTitle, MainMenu io_SubManu)
        {
            io_SubManu.Options[0].Text = "Back";
            io_SubManu.Options[0].Do -= io_SubManu.ExitSystem;
            io_SubManu.Options[0].Do += Show;

            AddOption(i_OptionTitle, io_SubManu.Show);

            //subManu.Level = Level;
            io_SubManu.OnBecameSubMenu(Level+1);
            BecameSubMenu += io_SubManu.OnBecameSubMenu;
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
            Console.Clear();
            int choice;
            bool flag = true;
            

            printScreen();

            while (flag)
            {
                getInput(out choice);
                Console.Clear();
                Options[choice].Invoke();
                Console.WriteLine("Press any key to continue..");                
                Console.ReadKey();
                printScreen();
            }
        }

        private void printScreen()
        {
            Console.Clear();
            Console.WriteLine("Menu level: {0}{1}====={2}=====", Level, Environment.NewLine, Title);
            foreach (Option curOption in Options)
            {
                Console.WriteLine("{0} - {1}", curOption.m_Index, curOption.Text);
            }
        }

        private void getInput (out int io_Input)
        {
            io_Input = -1;

            Console.WriteLine("Please choose from option or press 0 to Quit/Back:");
            int.TryParse(Console.ReadLine(), out io_Input);

            while (io_Input < 0 || io_Input >= Options.Count())
            {
                Console.WriteLine("Wrong Input - Try again!");
                int.TryParse(Console.ReadLine(), out io_Input);
            }

        }
    }

    public class Option
    {      
        public event Action Do;
        internal int m_Index;
        protected string m_Text;

        public Option(int i_Index)
        {
            m_Index = i_Index;
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
        
    }
}
