using Board;

namespace xadrez
{
    class Queen : Piece
    {

        public Queen(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool podeMover(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p == null || p.colour != colour;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] mat = new bool[gameBoard.lines, gameBoard.columns];

            Position pos = new Position(0, 0);

            // esquerda
            pos.defineValors(position.line, position.column - 1);
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line, pos.column - 1);
            }

            // direita
            pos.defineValors(position.line, position.column + 1);
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line, pos.column + 1);
            }

            // acima
            pos.defineValors(position.line - 1, position.column);
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line - 1, pos.column);
            }

            // abaixo
            pos.defineValors(position.line + 1, position.column);
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
            {
                mat[pos.line, pos.column] = true;
                if (gameBoard.piece(pos) != null && gameBoard.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValors(pos.line + 1, pos.column);
            }

            // NO
            pos.defineValors(position.line - 1, position.column - 1);
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
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
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
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
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
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
            while (gameBoard.positionIsValid(pos) && podeMover(pos))
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