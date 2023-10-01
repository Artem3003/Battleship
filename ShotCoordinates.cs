using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using System;

namespace battleship
{
    class ShotCoordinates
    {
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
                }
                throw new ArgumentException();
            }
        }
    }
}