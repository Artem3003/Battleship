using System;

namespace battleship
{
    sealed class Game // sealed - are not able to inherit from that service
    {
        private Game() {}

        private static readonly object _lock = new object();
 
        private static Game _instance;

        public static Game CreateGame()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Game();
                        System.Console.WriteLine("Welcome to Battleship!");
                        PlayGame();
                    }
                }
            }
            return _instance;
        }

        private static void PlayGame()
        {
            GameWithPlayer gameWithPlayer;
            GameWithBot gameWithBot;
            System.Console.WriteLine("What do you choose play with player or with bot?");
            string answer = Console.ReadLine();
            if (answer == "player")
            {
                answer.Trim();
                Console.Clear();
                gameWithPlayer = new GameWithPlayer();
                gameWithPlayer.PlaceShips();
                gameWithPlayer.PlayRounds();
                gameWithPlayer.GameConclution();
            } else if (answer == "bot")
            {
                answer.Trim();
                Console.Clear();
                gameWithBot = new GameWithBot();
                gameWithBot.PlaceShips();
                gameWithBot.PlayRounds();
                gameWithBot.GameConclution();
            } else
            {
                PlayGame();
            }
        }
    }
}