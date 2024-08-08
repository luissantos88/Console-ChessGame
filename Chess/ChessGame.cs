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
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public  ChessGame()
        {
            gameBoard = new GameBoard(8, 8);
            shitf = 1;
            atualPlayer = Colour.White;
            finish = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public void executeMovement(Position orign, Position destiny)
        {
            Piece p = gameBoard.removePiece(orign);
            p.incrementMovements();
            Piece capturePiece = gameBoard.removePiece(destiny);
            gameBoard.placePiece(p, destiny);
            if (capturePiece != null)
            {
                captured.Add(capturePiece);
            }
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

        public HashSet<Piece> capturedPieces(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.colour == colour)
                {
                aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.colour == colour)
                {
                    aux.Add(x);
                }
            }
            aux.Except(capturedPieces(colour));
            return aux;
        }

        public void placeNewPiece(char column, int line, Piece piece)
        {
            gameBoard.placePiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('c', 1, new Tower(gameBoard, Colour.White));
            placeNewPiece('c', 2, new Tower(gameBoard, Colour.White));
            placeNewPiece('d', 2, new Tower(gameBoard, Colour.White));
            placeNewPiece('e', 2, new Tower(gameBoard, Colour.White));
            placeNewPiece('e', 1, new Tower(gameBoard, Colour.White));
            placeNewPiece('d', 1, new King(gameBoard, Colour.White));

            placeNewPiece('c', 7, new Tower(gameBoard, Colour.Black));
            placeNewPiece('c', 8, new Tower(gameBoard, Colour.Black));
            placeNewPiece('d', 7, new Tower(gameBoard, Colour.Black));
            placeNewPiece('e', 7, new Tower(gameBoard, Colour.Black));
            placeNewPiece('e', 8, new Tower(gameBoard, Colour.Black));
            placeNewPiece('d', 8, new King(gameBoard, Colour.Black));
            
        }
    }
}
