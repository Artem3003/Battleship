using System;

namespace battleship
{
    class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Width = 4;
            OccupationType = OccupationType.BATTLESHIP;
        }

        public override string SunkMessage()
        {
            return "Battleship is sunk";
        }
    }
}