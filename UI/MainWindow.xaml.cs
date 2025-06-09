using System.ComponentModel.Design;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Resources;
using Logic;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private readonly Image[,] ShapeImages = new Image[8, 8]; // массив для хранения изображений фигур
        private readonly Rectangle[,] highlights = new Rectangle[8, 8]; // массив для хранения подсветки клеток
        private readonly Dictionary<Pos, Move> moveCache = new Dictionary<Pos, Move>(); // кэш для хранения возможных ходов

        private GameNow gameState;
        private Pos selectedPos = null;

        public MainWindow() // курсор
        {
            var uri = new Uri("pack://application:,,,/assets/Bloody Cursor.cur");
            var stream = Application.GetResourceStream(uri)?.Stream;

            if (stream != null)
            {
                this.Cursor = new Cursor(stream);
            }

            InitializeComponent();
            InitB();
            gameState = new GameNow(NewPlayer.White, Board.Original());
            DrawB(gameState.Boardd);
        }
        private void InitB() // имдж и фигуры для кадой
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    Image image = new Image();
                    ShapeImages[i, o] = image;
                    ShapeGrid.Children.Add(image);
                    Rectangle highlight = new Rectangle();
                    highlights[i, o] = highlight;
                    HGGrid.Children.Add(highlight);
                }
            }
        }
    private void DrawB(Board board) // рисует все фигуры
        {
            for (int i = 0; i < 8; i++)
            {
                for (int o = 0; o < 8; o++)
                {
                    Logic.Shape shape = board[i, o];
                    ShapeImages[i, o].Source = Images.GetImage(shape);
                }
            }
        }

        private void BoardGrid_MouseD(object sender, MouseButtonEventArgs e) // клики мыши ОнФр = выбор ОнТу = ход
        {
            Point point = e.GetPosition(BoardGrid);
            Pos pos = ToSqrPos(point);
            if(selectedPos == null)
            {
                OnFrPosSel(pos);
            }
            else
            {
                OnToPosSel(pos);
            }
        }

        private Pos ToSqrPos(Point point) // корды мыши в поз учит разм и делит на 8
        {
            double KVsize = BoardGrid.ActualWidth / 8;
            int row = (int)(point.Y / KVsize);
            int col = (int)(point.X / KVsize);
            return new Pos(row, col);
        }
        private void OnFrPosSel(Pos pos) // выбирает фиг подсвечивает ходы
        {
            IEnumerable<Move> moves = gameState.LegalMovForShape(pos);
            if (moves.Any())
            {
                selectedPos = pos;
                CacheMove(moves);
                ShowHG();
            } 
        }
        private void OnToPosSel(Pos pos) // делает ход если невохм вызыввает HMove иначе снимает подсветку и делает ход
        {
            selectedPos = null;
            HideHG();
            if(moveCache.TryGetValue(pos, out Move move))
            {
                HMove(move);
            }
        }
        private void HMove(Move move) //делает ход через геймстейт и рисует доску заново
        {
            gameState.MakeMove(move);
            DrawB(gameState.Boardd);
        }
        private void CacheMove(IEnumerable<Move> moves) // сохран все возм ходыы
        {
            moveCache.Clear();
            foreach (Move move in moves)
            {
                moveCache[move.To] = move;
            }
        }
        private void ShowHG() // подсветка
        {
            Color color = Color.FromArgb(150, 180, 0, 0);
            
            foreach (Pos to in moveCache.Keys)
            {
                highlights[to.Row, to.Col].Fill = new SolidColorBrush(color);
            }
        }
        private void HideHG() // снимает подсветку
        {
            foreach (Pos to in moveCache.Keys)
            {
                highlights[to.Row, to.Col].Fill = Brushes.Transparent;
            }
        }
    }
}