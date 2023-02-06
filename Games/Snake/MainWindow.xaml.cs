using GameLauncher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake_Game
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<TileValue, ImageSource> gridValImage = new Dictionary<TileValue, ImageSource>
        {
            { TileValue.Empty, SnakeImages.Empty },
            { TileValue.Snake, SnakeImages.Body },
            { TileValue.Food, SnakeImages.Food }
        };
        private readonly int rows = 15, columns = 15;
        private readonly Image[,] gridImages;
        private GameState gameState;
        private bool gameRunning;

        public string Username = "";
        public MainWindow(string tUsername)
        {
            InitializeComponent();
            gridImages = SetupGrid();
            gameState = new GameState(rows, columns);
            Username = tUsername;
        }

        private async Task RunGame()
        {
            DrawGrid();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
            await ShowGameOver();
            gameState = new GameState(rows, columns);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameEnd) { return; }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.ChangeDirection(Direction.Left);
                    break;
                case Key.A:
                    gameState.ChangeDirection(Direction.Left);
                    break;
                case Key.Up:
                    gameState.ChangeDirection(Direction.Up);
                    break;
                case Key.W:
                    gameState.ChangeDirection(Direction.Up);
                    break;
                case Key.Down:
                    gameState.ChangeDirection(Direction.Down);
                    break;
                case Key.S:
                    gameState.ChangeDirection(Direction.Down);
                    break;
                case Key.Right:
                    gameState.ChangeDirection(Direction.Right);
                    break;
                case Key.D:
                    gameState.ChangeDirection(Direction.Right);
                    break;
            }
        }

        private async Task GameLoop()
        {
            while (!gameState.GameEnd)
            {
                await Task.Delay(200);
                gameState.Move();
                DrawGrid();
            }
        }

        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, columns];
            GameGrid.Rows = rows;
            GameGrid.Columns = columns;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    Image image = new Image
                    {
                        Source = SnakeImages.Empty
                    };
                    images[r, c] = image;
                    GameGrid.Children.Add(image);
                }
            }
            return images;
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Overlay.Visibility == Visibility.Visible) { e.Handled = true; }
            if (!gameRunning)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false;
            }
        }

        private void DrawGrid()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    TileValue tileVal = gameState.Grid[r, c];
                    gridImages[r, c].Source = gridValImage[tileVal];
                }
            }
            txtScore.Text = $"Score: {gameState.Score}";
        }

        private async Task ShowGameOver()
        {
            await Task.Delay(1000);
            Overlay.Visibility = Visibility.Visible;
            OverlayText.Text = "PRESS ANY KEY TO START";
            // Database
            if(Username != "") { // If not Guest.
                string sql_Add = "INSERT INTO Scores (Username,Game,Score) VALUES('" + Username + "', '" + "Snake" + "', " + gameState.Score + ")";
                UserInfoDb.Execute_SQL(sql_Add);
            }
        }
    }
}
