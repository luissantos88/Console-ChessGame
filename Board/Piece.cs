using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Piece
    {
        public Position position {  get; set; }
        public Colour colour { get; protected set; }  
        public int qtdMovements { get; protected set; }
        public GameBoard gameBoard { get; protected set; }

        public Piece(GameBoard gameBoard, Colour colour)
        {
            this.position = null;
            this.gameBoard = gameBoard;
            this.colour = colour;        
            qtdMovements = 0;
        }


    }
}
