using System;

namespace battleship
{
    abstract class Ship
    {
        public string? Name { get; set; }
        public int Width { get; set; } 
        public int Hits { get; set; }
        public List<Panel> ShipPlacement { get; set; }
        public OccupationType OccupationType { get; set; }
        public bool IsSunk { 
            get
            {
                return Hits >= Width;
            }
        }
    }
}


