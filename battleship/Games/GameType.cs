using System;

namespace battleship
{
    abstract class GameType
    {
        public IPlayer FirstPlayer;
        public IPlayer SecondPlayer;
        
        abstract public void PlaceShips();
        abstract public void PlayRounds();

        public void GameConclution()
        {
            ShowsBoards.OutputGameBoard(FirstPlayer.GameBoard);
            ShowsBoards.OutputGameBoard(SecondPlayer.GameBoard);

            if (FirstPlayer.HasLost)
            {
                System.Console.WriteLine($"{SecondPlayer.Name} is winner!!! Congratulations!!!");
            } else
            {
                System.Console.WriteLine($"{FirstPlayer.Name} is winner!!! Congratulations!!!");
            }
        }
    }
}