using System;

namespace Ex04.Menus.Interfaces
{
    internal class ExitInterface : IClicked
    {
        public void Execut()
        {
            Environment.Exit(-1);
        }
    }
}
