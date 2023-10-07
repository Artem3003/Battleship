using System;

namespace battleship
{
    interface IBoard
    {
        static int size;
        List<Panel> Board { get; set; }

        static IBoard()
        {
            size = 10;
        }
    }
}