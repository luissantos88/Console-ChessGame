

namespace Board
{
    class GameBoard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] parts;

        public GameBoard(int line, int column)
        {
            this.lines = line;
            this.columns = column;
            parts = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return parts[line, column];
        }

        public Piece piece(Position pos)
        {
            return piece(pos.line, pos.column);
        }

        public bool existsPiece(Position pos)
        {
            validPosition(pos);
            return piece(pos) != null;
        }

        public void placePiece(Piece p, Position pos)
        {
            if (existsPiece(pos))
            {
                throw new BoardException("Already exists a piece in this positon!!!");
            }
            parts[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool positionValid(Position pos)
        {
            if (pos.line < 0 || pos.line > lines || pos.column < 0 || pos.column > columns)
            {
                return false;
            }
            return true;
        }
        public void validPosition(Position pos)
        {
            if (!positionValid(pos))
            {
                throw new BoardException("Invalid position!!!");
            }
        }
    }
}
