using System;

namespace battleship
{
    class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 1;
            OccupationType = OccupationType.SUBMARINE;
        }
    }
}