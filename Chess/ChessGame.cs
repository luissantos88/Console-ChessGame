using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessGame
    {
        public GameBoard gameBoard {  get; private set; }
        private int shift;
        private Colour atualPlayer;
        public bool finish {  get; private set; }

        public  ChessGame()
        {
            gameBoard = new GameBoard(8, 8);
            shift = 1;
            atualPlayer = Colour.White;
            finish = false;
            placePieces();
        }

        public void executeMovement(Position orign, Position destiny)
        {
            Piece p = gameBoard.removePiece(orign);
            p.incrementMovements();
            Piece capturePiece = gameBoard.removePiece(destiny);
            gameBoard.placePiece(p, destiny);
        }

        private void placePieces()
        {
            gameBoard.placePiece(new Tower(gameBoard, Colour.White), new ChessPosition('c', 1).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.White), new ChessPosition('c', 2).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.White), new ChessPosition('d', 2).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.White), new ChessPosition('e', 2).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.White), new ChessPosition('e', 1).toPosition());
            gameBoard.placePiece(new King(gameBoard, Colour.White), new ChessPosition('d', 1).toPosition());

            gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new ChessPosition('c', 7).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new ChessPosition('c', 8).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new ChessPosition('d', 7).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new ChessPosition('e', 7).toPosition());
            gameBoard.placePiece(new Tower(gameBoard, Colour.Black), new ChessPosition('e', 8).toPosition());
            gameBoard.placePiece(new King(gameBoard, Colour.Black), new ChessPosition('d', 8).toPosition());
        }
    }
}
