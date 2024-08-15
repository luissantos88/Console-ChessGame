using System.Runtime.ConstrainedExecution;
using Board;

namespace xadrez
{

    class Pawn : Piece
    {
        public Pawn(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Position pos)
        {
            Piece p = gameBoard.piece(pos);
            return p != null && p.colour != colour;
        }

        private bool livre(Position pos)
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
                if (gameBoard.positionIsValid(pos) && livre(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 2, position.column);
                Position p2 = new Position(position.line - 1, position.column);
                if (gameBoard.positionIsValid(p2) && livre(p2) && gameBoard.positionIsValid(pos) && livre(pos) && qtdMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 1, position.column - 1);
                if (gameBoard.positionIsValid(pos) && existeInimigo(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line - 1, position.column + 1);
                if (gameBoard.positionIsValid(pos) && existeInimigo(pos))
                {
                    mat[pos.line, pos.column] = true;
                }

                
            }
            else
            {
                pos.defineValors(position.line + 1, position.column);
                if (gameBoard.positionIsValid(pos) && livre(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 2, position.column);
                Position p2 = new Position(position.line + 1, position.column);
                if (gameBoard.positionIsValid(p2) && livre(p2) && gameBoard.positionIsValid(pos) && livre(pos) && qtdMovements == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 1, position.column - 1);
                if (gameBoard.positionIsValid(pos) && existeInimigo(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValors(position.line + 1, position.column + 1);
                if (gameBoard.positionIsValid(pos) && existeInimigo(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            return mat;
        }
    }
}