using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        static char[][] board;

        static void Main(string[] args)
        {
            board = new char[8][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                char figureType = command[0];
                int startingRow = int.Parse(command[1].ToString());
                int startingCol = int.Parse(command[2].ToString());
                int desiredRow = int.Parse(command[4].ToString());
                int desiredCol = int.Parse(command[5].ToString());

                if (!FigureExist(figureType, startingRow, startingCol))
                {
                    Console.WriteLine("There is no such a piece!");
                    continue;
                }
                if (!IsMoveValid(figureType, startingRow, startingCol, desiredRow, desiredCol))
                {
                    Console.WriteLine("Invalid move!");
                    continue;
                }
                if (!OutOfBoard(desiredRow, desiredCol))
                {
                    Console.WriteLine("Move go out of board!");
                    continue;
                }

                board[desiredRow][desiredCol] = figureType;
                board[startingRow][startingCol] = 'x';
            }
        }

        private static bool OutOfBoard(int row, int col)
        {
            bool validRow = row >= 0 && row <= 7;
            bool validCol = col >= 0 && col <= 7;

            return validRow && validCol;
        }

        private static bool IsMoveValid(char figureType, int startingRow, int startingCol, int desiredRow, int desiredCol)
        {
            switch (figureType)
            {
                case 'P':
                    return ValidPawnMove(startingRow, startingCol, desiredRow, desiredCol);
                case 'R':
                    return ValidStraightMove(startingRow, startingCol, desiredRow, desiredCol);
                case 'B':
                    return ValidDiagonalMove(startingRow, startingCol, desiredRow, desiredCol);
                case 'Q':
                    return ValidStraightMove(startingRow, startingCol, desiredRow, desiredCol) ||
                        ValidDiagonalMove(startingRow, startingCol, desiredRow, desiredCol);
                case 'K':
                    return ValidKingMove(startingRow, startingCol, desiredRow, desiredCol);
                default:
                    throw new Exception();
            }
        }

        private static bool ValidKingMove(int startingRow, int startingCol, int desiredRow, int desiredCol)
        {
            bool rowMove = Math.Abs(startingRow - desiredRow) == 1 &&
                Math.Abs(startingCol - desiredCol) == 0;
            bool colMove = Math.Abs(startingCol - desiredCol) == 1 &&
                Math.Abs(startingRow - desiredRow) == 0;
            bool diagonalMove = Math.Abs(startingRow - desiredRow) == 1 &&
                Math.Abs(startingCol - desiredCol) == 1;

            return rowMove || colMove || diagonalMove;
        }

        private static bool ValidDiagonalMove(int startingRow, int startingCol, int desiredRow, int desiredCol)
        {
            return Math.Abs(startingRow - desiredRow) == Math.Abs(startingCol - desiredCol);
        }

        private static bool ValidStraightMove(int startingRow, int startingCol, int desiredRow, int desiredCol)
        {
            bool sameRow = startingRow == desiredRow;
            bool sameCol = startingCol == desiredCol;

            return sameRow || sameCol;
        }

        private static bool ValidPawnMove(int startingRow, int startingCol, int desiredRow, int desiredCol)
        {
            bool validColumn = startingCol == desiredCol;
            bool validRow = startingRow - 1 == desiredRow;

            return validColumn && validRow;
        }

        private static bool FigureExist(char figureType, int row, int col)
        {
            return board[row][col] == figureType;
        }
    }
}
