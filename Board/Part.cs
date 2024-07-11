using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Part
    {
        public Position position {  get; set; }
        public Colour colour { get; protected set; }  
        public int qtdMovements { get; protected set; }
        public Game_Board board { get; protected set; }

        public Part(Position position, Colour colour, Game_Board board)
        {
            this.position = position;
            this.colour = colour;
            this.board = board;
            qtdMovements = 0;
        }
    }
}
