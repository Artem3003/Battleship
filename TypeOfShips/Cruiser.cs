using System;

namespace battleship
{
    class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            Width = 2;
            OccupationType = OccupationType.CRUISER;
        }
    }
}