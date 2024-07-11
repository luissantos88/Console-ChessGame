

using Board;

namespace Xadrez_console
{
    class Screen
    {
        public static void PrintBoard(Game_Board game_Board)
        {

            for (int i = 0; i < game_Board.lines; i++)
            {
                for (int j = 0; j < game_Board.columns; j++)
                {
                    if (game_Board.part(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(game_Board.part(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
