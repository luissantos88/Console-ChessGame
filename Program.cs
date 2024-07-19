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

                gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new Position(0, 0));
                gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new Position(1, 3));
                gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new Position(0, 2));

                gameBoard.placePiece(new Tower(gameBoard, Colour.White), new Position(3, 5));

                Screen.PrintBoard(gameBoard);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
