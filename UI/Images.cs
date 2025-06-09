using Logic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UI
{
    // Выгрузка фоток и хран их в памяти для использования в UI
    public static class Images
    {
        private static readonly Dictionary<ShapeType, ImageSource> whiteSource = new()
        {
            { ShapeType.Pawn, LoadImage("assets/PawnW.png") },
            { ShapeType.Bishop, LoadImage("assets/BishopW.png") },
            { ShapeType.Knight, LoadImage("assets/KnightW.png") },
            { ShapeType.Rook, LoadImage("assets/RookW.png") },
            { ShapeType.Queen, LoadImage("assets/QueenW.png") },
            { ShapeType.King, LoadImage("assets/KingW.png") }
        };

        private static readonly Dictionary<ShapeType, ImageSource> blackSource = new()
        {
            { ShapeType.Pawn, LoadImage("assets/PawnB.png") },
            { ShapeType.Bishop, LoadImage("assets/BishopB.png") },
            { ShapeType.Knight, LoadImage("assets/KnightB.png") },
            { ShapeType.Rook, LoadImage("assets/RookB.png") },
            { ShapeType.Queen, LoadImage("assets/QueenB.png") },
            { ShapeType.King, LoadImage("assets/KingB.png") }
        };
        private static ImageSource LoadImage(string FPath) // загружает картинку по пути
        {
            return new BitmapImage(new Uri(FPath, UriKind.Relative));
        }
        public static ImageSource GetImage(NewPlayer color, ShapeType type) // возвращает картинку по типу фигуры и цвету игрока
        {
            if (color == NewPlayer.White)
            {
                return whiteSource[type];
            }
            else if (color == NewPlayer.Black)
            {
                return blackSource[type];
            }
            else{
                return null;
            }
        }
        public static ImageSource GetImage(Shape shape) // возвращает картинку по фигуре, если фигура null, то возвращает null
        {
            if (shape == null)
            {
                return null;
            }
            return GetImage(shape.Color, shape.Type);
        }
    }
}
