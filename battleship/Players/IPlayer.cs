using System;

namespace battleship
{
    interface IPlayer
    {
        List<Ship> Ships { get; set; }
        GameBoard GameBoard { get; set; }
        FiringBoard FiringBoard { get; set; }
        bool HasLost { get; set; }
        string Name { get; }
    }
}