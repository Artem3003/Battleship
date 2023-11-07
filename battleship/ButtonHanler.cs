using System.Collections.Specialized;
using System;

namespace battleship
{
    class ButtonHandler
    {
        public delegate void ShipMoveHandler(string direction);
        public event ShipMoveHandler Click;

        public ButtonHandler()
        {
            Console.CancelKeyPress += CancelKeyPress;
        }

        private void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            if (e.SpecialKey == ConsoleSpecialKey.ControlBreak)
            {
                e.Cancel = true;
            }
        }

        // anonymous methodsa and lambda expressions
        // public ButtonHandler()
        // {
        //     Console.CancelKeyPress += (sender, e) =>
        //     {
        //         if (e.SpecialKey == ConsoleSpecialKey.ControlBreak)
        //         {
        //             e.Cancel = true;
        //         }
        //     };
        // }

        // Action and Func 
        // public Action<string> Click;
        // public Func<string, bool> Click; 

        public string ReadInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    return "up";
                case ConsoleKey.RightArrow:
                    return "right";
                case ConsoleKey.DownArrow:
                    return "down";
                case ConsoleKey.LeftArrow:
                    return "left";
                case ConsoleKey.Tab:
                    return "tab";
                default:
                    return "enter";
            }
            return null;
        }
    }
}