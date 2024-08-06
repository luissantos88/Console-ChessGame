using Board;

namespace Chess
{
    class Tower : Piece
    {
        public Tower(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }
        public override string ToString()
        {
            return "T";
        }

        private bool canMoveTower(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p == null || p.colour != colour;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[gameBoard.lines, gameBoard.columns];

            Position pos = new Position(0, 0);

            // up
            pos.defineValors(position.line - 1, position.column);
            while (gameBoard.positionIsValid(pos) && canMoveTower(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }
            // down
            pos.defineValors(position.line + 1, position.column);
            while (gameBoard.positionIsValid(pos) && canMoveTower(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            // right
            pos.defineValors(position.line, position.column + 1);
            while (gameBoard.positionIsValid(pos) && canMoveTower(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }
            // left
            pos.defineValors(position.line, position.column - 1);
            while (gameBoard.positionIsValid(pos) && canMoveTower(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            return mat;
        }
    }
}