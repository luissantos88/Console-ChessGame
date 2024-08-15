using Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class ChessGame
    {
        public GameBoard gameBoard { get; private set; }
        public int shitf { get; private set; }
        public Colour atualPlayer { get; private set; }
        public bool finish { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessGame()
        {
            gameBoard = new GameBoard(8, 8);
            shitf = 1;
            atualPlayer = Colour.White;
            finish = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece executeMovement(Position orign, Position destiny)
        {
            Piece p = gameBoard.removePiece(orign);
            p.incrementMovements();
            Piece capturePiece = gameBoard.removePiece(destiny);
            gameBoard.placePiece(p, destiny);
            if (capturePiece != null)
            {
                captured.Add(capturePiece);
            }
            return capturePiece;
        }

        public void cancelMovement(Position orign, Position destiny, Piece capturedPiece)
        {
            Piece p = gameBoard.removePiece(destiny);
            p.decreaseMovements();
            if (capturedPiece != null)
            {
                gameBoard.placePiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            gameBoard.placePiece(p, orign);
        }
        public void executeAMove(Position orign, Position destiny)
        {
            Piece capturedPiece = executeMovement(orign, destiny);

            if (isInCheck(atualPlayer))
            {
                cancelMovement(orign, destiny, capturedPiece);
                throw new BoardException("You can´t put yourself in check!!!");
            }

            if (isInCheck(adversary(atualPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckMate(adversary(atualPlayer)))
            {
                finish = true;
            }
            else
            {
                shitf++;
                changePlayer();
            }
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
            foreach (Piece x in pieces)
            {
                if (x.colour == colour)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(colour));
            return aux;
        }

        private Colour adversary(Colour colour)
        {
            if (colour == Colour.White)
            {
                return Colour.Black;
            }
            else
            {
                return Colour.White;
            }
        }

        private Piece king(Colour colour)
        {
            foreach (Piece x in piecesInGame(colour))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool isInCheck(Colour colour)
        {
            Piece K = king(colour);
            if (K == null)
            {
                throw new BoardException("There is no king " + colour + " in the board");
            }
            foreach (Piece x in piecesInGame(adversary(colour)))
            {
                bool[,] mat = x.possibleMovements();
                if (mat[K.position.line, K.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Colour colour)
        {
            if (!isInCheck(colour))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(colour))
            {
                bool[,] mat = x.possibleMovements();
                for (int i = 0; i < gameBoard.lines; i++)
                {
                    for (int j = 0; j < gameBoard.columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position orign = x.position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = executeMovement(orign, destiny);
                            bool testCheck = isInCheck(colour);
                            cancelMovement(orign, destiny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void placeNewPiece(char column, int line, Piece piece)
        {
            gameBoard.placePiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('d', 1, new King(gameBoard, Colour.White));
            placeNewPiece('c', 1, new Tower(gameBoard, Colour.White));
            placeNewPiece('h', 7, new Tower(gameBoard, Colour.White));

            placeNewPiece('b', 8, new Tower(gameBoard, Colour.Black));
            placeNewPiece('a', 8, new King(gameBoard, Colour.Black));          
        }
    }
}
