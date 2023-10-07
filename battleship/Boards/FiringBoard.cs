using System;

namespace battleship
{
    class FiringBoard : IBoard
    {
        public List<Panel> Board { get; set; }

        public FiringBoard()
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