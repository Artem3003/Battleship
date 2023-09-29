using System;

namespace battleship
{
    class GameBoard : IBoard
    {
        public List<Panel> Board { get; set; }
        public GameBoard()
        {
            Board = new List<Panel>();
            for (int i = 0; i < IBoard.size; i++)
            {
                for (int j = 0; j < IBoard.size; j++)
                {
                    Board.Add(new Panel(i, j));
                }
            }
        }
    }
}