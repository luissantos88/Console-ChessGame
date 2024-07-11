
using Board;
using Xadrez_console;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Game_Board board = new Game_Board(8, 8);

            Screen.PrintBoard(board);

        }
    }
}
