using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Queen : Shape
    {
        public override ShapeType Type => ShapeType.Queen;
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
        public Queen(NewPlayer colorr)
        {
            Color = colorr;
        }
        public override Shape Copy()
        {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Pos from, Board board) // классический гетмувс
        {
            return MovePosInDir(from, board, dirs)
                .Select(to => new ClassicMove(from, to));
        }
    }
}
