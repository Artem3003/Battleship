using System;

namespace battleship
{
    class Coordinates
    {
        private int row;
        private int column;
        public Coordinates(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int Row => row;

        public int Column => column;
    }
}