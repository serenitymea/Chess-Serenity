using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Shape
    {
        public abstract ShapeType Type { get; }
        public abstract NewPlayer Color { get; }
        public bool HasMoved { get; set; } = false;
        public abstract Shape Copy();
        public abstract IEnumerable<Move> GetMoves(Pos from, Board board);
        protected IEnumerable<Pos> MovePosInDir(Pos from, Board board, Dirr dir) // ходит в одной поз пок ане упр или преп
        {
            for (Pos pos = from + dir; Board.IsInside(pos); pos += dir)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Shape shape = board[pos];
                if (shape.Color != Color)
                {
                    yield return pos;
                }

                break;
            }

        }
        protected IEnumerable<Pos> MovePosInDir(Pos from, Board board, params Dirr[] dirs)
        {
            foreach (var dir in dirs)
            {
                foreach (var pos in MovePosInDir(from, board, dir))
                {
                    yield return pos;
                }
            }
        }

    }
}
