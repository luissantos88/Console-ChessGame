

namespace Board
{
    class Game_Board
    {
        public int lines {  get; set; }
        public int columns { get; set; }
        private Part[,] parts;

        public Game_Board(int line, int column)
        {
            this.lines = line;
            this.columns = column;
            parts = new Part[lines, columns];
        }

        public Part part(int line, int column)
        {
            return parts[line, column];
        }

        public void placePart(Part p, Position pos)
        {
            parts[pos.line, pos.column] = p;
            p.position = pos;
        }
    }
}
