using Board;


namespace Xadrez_console.Chess
{
    class Bishop : Piece
    {
        public Bishop(GameBoard gameBoard, Colour colour) : base(gameBoard, colour) { 
        }

        public override string ToString()
        {
            return "B";
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

            // NO
            pos.defineValors(position.line - 1, position.column - 1);
            while (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line - 1, pos.column - 1);
            }

            // NE
            pos.defineValors(position.line - 1, position.column + 1);
            while (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line - 1, pos.column + 1);
            }

            // SE
            pos.defineValors(position.line + 1, position.column + 1);
            while (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line + 1, pos.column + 1);
            }

            // SO
            pos.defineValors(position.line + 1, position.column - 1);
            while (gameBoard.positionIsValid(pos) && canMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line + 1, pos.column - 1);
            }

            return mat;
        }
    }
}

  