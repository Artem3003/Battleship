using System;

namespace battleship
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destoryer";
            Width = 3;
            OccupationType = OccupationType.DESTROYER;
        }
    }
}