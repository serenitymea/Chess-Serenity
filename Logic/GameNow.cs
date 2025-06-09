using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Logic
{
    //шо парисходит на доске и кто ходит
    public class GameNow
    {
        public Board Boardd { get; private set; }
        public NewPlayer CurrP { get; private set; }

        public GameNow (NewPlayer CurrentPlayer, Board Board)
        {
            CurrP = CurrentPlayer;
            Boardd = Board;
        }
        public IEnumerable <Move> LegalMovForShape (Pos pos)
        {
            // проверка есть ли фиг и принвдлежит ли игроку
            if (Boardd.IsEmpty(pos) || Boardd[pos].Color != CurrP)
            {
                return Enumerable.Empty<Move>();
            }
            // фиг и возм хоыд
            Shape shape = Boardd[pos];
            return shape.GetMoves(pos, Boardd);
        } 
        public void MakeMove(Move move) // походи передай другмоу
        {
            move.Execute(Boardd);
            CurrP = CurrP.getOpponent();
        }
    }
}
