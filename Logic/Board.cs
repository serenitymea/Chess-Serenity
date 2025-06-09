using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Board
    {
        // двмерный масив фигур
        private readonly Shape[,] shapes = new Shape[8, 8];

        public Shape this[int row, int col]
        {
          get { return shapes[row, col]; } // возвращ фигуру из масива. индексатор для доступа к фигурам по строке и столбцу
            set { shapes[row, col] = value; } // присваивает фигуру в масив
        }

        public Shape this[Pos pos]
        {
            get { return this[pos.Row, pos.Col]; } // возвращает фигуру по позиции
            set { this[pos.Row, pos.Col] = value; } // присваивает фигуру по позиции
        }

        public static Board Original() // созд доску нач
        {
            Board board = new Board();
            board.StartLocation();
            return board;
        }
        private void StartLocation() // уст фиг
        {
            Shape[] WhiteShapes = new Shape[8]
            {
                new Rook(NewPlayer.White),
                new Knight(NewPlayer.White),
                new Bishop(NewPlayer.White),
                new Queen(NewPlayer.White),
                new King(NewPlayer.White),
                new Bishop(NewPlayer.White),
                new Knight(NewPlayer.White),
                new Rook(NewPlayer.White)

            };
            for (int i = 0; i < 8; i++)
            {
                this[7, i] = WhiteShapes[i];

            }
            Shape[] BlackShapes = new Shape[8]
{
                new Rook(NewPlayer.Black),
                new Knight(NewPlayer.Black),
                new Bishop(NewPlayer.Black),
                new Queen(NewPlayer.Black),
                new King(NewPlayer.Black),
                new Bishop(NewPlayer.Black),
                new Knight(NewPlayer.Black),
                new Rook(NewPlayer.Black)

};
            for (int i = 0; i < 8; i++)
            {
                this[0, i] = BlackShapes[i];

            }
            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(NewPlayer.Black);
                this[6, i] = new Pawn(NewPlayer.White);
            }
        }
        public static bool IsInside(Pos pos)// проверка на вхождение позиции в доску
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Col >= 0 && pos.Col < 8;
        }
        public bool IsEmpty(Pos pos)// проверка пустая/нет
        {
            return this[pos] == null;
        }
    }
}
