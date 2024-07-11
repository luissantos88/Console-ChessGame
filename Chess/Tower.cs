using Board;

namespace Chess
{
    class Tower : Part
    {
        public Tower(Game_Board game_Board, Colour colour) : base(game_Board, colour)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}