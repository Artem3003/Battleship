using System;

namespace battleship
{
    interface IBoard
    {
        static int size = 10;
        List<Panel> Board { get; set; }
    }
}