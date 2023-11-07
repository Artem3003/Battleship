using System;
using System.Linq;

namespace battleship
{
    class Round : IDisposable
    {
        bool disposed = false; // Flag: Has Dipose already been called
        private IPlayer firstPlayer;
        private IPlayer secondPlayer;
        private ShotCoordinates shotCoordinates;

        public Round(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void PlayRound()
        {
            shotCoordinates = Shoot(firstPlayer);
            ProcessShot(shotCoordinates, firstPlayer, secondPlayer);

            Extensions.PressEnter();
            Console.Clear();
            Dispose();

            if (!firstPlayer.HasLost)
            {
                shotCoordinates = Shoot(secondPlayer);
                ProcessShot(shotCoordinates, secondPlayer, firstPlayer);
                Dispose();
            }
        }

        private ShotCoordinates Shoot(IPlayer player)
        {
            ShotCoordinates shotCoordinates;
            if (player is Player)
            {
                System.Console.WriteLine($"{player.Name} shoots");
                ShowsBoards.OutputFiringBoard(player.FiringBoard);

                try
                {
                    System.Console.WriteLine("Enter coordinates of row(A-J):");
                    char row = Console.ReadKey().KeyChar;
                    row = char.ToUpper(row);
                    System.Console.WriteLine(); // space

                    System.Console.WriteLine("Enter coordinates of column(1-10):");
                    int column = Convert.ToInt32(Console.ReadLine());
                    System.Console.WriteLine(); // space

                    shotCoordinates = new ShotCoordinates(row, column);
                    return shotCoordinates;
                }
                catch (System.ArgumentNullException)
                {
                    UserInputException exception = new UserInputException("You should write coordinates row(A-J) and column(1-10)");
                    System.Console.WriteLine(exception.Message);
                    Shoot(player);
                }
                catch (System.FormatException)
                {
                    UserInputException exception = new UserInputException("You should write coordinate. Please don't leave fields empty");
                    System.Console.WriteLine(exception.Message);
                    Shoot(player);
                }
            }
            if (player is Bot)
            {
                System.Console.WriteLine("Bot shoots");
                shotCoordinates = new ShotCoordinates();
                Panel panel = player.FiringBoard.Board.At(shotCoordinates.Row, shotCoordinates.Column);
                System.Console.WriteLine($"{panel.OccupationType}");
                System.Console.WriteLine($"Bot fired");
                return shotCoordinates;
            }
            throw new Exception();
        }

        private void ProcessShot(ShotCoordinates shotCoordinates, IPlayer player, IPlayer secondPlayer)
        {
            Panel panel = player.FiringBoard.Board.At(shotCoordinates.Row, shotCoordinates.Column);
            if (panel.OccupationType == OccupationType.EMPTY) // If player missed
            {
                Console.Clear();
                panel.OccupationType = OccupationType.MISS;
                System.Console.WriteLine($"'Miss'");
                ShowsBoards.OutputFiringBoard(player.FiringBoard);
            } else if (panel.OccupationType == OccupationType.MISS || panel.OccupationType == OccupationType.HIT) // if player hit what he has already hit
            {
                Console.Clear();
                System.Console.WriteLine($"'You have already hit it'");
                ProcessShot(Shoot(player), player, secondPlayer);
            } else // if player hit some ship
            {
                Console.Clear();
                Ship ship = secondPlayer.Ships.First(sh => sh.ShipPlacement.Contains(player.FiringBoard.Board.At(shotCoordinates.Row, shotCoordinates.Column)) && sh.IsSunk == false);
                ship.Hits++;
                panel.OccupationType = OccupationType.HIT;
                if (ship.IsSunk) // check whether ship is sunk
                {
                    ship.ShipPlacement.RemoveNeighbors(player.FiringBoard.Board);
                    System.Console.WriteLine(ship.SunkMessage());;
                } else
                {
                    System.Console.WriteLine($"'Hit'");
                }
                ProcessShot(Shoot(player), player, secondPlayer);
            }
        }

        // Public implementaiton of Dispose pattern callable by consumers
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
            GC.Collect(0);
        }

        // Protected implementation of Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
                
            if (disposing)
            {
                shotCoordinates = null;
            }
            // free any unmanaged object here

            disposed = true;
        }

        // Distructor
        ~Round()
        {
            Dispose(disposing: false);
        }
    }
}