using System;

namespace battleship
{
    class GameWithBot : GameType
    {
        public IPlayer Player;
        public IPlayer Bot;
        public GameWithBot()
        {
            System.Console.Write("Enter player's name: ");
            this.FirstPlayer = new Player(Console.ReadLine());  
            this.SecondPlayer = new Bot(); 
            this.Player = this.FirstPlayer;
            this.Bot = this.SecondPlayer;         
        }

        public override void PlaceShips()
        {
            System.Console.WriteLine("Do you want to place ships randomly?(y/n)");
            char answer = Console.ReadKey().KeyChar;
            System.Console.WriteLine(); // space
    
            if (answer == 'y')
            {
                // place ships randomly
                Player.RandomPlaceShip();
                Bot.RandomPlaceShip();   
            } else if (answer == 'n')
            {
                Player.PlayerPlaceShips();
                Bot.RandomPlaceShip();
            }
            
            // fill firing boards
            Player.FillFiringBoard(Bot);
            Bot.FillFiringBoard(Player);
        }

        public override void PlayRounds()
        {
            System.Console.WriteLine("Show first player's board");
            Extensions.PressEnter();
            Console.Clear();
            System.Console.WriteLine($"{Player.Name} board:");
            ShowsBoards.OutputGameBoard(Player.GameBoard);
            Extensions.PressEnter();
            Console.Clear();

            while (!Player.HasLost && !Bot.HasLost)
            {
                Round round = new Round(Player, Bot);

                round.PlayRound();

                Extensions.PressEnter();
                Console.Clear();
            }
        }
    }
}