using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using System;

namespace battleship
{
    class ShotCoordinates
    {
        static Random random = new Random();
        private int column;
        private char row;

        public ShotCoordinates(char row, int column) 
        {
            this.row = row;
            this.column = column;
        }

        public int Column 
        { 
            get
            {
                if (column > 10 || column < 0)
                {
                    return random.Next(0, 10);
                }
                return column - 1;
            }
        }
        public int Row
        { 
            get
            {
                // convert from letter to number 
                if (Char.IsLetter(row) && Char.IsUpper(row))
                {
                    return (int)row - 64 - 1;
                } else
                {
                    return random.Next(0, 10);
                }
            }
        }
    }
}