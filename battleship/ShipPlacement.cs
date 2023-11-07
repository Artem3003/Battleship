using System;

namespace battleship
{
    static class ShipPlacement
    {
        static Random random = new Random();

        // place ship randomly on the board
        public static void RandomPlaceShip(this IPlayer player)
        {
            foreach (Ship ship in player.Ships)
            {
                bool isOpen = true;
                while(isOpen)
                {
                    int startColumn = random.Next(0, 10);
                    int startRow = random.Next(0, 10);
                    int orientation = random.Next(1, 101) % 2; // 0 - horizontally, 1 - vertically
                    int endColumn = startColumn;
                    int endRow = startRow;

                    ship.ChangeOrientation(orientation, ref endRow, ref endColumn); // change orientation of ship

                    // we can not place ships beyond the boundaries of the board
                    if(endColumn >= 10 || endRow >= 10)
                    {
                        isOpen = true;
                        continue; // Reset while loop to select new panel
                    }

                    // Check if specified panels are occupied
                    ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);

                    if (ship.ShipPlacement.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    if (ship.ShipPlacement.HasNeighbors(player.GameBoard.Board))
                    {
                        isOpen = true;
                        continue;
                    }

                    ship.PlaceShip();
                    isOpen = false;
                }
            }
        }

        // place ships on board by player
        public static void PlayerPlaceShips(this IPlayer player)
        {
            foreach (Ship ship in player.Ships)
            {
                bool isOpen = true;
                int startColumn = 0;
                int startRow = 0;
                int endColumn = startColumn;
                int endRow = ship.Width - 1;
                while (player.GameBoard.Board.At(startRow, startColumn).IsOccupied || player.GameBoard.Board.At(endRow, endColumn).IsOccupied)
                {
                    startColumn += 1;
                }
                ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                ship.PlaceShip();
                Console.Clear();
                ShowsBoards.OutputGameBoard(player.GameBoard);

                ButtonHandler buttonHandler = new ButtonHandler();
                buttonHandler.Click += OnInputReceived;
                string userInput;
                while(isOpen)
                {
                    userInput = buttonHandler.ReadInput();
                    // go out from loop
                    if (userInput == "enter")
                    {
                        isOpen = false;
                    }

                    if (userInput == "right")
                    {
                        ship.MoveShip();
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        if(endColumn < 9 && (!player.GameBoard.Board.FindNeighbor(endRow, endColumn).IsOccupied || !player.GameBoard.Board.FindNeighbor(startRow, startColumn).IsOccupied))
                        {
                            startColumn += 1;
                            endColumn += 1;
                        }
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        if (ship.ShipPlacement.HasNeighbors(player.GameBoard.Board))
                        {
                            startColumn -= 1;
                            endColumn -= 1;
                            System.Console.WriteLine("You can not place ships near each other");
                            System.Threading.Thread.Sleep(1000);
                            ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        }
                    }
                    if (userInput == "left")
                    {
                        ship.MoveShip();
                        if(endColumn > 0 && (!player.GameBoard.Board.FindNeighbor(endRow, endColumn).IsOccupied || !player.GameBoard.Board.FindNeighbor(startRow, startColumn).IsOccupied))
                        {
                            startColumn -= 1;
                            endColumn -= 1;
                        }
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        if (ship.ShipPlacement.HasNeighbors(player.GameBoard.Board))
                        {
                            startColumn += 1;
                            endColumn += 1;
                            System.Console.WriteLine("You can not place ships near each other");
                            System.Threading.Thread.Sleep(1000);
                            ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        }
                    }
                    if (userInput == "up")
                    {

                        ship.MoveShip();
                        if (startRow > 0 && (!player.GameBoard.Board.FindNeighbor(endRow, endColumn).IsOccupied || !player.GameBoard.Board.FindNeighbor(startRow, startColumn).IsOccupied))
                        {
                            startRow -= 1;
                            endRow -= 1;   
                        }
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        if (ship.ShipPlacement.HasNeighbors(player.GameBoard.Board))
                        {
                            startRow += 1;
                            endRow += 1;
                            System.Console.WriteLine("You can not place ships near each other");
                            System.Threading.Thread.Sleep(1000);
                            ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        }
                    }
                    if (userInput == "down")
                    {
                        ship.MoveShip();
                        if(endRow < 9 && (!player.GameBoard.Board.FindNeighbor(endRow, endColumn).IsOccupied || !player.GameBoard.Board.FindNeighbor(startRow, startColumn).IsOccupied))
                        {
                            startRow += 1;
                            endRow += 1;
                        }
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        if (ship.ShipPlacement.HasNeighbors(player.GameBoard.Board))
                        {
                            startRow -= 1;
                            endRow -= 1;
                            System.Console.WriteLine("You can not place ships near each other");
                            System.Threading.Thread.Sleep(1000);
                            ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                        }
                    }
                    if (userInput == "tab")
                    {
                        ship.MoveShip();
                        if (endColumn == startColumn && endColumn + ship.Width - 1 <= 9 && !player.GameBoard.Board.FindNeighbor(startRow, endColumn + ship.Width - 1).IsOccupied)
                        {
                            endRow = startRow;
                            endColumn += ship.Width - 1;   
                        } else if (endColumn == startColumn && endColumn + ship.Width - 1 > 9 && !player.GameBoard.Board.FindNeighbor(startRow, endColumn - ship.Width - 1).IsOccupied)
                        {
                            endRow = startRow;
                            endColumn = startColumn;
                            startColumn -= ship.Width - 1;  
                        } else if (endRow == startRow && endRow + ship.Width - 1 <= 9 && !player.GameBoard.Board.FindNeighbor(endRow + ship.Width - 1, startColumn).IsOccupied)
                        {
                            endColumn = startColumn;
                            endRow += ship.Width - 1;
                        } else if (endRow == startRow && endRow + ship.Width - 1 > 9 && !player.GameBoard.Board.FindNeighbor(startRow - ship.Width - 1, startColumn).IsOccupied)
                        {
                            endColumn = startColumn;
                            endRow = startRow;
                            startRow -= ship.Width - 1;  
                        }
                        ship.ShipPlacement = player.GameBoard.Board.Range(startRow, startColumn, endRow, endColumn);
                    }
                    ship.PlaceShip();
                    Console.Clear();
                    ShowsBoards.OutputGameBoard(player.GameBoard);
                }
            }     
        }

        private static void OnInputReceived(string direction)
        {
            System.Console.WriteLine(direction);
        }

        // copy game board of one player to another firing board
        public static void FillFiringBoard(this IPlayer player, IPlayer rival)
        {
            for (int i = 0; i < player.FiringBoard.Board.Count; i++)
            {
                player.FiringBoard.Board[i] = rival.GameBoard.Board[i];
            }
        }

        // change orientation of ship
        private static void ChangeOrientation(this Ship ship, int orientation, ref int endRow, ref int endColumn)
        {
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
        }

        // move ship
        private static void MoveShip(this Ship ship)
        {
            foreach (Panel panel in ship.ShipPlacement)
            {
                panel.OccupationType = OccupationType.EMPTY;
            }
        }

        // place ship
        private static void PlaceShip(this Ship ship) 
        {
            foreach (Panel panel in ship.ShipPlacement)
            {
                panel.OccupationType = ship.OccupationType;
            }
        }
    }
}