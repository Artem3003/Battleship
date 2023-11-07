using System;

namespace battleship
{
    class GameWithPlayer : GameType
    {
        public GameWithPlayer()
        {
            System.Console.Write("Enter first player's name: ");
            this.FirstPlayer = new Player(Console.ReadLine());  

            System.Console.Write("Enter second player's name: ");
            this.SecondPlayer = new Player(Console.ReadLine());
        }

        public override void PlaceShips()
        {
            System.Console.WriteLine("Do you want to place ships randomly?(y/n)");
            char answer = Console.ReadKey().KeyChar;
            System.Console.WriteLine(); // space
    
            if (answer == 'y')
            {
                // place ships randomly
                FirstPlayer.RandomPlaceShip();
                SecondPlayer.RandomPlaceShip();   
            } else if (answer == 'n')
            {
                FirstPlayer.PlayerPlaceShips();
                SecondPlayer.PlayerPlaceShips();
            }
            
            // fill firing boards
            FirstPlayer.FillFiringBoard(SecondPlayer);
            SecondPlayer.FillFiringBoard(FirstPlayer);
        }

        public override void PlayRounds()
        {
            System.Console.WriteLine("Show first player's board");
            Extensions.PressEnter();
            Console.Clear();
            System.Console.WriteLine($"{FirstPlayer.Name} board:");
            ShowsBoards.OutputGameBoard(FirstPlayer.GameBoard);
            Extensions.PressEnter();
            Console.Clear();

            System.Console.WriteLine("Show second player's board");
            Extensions.PressEnter();
            Console.Clear();
            System.Console.WriteLine($"{SecondPlayer.Name} board:");
            ShowsBoards.OutputGameBoard(SecondPlayer.GameBoard);

            Extensions.PressEnter();
            Console.Clear();

            while (!FirstPlayer.HasLost && !SecondPlayer.HasLost)
            {
                Round round = new Round(FirstPlayer, SecondPlayer);

                round.PlayRound();

                Extensions.PressEnter();
                Console.Clear();
            }
        }
    }
}