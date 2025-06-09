using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class ClassicMove : Move
    {
        public override SpecMoving Type => SpecMoving.Classic;
        public override Pos From { get; }
        public override Pos To { get; }
    
    public ClassicMove(Pos from, Pos to)
        {
            From = from;
            To = to;
        }
        public override void Execute(Board board)
        {
            Shape shape = board[From];
            board[To] = shape;
            board[From] = null;
            shape.HasMoved = true;

        }
    } 
}
