using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
