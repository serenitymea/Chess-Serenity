using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class King : Shape
    {
        public override ShapeType Type => ShapeType.King;
        public override NewPlayer Color { get; }
        private static readonly Dirr[] dirs = new Dirr[]
        {
            Dirr.N,
            Dirr.S,
            Dirr.E,
            Dirr.W,
            Dirr.NW,
            Dirr.NE,
            Dirr.SW,
            Dirr.SE
        };
        public King(NewPlayer color)
        {
            Color = color;
        }
        public override Shape Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        // ген всех вохм похиций и превращ их в ходы
        private IEnumerable<Pos> MovePos(Pos from, Board board) 
        {
            foreach (Dirr dir in dirs)
            {
                Pos to = from + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Pos from, Board board)
        {
            foreach (Pos to in MovePos(from, board))
            {
                yield return new ClassicMove(from, to);
            }
        }
    }
}
