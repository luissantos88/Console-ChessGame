using Board;

namespace Chess
{
    class King : Part
    {
        public King(Game_Board game_Board, Colour colour) : base(game_Board, colour)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
