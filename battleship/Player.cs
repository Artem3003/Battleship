using System.Transactions;
using System.Globalization;
using System;

namespace battleship
{
    class Player
    {
        static Random random = new Random();
        private string name;
        public List<Ship> Ships;
        public GameBoard GameBoard;
        public FiringBoard FiringBoard;

        public Player(string name)
        {
            this.name = name;
            this.Ships = new List<Ship>()
            {
                new Battleship(),
                new Destroyer(),
                new Cruiser(),
                new Cruiser(),
                new Submarine(),
                new Submarine(),
                new Submarine()
            };
            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
        }

        public bool HasLost
        {
            get
            {
                return Ships.All(sh => sh.IsSunk);
            }
        }

        public string Name => name;

        public void PlaceShip()
        {
            foreach (Ship ship in Ships)
            {
                bool isOpen = true;
                while(isOpen)
                {
                    int startColumn = random.Next(0, 10);
                    int startRow = random.Next(0, 10);
                    int orientation = random.Next(1, 101) % 2; // 0 - horizontally, 1 - vertically
                    int endColumn = startColumn;
                    int endRow = startRow;

                    // place ship
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endRow++;
                        }
                    } else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endColumn++;
                        }
                    }

                    // we can not place ships beyond the boundaries of the board
                    if(endColumn >= 10 || endRow >= 10)
                    {
                        isOpen = true;
                        continue; // Reset while loop to select new panel
                    }

                    // Check if specified panels are occupied
                    ship.ShipPlacement = GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);

                    if (ship.ShipPlacement.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    if (ship.ShipPlacement.HasNeighbors(GameBoard.Board))
                    {
                        isOpen = true;
                        continue;
                    }

                    // Place ships
                    foreach (Panel panel in ship.ShipPlacement)
                    {
                        panel.OccupationType = ship.OccupationType;
                    }
                    isOpen = false;
                }
            }
        }

        // coppy game board of one player to another firing board
        public void FillFiringBoard(Player player)
        {
            for (int i = 0; i < FiringBoard.Board.Count; i++)
            {
                FiringBoard.Board[i] = player.GameBoard.Board[i];
            }
        }
    }
}