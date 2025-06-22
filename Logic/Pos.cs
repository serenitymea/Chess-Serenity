namespace Logic
{
    public class Pos
    {
        //вот эта крч обузначает ряд и колонку
        public int Row { get; }
        public int Col { get; }
        public Pos(int Row, int Column)
        {
            this.Row = Row;
            Col = Column;
        }
        // вот эта шляпа типа сортирует клеточки на белые и черные если белая то она делиться на два без остатка
        public NewPlayer cellcol()
        {
            return (Row + Col) % 2 == 0 ? NewPlayer.White : NewPlayer.Black;
        }   
        // вот эта тема короче сравнивает клетки одинаковые они чи не там типа (1 5) = (1 5) значит выдает тру а если нет то фолс
        public override bool Equals(object obj)
        {
            if (obj is Pos poss)
                return Row == poss.Row && Col == poss.Col;
            return false;
        }
        //уник хеш код для позиции
        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }
        //равность позицицй
        public static bool operator ==(Pos left, Pos right)
        {
            return EqualityComparer<Pos>.Default.Equals(left, right);
        }
        //обратное равности поз
        public static bool operator !=(Pos left, Pos right)
        {
            return !(left == right);
        }
        //движен поз в направлении
        public static Pos operator +(Pos pos, Dirr dir)
        {
            return new Pos(pos.Row + dir.RowD, pos.Col + dir.ColD);
        }
    }
}
