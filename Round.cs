using System;

namespace battleship
{
    class Round
    {
        private Player firstPlayer;
        private Player secondPlayer;

        public Round(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public void PlayRound()
        {
            ShotCoordinates shotCoordinates = Shoot(firstPlayer);
            ProcessShot(shotCoordinates, firstPlayer);

            Extensions.PressEnter();
            Console.Clear();

            if (!firstPlayer.HasLost)
            {
                shotCoordinates = Shoot(secondPlayer);
                ProcessShot(shotCoordinates, secondPlayer);
            }
        }

        private ShotCoordinates Shoot(Player player)
        {
            ShotCoordinates shotCoordinates;
            System.Console.WriteLine($"{player.Name} shoots");
            ShowsBoards.OutputFiringBoard(player.FiringBoard);

            System.Console.WriteLine("Enter coordinates of row(A-J):");
            char row = Console.ReadKey().KeyChar;
            row = char.ToUpper(row);
            System.Console.WriteLine(); // space

            System.Console.WriteLine("Enter coordinates of column(1-10):");
            int column = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine(); // space

            return shotCoordinates = new ShotCoordinates(row, column);
        }

        private void ProcessShot(ShotCoordinates shotCoordinates, Player player)
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
                ProcessShot(Shoot(player), player);
            } else // if player hit some ship
            {
                Console.Clear();
                Ship ship = player.Ships.First(x => x.OccupationType == panel.OccupationType && x.IsSunk == false);
                ship.Hits++;
                panel.OccupationType = OccupationType.HIT;
                if (ship.IsSunk) // check whether ship is sunk
                {
                    System.Console.WriteLine($"'{ship.Name} is sunk'");
                } else
                {
                    System.Console.WriteLine($"'Hit'");
                }
                ProcessShot(Shoot(player), player);
            }
        }
    }
}