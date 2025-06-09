using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Rook : Shape
    {
        public override ShapeType Type => ShapeType.Rook;
        public override NewPlayer Color { get; }
        private static readonly Dirr[] dirs = new Dirr[]
        {
            Dirr.N,
            Dirr.S,
            Dirr.E,
            Dirr.W
        };
        public Rook(NewPlayer colorr)
        {
            Color = colorr;
        }
        public override Shape Copy()
        {
            Rook copy = new Rook(Color);
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