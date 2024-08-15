using Board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }
        public override string ToString()
        {
            return "H";
        }
        private bool canMove(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p == null || p.colour != colour;
        }
        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[gameBoard.lines, gameBoard.columns];

            Position pos = new Position(0, 0);

            pos.defineValors(position.line - 1, position.column - 2);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line - 2, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line - 2, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line - 1, position.column + 2);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line + 1, position.column + 2);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line + 2, position.column + 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line + 2, position.column - 1);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValors(position.line + 1, position.column - 2);
            if (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }           
            return mat;
        }
    }
}
