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
                ChessGame chessGame = new ChessGame();

                while (!chessGame.finish)
                {

                    Console.Clear();
                    Screen.PrintBoard(chessGame.gameBoard);

                    Console.WriteLine();
                    Console.Write("Orign: ");
                    Position orign = Screen.readChessPosition().toPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readChessPosition().toPosition();

                    chessGame.executeMovement(orign, destiny);

                }
            
                Screen.PrintBoard(chessGame.gameBoard);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
