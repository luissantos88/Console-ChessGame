

namespace Board
{
    class GameBoard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public GameBoard(int line, int column)
        {
            this.lines = line;
            this.columns = column;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
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
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }
        public Piece removePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool positionIsValid(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }
            return true;
        }
        public void validPosition(Position pos)
        {
            if (!positionIsValid(pos))
            {
                throw new BoardException("Invalid position!!!");
            }
        }
    }
}
