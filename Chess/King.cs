using Board;

namespace Chess
{
    class King : Piece
    {
        public King(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }        
        public override string ToString()
        {
            return "R";
        }
        private bool canMoveKing(Position pos)
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
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
                {
                mat[pos.line, pos.column] = true;
            }
            // ne
            pos.defineValors(position.line - 1, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // right
            pos.defineValors(position.line, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // se
            pos.defineValors(position.line + 1, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // down
            pos.defineValors(position.line + 1, position.column);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // so
            pos.defineValors(position.line + 1, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // left
            pos.defineValors(position.line, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // no
            pos.defineValors(position.line - 1, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMoveKing(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;
        }
    }
}
