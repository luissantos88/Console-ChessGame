

using Board;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintBoard(GameBoard gameBoard)
        {

            for (int i = 0; i < gameBoard.lines; i++)
            {
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    if (gameBoard.part(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(gameBoard.part(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
