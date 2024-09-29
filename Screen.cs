using Board;
using Chess;

namespace Xadrez_console
{
    class Screen
    {
        public static void printChessGame(ChessGame chessGame)
        {
            PrintBoard(chessGame.gameBoard);
            Console.WriteLine();
            printCapturedPieces(chessGame);
            Console.WriteLine();
            Console.WriteLine("Move: " + chessGame.shitf);
            if (!chessGame.finish)
            {
                Console.WriteLine("Waiting move from: " + chessGame.atualPlayer);
                if (chessGame.check)
                {
                    Console.WriteLine("CHECK!!!!!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!!!!!");
                Console.WriteLine("The winner is : " + chessGame.atualPlayer);
            }                     
        }
        public static void printCapturedPieces(ChessGame chessGame)
        {
            Console.WriteLine("Captured Pieces: ");
            Console.Write("White: ");
            printSetPieces(chessGame.capturedPieces(Colour.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSetPieces(chessGame.capturedPieces(Colour.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void printSetPieces(HashSet<Piece> setPieces)
        {
            Console.Write("[");
            foreach (Piece x in setPieces)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(GameBoard gameBoard)
        {

            for (int i = 0; i < gameBoard.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    printPiece(gameBoard.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(GameBoard gameBoard, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < gameBoard.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(gameBoard.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }
        public static ChessPosition readChessPosition()
        {
            var s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }
        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.colour == Colour.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
