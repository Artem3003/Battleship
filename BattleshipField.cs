using System.Runtime.Serialization.Json;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;

namespace battleship
{
    class BattleshipField
    {
        private Dictionary<OccupationType, int> amountOfShips = new Dictionary<OccupationType, int>() {
                { OccupationType.BATTLESHIP, 1},
                { OccupationType.CRUISER, 2},
                { OccupationType.DESTROYER, 3},
                { OccupationType.SUBMARINE, 4}};
        public bool ValidateBattlefield(int[,] field)
        {
            bool isValid = true;
            int size = field.GetLength(0);
            // find all ships parallel to the OX axis
            for (int i = 0; i < size; i++)
            {
                int shipCounter = 0;
                for (int j = 0; j < size; j++)
                {
                    if (field[i, j] == 1)
                    {
                        shipCounter++;
                    } 
                    if (field[i, j] == 0)
                    {
                        if(shipCounter > 1)
                        {
                            amountOfShips[BattleshipType(shipCounter)] -= 1;
                        }
                        shipCounter = 0;
                    }
                }
            }

            // find all ships parallel to the OY axis
            for (int i = 0; i < size; i++)
            {
                int shipCounter = 0;
                for (int j = 0; j < size; j++)
                {
                    if (field[j, i] == 1)
                    {
                        shipCounter++;
                    } 
                    if (field[j, i] == 0)
                    {
                        if(shipCounter > 1)
                        {
                            amountOfShips[BattleshipType(shipCounter)] -= 1;
                        }
                        shipCounter = 0;
                    }
                }
            }

            // find all submarines
            int subCounter = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 1 && !FindNeighbors(i, j, field))
                    {
                        subCounter++;
                    }
                }
            }
            amountOfShips[OccupationType.SUBMARINE] -= subCounter;

            // check correction of ship positions
            foreach (int amountOfShip in amountOfShips.Values)
            {
                if (amountOfShip < 0 || amountOfShip > 0)
                {
                    isValid = false;
                }
            }
            
            return isValid;
        }

        // find out type of ship
        private OccupationType BattleshipType(int size)
        {
            if (size == 4)
            {
                return OccupationType.BATTLESHIP;
            }
            if (size == 3)
            {
                return OccupationType.CRUISER;
            }
            if (size == 2)
            {
                return OccupationType.DESTROYER;
            }
            throw new ArgumentException();
        }

        private bool FindNeighbors(int i, int j, int[,] field)
        {
            int size = field.GetLength(0);
            bool isNeighbor = false;
            // up
            if (i > 0)
            {
                if(field[i - 1, j] == 1)
                {
                    isNeighbor = true;
                }
            }
            // down
            if (i < size - 1)
            {
                if(field[i + 1, j] == 1)
                {
                    isNeighbor = true;
                }
            }
            // right
            if (j < size - 1)
            {
                if(field[i, j + 1] == 1)
                {
                    isNeighbor = true;
                }
            }
            // left
            if (j > 0)
            {
                if(field[i, j - 1] == 1)
                {
                    isNeighbor = true;
                }
            }
            return isNeighbor;
        }
    }

    public enum OccupationType
    {
        BATTLESHIP,
        CRUISER,
        DESTROYER,
        SUBMARINE
    }
}