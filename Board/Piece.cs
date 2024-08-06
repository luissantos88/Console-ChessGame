using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
   abstract class Piece
    {
        public Position position { get; set; }
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

        public void incrementMovements()
        { 
            qtdMovements++; 
        }

        public bool existsPossibleMovements()
        {
            bool[,] mat = possibleMovements();
            for (int i = 0; i < gameBoard.lines; i++)
            {
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    if (mat[i, j] )
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)
        {
            return possibleMovements()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMovements();              
    }
}