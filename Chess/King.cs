using Board;

namespace Chess
{
    class King : Piece
    {
        public King(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
