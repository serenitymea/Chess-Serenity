using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Move
    {
        public abstract SpecMoving Type { get; }
        public abstract Pos From { get; }
        public abstract Pos To { get; }
        public abstract void Execute(Board board);
    }
}
