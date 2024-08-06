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
        public int shitf { get; private set; }
        public Colour atualPlayer { get; private set; }
        public bool finish {  get; private set; }

        public  ChessGame()
        {
            gameBoard = new GameBoard(8, 8);
            shitf = 1;
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

        public void executeAMove(Position orign, Position destiny)
        {
            executeMovement(orign, destiny);
            shitf++;
            changePlayer();

        }

        public void validateOrignPositon(Position pos)
        {
            if (gameBoard.piece(pos) == null)
            {
                throw new BoardException("There is no piece to play in orgin positon!!!");
            }

            if (atualPlayer != gameBoard.piece(pos).colour)
            {
                throw new BoardException("This piece is not yours to play!!!");
            }

            if (!gameBoard.piece(pos).existsPossibleMovements())
            {
                throw new BoardException("There are no possible moves for the orign piece");
            }
        }

        public void validateDestintyPosition(Position orign, Position destiy)
        {
            if (!gameBoard.piece(orign).canMoveTo(destiy))
            {
                throw new BoardException("Destiny position is invalid!!!");
            }
        }

        public void changePlayer()
        {
            if (atualPlayer == Colour.White)
            {
                atualPlayer = Colour.Black;
            }
            else
            {
                atualPlayer = Colour.White;
            }                
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
