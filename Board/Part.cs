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

        public Part(Game_Board board, Colour colour)
        {
            this.position = null;
            this.board = board;
            this.colour = colour;        
            qtdMovements = 0;
        }


    }
}
