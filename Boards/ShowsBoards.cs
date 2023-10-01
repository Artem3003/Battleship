using System.Runtime.CompilerServices;
using System;

namespace battleship 
{
    static class ShowsBoards
    {
        public static void OutputGameBoard(IBoard gameBoard)
        {
            int counterLetters = 0;
            // write number above field 
            for (int j = 1; j <= 10; j++)
            {
                System.Console.Write(j + " ");
            }
            System.Console.WriteLine();
            for (int i = 1; i <= IBoard.size * IBoard.size; i++)
            {
                gameBoard.PaintPanel(i - 1, "0", ConsoleColor.Blue);
                gameBoard.PaintPanel(i - 1, "M", ConsoleColor.DarkBlue);
                gameBoard.PaintPanel(i - 1, "X", ConsoleColor.DarkRed);
                gameBoard.PaintPanel(i - 1, "B", ConsoleColor.DarkGreen);
                gameBoard.PaintPanel(i - 1, "D", ConsoleColor.DarkGreen);
                gameBoard.PaintPanel(i - 1, "C", ConsoleColor.DarkGreen);
                gameBoard.PaintPanel(i - 1, "S", ConsoleColor.DarkGreen);
                if (i % 10 == 0) // wrap line
                {
                    System.Console.Write(" " + ((char)(64 + ++counterLetters)).ToString()); // write letters right way of field
                    System.Console.WriteLine(); // space
                }
            }
        }

        public static void OutputFiringBoard(IBoard gameBoard)
        {
            int counterLetters = 0;
            // write number above field 
            for (int j = 1; j <= 10; j++)
            {
                System.Console.Write(j + " ");
            }
            System.Console.WriteLine();
            for (int i = 1; i <= IBoard.size * IBoard.size; i++)
            {
                gameBoard.PaintPanel(i - 1, "0", ConsoleColor.Blue);
                gameBoard.PaintPanel(i - 1, "M", ConsoleColor.DarkBlue);
                gameBoard.PaintPanel(i - 1, "X", ConsoleColor.DarkRed);
                gameBoard.PaintPanel(i - 1, "B", ConsoleColor.Blue);
                gameBoard.PaintPanel(i - 1, "D", ConsoleColor.Blue);
                gameBoard.PaintPanel(i - 1, "C", ConsoleColor.Blue);
                gameBoard.PaintPanel(i - 1, "S", ConsoleColor.Blue);
                if (i % 10 == 0) // wrap line
                {
                    System.Console.Write(" " + ((char)(64 + ++counterLetters)).ToString()); // write letters right way of field
                    System.Console.WriteLine(); // space
                }
            }
        }

        private static void PaintPanel(this IBoard board, int planeNumber, string status, ConsoleColor color)
        {
            if(board.Board[planeNumber].Status == status)
            {
                Console.BackgroundColor = color;
                System.Console.Write("~" + " ");
                Console.ResetColor();
            }
        }
    }
}