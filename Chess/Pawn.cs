using Board;
using Chess;

namespace xadrez
{

    class Pawn : Piece
    {
        private ChessGame chessGame;

        public Pawn(GameBoard gameBoard, Colour colour, ChessGame chessGame) : base(gameBoard, colour)
        {
            this.chessGame = chessGame;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool thereIsEnemy(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p != null && p.colour != colour;
        }

        private bool free(Position pos)
        {
            return gameBoard.piece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[gameBoard.lines, gameBoard.columns];

            Position pos = new Position(0, 0);

            if (colour == Colour.White)
            {
                pos.defineValors(position.line - 1, position.column);
                if (gameBoard.positionIsValid(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (gameBoard.positionIsValid(p2) && free(p2) && gameBoard.positionIsValid(pos) && free(pos) && qtdMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 1, position.column - 1);
                if (gameBoard.positionIsValid(pos) && thereIsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 1, position.column + 1);
                if (gameBoard.positionIsValid(pos) && thereIsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                // #specialMove en passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (gameBoard.positionIsValid(left) && thereIsEnemy(left) && gameBoard.piece(left) == chessGame.openToEnPassant)
                    {
                        mat[left.line - 1, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (gameBoard.positionIsValid(right) && thereIsEnemy(right) && gameBoard.piece(right) == chessGame.openToEnPassant)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
                }
            }
            else
            {
                pos.defineValors(position.line + 1, position.column);
                if (gameBoard.positionIsValid(pos) && free(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (gameBoard.positionIsValid(p2) && free(p2) && gameBoard.positionIsValid(pos) && free(pos) && qtdMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 1, position.column - 1);
                if (gameBoard.positionIsValid(pos) && thereIsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 1, position.column + 1);
                if (gameBoard.positionIsValid(pos) && thereIsEnemy(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                // #specialMove en passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (gameBoard.positionIsValid(left) && thereIsEnemy(left) && gameBoard.piece(left) == chessGame.openToEnPassant)
                    {
                        mat[left.line + 1, left.column] = true;
                    }

                    Position right = new Position(position.line, position.column + 1);
                    if (gameBoard.positionIsValid(right) && thereIsEnemy(right) && gameBoard.piece(right) == chessGame.openToEnPassant)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
                }
            }
            return mat;
        }
    }
}