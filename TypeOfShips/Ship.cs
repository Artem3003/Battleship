using System;

namespace battleship
{
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Width { get; set; } 
        public OccupationType OccupationType { get; set; }
    }
}


