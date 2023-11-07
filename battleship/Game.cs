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

                        Console.Clear();
                        // create two players
                        System.Console.Write("Enter first players name: ");
                        string ?firstPlayerName = Console.ReadLine();
                        Player firstPlayer = new Player(firstPlayerName);

                        System.Console.Write("Enter second players name: ");
                        string ?secondPlayerName = Console.ReadLine();
                        Player secondPlayer = new Player(secondPlayerName);

                        // place ships
                        firstPlayer.PlaceShip();
                        secondPlayer.PlaceShip();

                        // fill firing boards
                        firstPlayer.FillFiringBoard(secondPlayer);
                        secondPlayer.FillFiringBoard(firstPlayer);

                        System.Console.WriteLine("Show first player's board");
                        Extensions.PressEnter();
                        Console.Clear();
                        System.Console.WriteLine($"{firstPlayer.Name} board:");
                        ShowsBoards.OutputGameBoard(firstPlayer.GameBoard);

                        System.Console.WriteLine("Show second player's board");
                        Extensions.PressEnter();
                        Console.Clear();
                        System.Console.WriteLine($"{secondPlayer.Name} board:");
                        ShowsBoards.OutputGameBoard(secondPlayer.GameBoard);

                        Extensions.PressEnter();
                        Console.Clear();



                        while (!firstPlayer.HasLost && !secondPlayer.HasLost)
                        {
                            Round round = new Round(firstPlayer, secondPlayer);
                            round.PlayRound();


                            Extensions.PressEnter();
                            Console.Clear();
                        }

                        ShowsBoards.OutputGameBoard(firstPlayer.GameBoard);
                        ShowsBoards.OutputGameBoard(secondPlayer.GameBoard);

                        if (firstPlayer.HasLost)
                        {
                            System.Console.WriteLine($"{secondPlayer.Name} is winner!!! Congratulations!!!");
                        } else
                        {
                            System.Console.WriteLine($"{firstPlayer.Name} is winner!!! Congratulations!!!");
                        }
                    }
                }
            }
            return _instance;
        }
    }
}