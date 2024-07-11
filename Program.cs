using Board;
using Xadrez_console;
using Chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Game_Board game_Board = new Game_Board(8, 8);

            game_Board.placePart(new Tower(game_Board, Colour.Black), new Position(0, 0));
            game_Board.placePart(new Tower(game_Board, Colour.Black), new Position(1, 3));
            game_Board.placePart(new King(game_Board, Colour.Black), new Position(2, 4));

            Screen.PrintBoard(game_Board);

        }
    }
}
