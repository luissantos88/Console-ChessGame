using Board;

namespace Chess
{
    class King : Piece
    {

        private ChessGame chessGame;

        public King(GameBoard gameBoard, Colour colour, ChessGame chessGame) : base(gameBoard, colour)
        {
            this.chessGame = chessGame;
        }        
        public override string ToString()
        {
            return "K";
        }
        private bool canMove(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p == null || p.colour != colour;
        }

        private bool checkTowerForCastling (Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p != null && p is Tower && p.colour == colour && p.qtdMovements == 0; 
        }
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[gameBoard.lines, gameBoard.columns];

            Position pos = new Position(0, 0);

            // up
            pos.defineValors(position.line - 1, position.column);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
                {
                mat[pos.line, pos.column] = true;
            }
            // ne
            pos.defineValors(position.line - 1, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // right
            pos.defineValors(position.line, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // se
            pos.defineValors(position.line + 1, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // down
            pos.defineValors(position.line + 1, position.column);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // so
            pos.defineValors(position.line + 1, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // left
            pos.defineValors(position.line, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // no
            pos.defineValors(position.line - 1, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            // #specialMove castling
            if(qtdMovements == 0 &&  !chessGame.check)
            {
                // #specialMove small castling
                Position posT1 = new Position(position.line, position.column + 3);
                if (checkTowerForCastling(posT1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (gameBoard.piece(p1) == null & gameBoard.piece(p2) == null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
                // #specialMove big castling
                Position posT2 = new Position(position.line, position.column - 4);
                if (checkTowerForCastling(posT2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (gameBoard.piece(p1) == null & gameBoard.piece(p2) == null && gameBoard.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }
            return mat;
        }
    }
}
