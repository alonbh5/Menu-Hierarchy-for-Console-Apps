namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Delegates.MainMenu DelegateMenu = Menus.CreateMainMenuDelegate();

            DelegateMenu.Show();

            Interfaces.MainMenu InterfaceMenu = Menus.CreateMainMenuInterfaces();

            InterfaceMenu.Show();
        }
    }
}