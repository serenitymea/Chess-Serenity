using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    //все взоможные цвета игрока
    public enum NewPlayer
    {
        NoPlayer,
        White,
        Black
    }
    // штука которая меняет игрока типа если он черный то белым быть не может кекв
    public static class  ChangePlayer 
    {
        public static NewPlayer getOpponent(this NewPlayer thisPlayer)
        {
            if (thisPlayer == NewPlayer.Black)
                return NewPlayer.White;
            else if (thisPlayer == NewPlayer.White)
                return NewPlayer.Black;
            else
                return NewPlayer.NoPlayer;            
        }
    }
}
