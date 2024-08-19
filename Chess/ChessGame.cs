using Board;
using System.ComponentModel;
using xadrez;
using Xadrez_console.Chess;

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
        public Piece openToEnPassant { get; private set; }

        public ChessGame()
        {
            gameBoard = new GameBoard(8, 8);
            shitf = 1;
            atualPlayer = Colour.White;
            finish = false;
            check = false;
            openToEnPassant = null;
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

            // #specialMove small castling
            if (p is King && destiny.column == orign.column + 2)
            {
                Position towerOrign = new Position(orign.line, orign.column + 3);
                Position towerDestiny = new Position(orign.line, orign.column + 1);
                Piece T = gameBoard.removePiece(towerOrign);
                T.incrementMovements();
                gameBoard.placePiece(T, towerDestiny);
            }

            // #specialMove big castling
            if (p is King && destiny.column == orign.column - 2)
            {
                Position towerOrign = new Position(orign.line, orign.column - 4);
                Position towerDestiny = new Position(orign.line, orign.column - 1);
                Piece T = gameBoard.removePiece(towerOrign);
                T.incrementMovements();
                gameBoard.placePiece(T, towerDestiny);
            }

            // #specialMove en passant
            if (p is Pawn)
            {
                if (orign.column != destiny.column && capturePiece == null)
                {
                    Position pawnAdversaryPos;
                    {
                        if (p.colour == Colour.White)
                        {
                            pawnAdversaryPos = new Position(destiny.line + 1, destiny.column);
                        }
                        else
                        {
                            pawnAdversaryPos = new Position(destiny.line - 1, destiny.column);
                        }

                        capturePiece = gameBoard.removePiece(pawnAdversaryPos);
                        captured.Add(capturePiece); 
                    }
                }
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

            // #specialMove small castling
            if (p is King && destiny.column == orign.column + 2)
            {
                Position towerOrign = new Position(orign.line, orign.column + 3);
                Position towerDestiny = new Position(orign.line, orign.column + 1);
                Piece T = gameBoard.removePiece(towerOrign);
                T.decreaseMovements();
                gameBoard.placePiece(T, towerOrign);
            }
            // #specialMove big castling
            if (p is King && destiny.column == orign.column - 2)
            {
                Position towerOrign = new Position(orign.line, orign.column - 4);
                Position towerDestiny = new Position(orign.line, orign.column - 1);
                Piece T = gameBoard.removePiece(towerOrign);
                T.decreaseMovements();
                gameBoard.placePiece(T, towerOrign);
            }

            // #specialMove en passant
            if (p is Pawn)
            {
                if (orign.column != destiny.column && capturedPiece == openToEnPassant)
                {
                    Piece pawn = gameBoard.removePiece(destiny);
                    Position pawnPosition;
                    if(p.colour == Colour.White)
                    {
                        pawnPosition = new Position(3, destiny.column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, destiny.column);
                    }
                    gameBoard.placePiece(pawn, pawnPosition);
                }
            }
        }
        public void executeAMove(Position orign, Position destiny)
        {
            Piece capturedPiece = executeMovement(orign, destiny);

            if (isInCheck(atualPlayer))
            {
                cancelMovement(orign, destiny, capturedPiece);
                throw new BoardException("You can´t put yourself in check!!!");
            }

            Piece p = gameBoard.piece(destiny);

            // #specialMove promotion
            if (p is Pawn)
            {
                if (p.colour == Colour.White && destiny.line == 0 || p.colour == Colour.Black && destiny.line == 7)
                {
                    p = gameBoard.removePiece(destiny);
                    pieces.Remove(p);
                    Piece queen = new Queen(gameBoard, p.colour);
                    gameBoard.placePiece(queen, destiny);
                    pieces.Add(queen);
                }
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
          
            // #specialMove en passant
            if (p is Pawn && (destiny.line == orign.line - 2 || destiny.line == orign.line + 2))
            {
                openToEnPassant = p;
            }
            else
            {
                openToEnPassant = null;
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
            if (!gameBoard.piece(orign).possibleMovement(destiy))
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
            //White
            placeNewPiece('a', 1, new Tower(gameBoard, Colour.White));
            placeNewPiece('b', 1, new Horse(gameBoard, Colour.White));
            placeNewPiece('c', 1, new Bishop(gameBoard, Colour.White));
            placeNewPiece('d', 1, new Queen(gameBoard, Colour.White));
            placeNewPiece('e', 1, new King(gameBoard, Colour.White, this));
            placeNewPiece('f', 1, new Bishop(gameBoard, Colour.White));
            placeNewPiece('g', 1, new Horse(gameBoard, Colour.White));
            placeNewPiece('h', 1, new Tower(gameBoard, Colour.White));
            placeNewPiece('a', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('b', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('c', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('d', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('e', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('f', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('g', 2, new Pawn(gameBoard, Colour.White, this));
            placeNewPiece('h', 2, new Pawn(gameBoard, Colour.White, this));

            //Black
            placeNewPiece('a', 8, new Tower(gameBoard, Colour.Black));
            placeNewPiece('b', 8, new Horse(gameBoard, Colour.Black));
            placeNewPiece('c', 8, new Bishop(gameBoard, Colour.Black));
            placeNewPiece('d', 8, new Queen(gameBoard, Colour.Black));
            placeNewPiece('e', 8, new King(gameBoard, Colour.Black, this));
            placeNewPiece('f', 8, new Bishop(gameBoard, Colour.Black));
            placeNewPiece('g', 8, new Horse(gameBoard, Colour.Black));
            placeNewPiece('h', 8, new Tower(gameBoard, Colour.Black));
            placeNewPiece('a', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('b', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('c', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('d', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('e', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('f', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('g', 7, new Pawn(gameBoard, Colour.Black, this));
            placeNewPiece('h', 7, new Pawn(gameBoard, Colour.Black, this));

        }
    }
}
