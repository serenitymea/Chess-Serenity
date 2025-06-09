using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Pawn : Shape
    {
        public override ShapeType Type => ShapeType.Pawn;
        public override NewPlayer Color { get; }

        private readonly Dirr forw;

        public Pawn(NewPlayer colorr)
        {
            Color = colorr;

            if (colorr == NewPlayer.White)
            {
                forw = Dirr.N;
            }
            else if (colorr == NewPlayer.Black)
            {
                forw = Dirr.S;
            }
        }
        public override Shape Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private static bool CanMoveT(Pos pos, Board board) // тру пуста фолс вне занята
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }
        private bool CanZahvat(Pos pos, Board board)
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }
            return board[pos].Color != Color;
        }
        private IEnumerable<Move> ForwardMov(Pos from, Board board) // ретурнит все ходы вперед
        {
            Pos oneMPos = from + forw;
            if (CanMoveT(oneMPos, board))
            {
                yield return new ClassicMove(from, oneMPos);
                Pos twoMPos = oneMPos + forw;
                if (!HasMoved && CanMoveT(twoMPos, board))
                {
                    yield return new ClassicMove(from, twoMPos);
                }
            }
        }
        private IEnumerable<Move> DiagonMov(Pos from, Board board) // ретрнит все по диагон
        {
            foreach (Dirr dir in new Dirr[] { Dirr.W, Dirr.E })
            {
                Pos to = from + forw + dir;
                if (CanZahvat(to, board))
                {
                    yield return new ClassicMove(from, to);
                }
            }
        }
        public override IEnumerable<Move> GetMoves(Pos from, Board board) // реткрнит все возм
        {
            return ForwardMov(from, board)
                .Concat(DiagonMov(from, board));
        }
    }
}
