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
                    try
                    {
                        Console.Clear();

                        Screen.printChessGame(chessGame);
                        
                        Console.WriteLine();
                        Console.Write("Orign: ");
                        Position orign = Screen.readChessPosition().toPosition();
                        chessGame.validateOrignPositon(orign);

                        bool[,] possiblePositions = chessGame.gameBoard.piece(orign).possibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(chessGame.gameBoard, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        chessGame.validateDestintyPosition(orign, destiny);

                        chessGame.executeAMove(orign, destiny);

                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.printChessGame(chessGame);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
