using System;

namespace battleship
{
    public static class Extensions
    {
        // find panel AT using some row and column 
        internal static Panel At(this List<Panel> board, int row, int column)
        {
            foreach (Panel panel in board)
            {
                if (panel.Coordinates.Row == row && panel.Coordinates.Column == column)
                {
                    return panel;
                }
            }
            throw new ArgumentNullException("Could not find panel");
        }

        // create list of panels of all ship
        internal static List<Panel> Range(this List<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels.Where(x => x.Coordinates.Row >= startRow && 
                                     x.Coordinates.Column >= startColumn &&
                                     x.Coordinates.Row <= endRow &&
                                     x.Coordinates.Column <= endColumn).ToList();
        }
        
        // check whether neighbors exist
        internal static bool HasNeighbors(this List<Panel> panels, List<Panel> board)
        {
            bool isNeighbor = false;
            foreach (Panel panel in panels)
            {
                int row = panel.Coordinates.Row;
                int column = panel.Coordinates.Column;

                // up
                if (row > 0)
                {
                    if(board.FindNeighbor(row - 1, column).IsOccupied)
                    {
                        isNeighbor = true;
                    }
                }
                // down
                if (row < IBoard.size - 1)
                {
                    if(board.FindNeighbor(row + 1, column).IsOccupied)
                    {
                        isNeighbor = true;
                    }
                }
                // right
                if (column < IBoard.size - 1)
                {
                    if(board.FindNeighbor(row, column + 1).IsOccupied)
                    {
                        isNeighbor = true;
                    }
                }
                // left
                if (column > 0)
                {
                    if(board.FindNeighbor(row, column - 1).IsOccupied)
                    {
                        isNeighbor = true;
                    }
                }
            }
            return isNeighbor;
        }

        private static Panel FindNeighbor(this List<Panel> board, int row, int column)
        {
            return board.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).ToList().First();
        }
    }
}