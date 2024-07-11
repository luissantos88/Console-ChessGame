using Board;
using Xadrez_console;
using Chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                GameBoard gameBoard = new GameBoard(8, 8);

                gameBoard.placePart(new Tower(gameBoard, Colour.Black), new Position(0, 0));
                gameBoard.placePart(new Tower(gameBoard, Colour.Black), new Position(1, 3));
                gameBoard.placePart(new King(gameBoard, Colour.Black), new Position(0, 9));

                Screen.PrintBoard(gameBoard);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
