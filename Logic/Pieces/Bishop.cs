using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Bishop : Shape
    {
        public override ShapeType Type => ShapeType.Bishop;
        public override NewPlayer Color { get; }
        private static readonly Dirr[] dirs = new Dirr[] 
        {
        Dirr.NW,
        Dirr.NE,
        Dirr.SW,
        Dirr.SE
        };
        public Bishop(NewPlayer color)
        {
            Color = color;
        }
    public override Shape Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Pos from, Board board)// гетмувс класический
        {
            return MovePosInDir(from, board, dirs)
                .Select(to => new ClassicMove(from, to));
        }
    }
}
