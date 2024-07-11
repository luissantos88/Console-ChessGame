using Board;

namespace Chess
{
    class Tower : Piece
    {
        public Tower(GameBoard gameBoard, Colour colour) : base(gameBoard, colour)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}