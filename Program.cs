using Board;
using Xadrez_console;
using Chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosition());

        }
    }
}
