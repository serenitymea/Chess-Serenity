namespace Logic
{
    //направления
    public class Dirr
    {
        public readonly static Dirr N = new Dirr(-1, 0);
        public readonly static Dirr S = new Dirr(1, 0);
        public readonly static Dirr E = new Dirr(0, 1);
        public readonly static Dirr W = new Dirr(0, -1);
        public readonly static Dirr NE = N + E;
        public readonly static Dirr NW = N + W;
        public readonly static Dirr SE = S + E;
        public readonly static Dirr SW = S + W;
        public int RowD { get; }
        public int ColD { get; }

        public Dirr(int rowDelta, int columnDelta)
        {
            RowD = rowDelta;
            ColD = columnDelta;
        }
        // сумм понятий
        public static Dirr operator +(Dirr dir1, Dirr dir2)
        {
            return new Dirr(dir1.RowD + dir2.RowD, dir1.ColD + dir2.ColD);
        }
        // множ ходов
        public static Dirr operator *(int scalar, Dirr dir)
        {
            return new Dirr(scalar * dir.RowD, scalar * dir.ColD);
        }
    }
}
