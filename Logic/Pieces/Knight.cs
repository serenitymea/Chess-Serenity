namespace Logic
{
    public class Knight : Shape
    {
        public override ShapeType Type => ShapeType.Knight;
        public override NewPlayer Color { get; }
        public Knight(NewPlayer color)
        {
            Color = color;
        }
        public override Shape Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        private static IEnumerable<Pos> PotentialToPos(Pos from) // возвр все поз в виде Г
        {
            foreach (Dirr vDir in new Dirr[] { Dirr.N, Dirr.S })
            {
                foreach (Dirr hDir in new Dirr[] { Dirr.E, Dirr.W })
                {
                    yield return from + 2 * vDir + hDir;
                    yield return from + 2 * hDir + vDir;
                }
            }
        }
        // ищет пос с фром и превращает их в ходы
        private IEnumerable<Pos> MovePos(Pos froam, Board board)
        {
            return PotentialToPos(froam)
                .Where(pos => Board.IsInside(pos) 
                && (board.IsEmpty(pos) || board[pos].Color != Color));
        }
        public override IEnumerable<Move> GetMoves(Pos froam, Board board)
        {
            return MovePos(froam, board)
                .Select(to => new ClassicMove(froam, to));
        }
    }
}
