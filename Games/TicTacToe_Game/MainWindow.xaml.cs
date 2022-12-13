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

namespace Tic_Tac_Toe_Game
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<Player, ImageSource> imageSources = new()
        {
            { Player.X, new BitmapImage(new Uri("Assets/X15.png", UriKind.Relative)) },
            { Player.O, new BitmapImage(new Uri("Assets/O15.png", UriKind.Relative)) }
        };

        private readonly Image[,] imageControls = new Image[3,3];
        private readonly GameState gameState = new GameState();
        public MainWindow()
        {
            InitializeComponent();
            SetupGrid();

            gameState.MoveMade += MoveMade;
            gameState.GameEnded += GameEnded;
            gameState.GameReStart += GameReStart;
        }

        private void SetupGrid()
        {
            for(int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Image imageControl = new Image();
                    GameGrid.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }
        }

        private void TransToEnd(string text, ImageSource winnerImg)
        {
            TurnPanel.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Hidden;
            ResultText.Text = text;
            WinnerImage.Source = winnerImg;
            EndScreen.Visibility = Visibility.Visible;
        }

        private void TransToGame()
        {
            EndScreen.Visibility = Visibility.Hidden;
            TurnPanel.Visibility = Visibility.Visible;
            GameCanvas.Visibility = Visibility.Visible;
        }
        private void MoveMade(int row, int col)
        {
            Player player = gameState.Grid[row, col];
            imageControls[row, col].Source = imageSources[player];
            PlayerImage.Source = imageSources[gameState.currPlayer];
        }

        private void GameEnded(Result gameResult)
        {
            if (gameResult.winner == Player.Empty) { TransToEnd("TIE GAME!", null); }
            else { TransToEnd("WINNER PLAYER ", imageSources[gameResult.winner]); }
        }
        private void GameReStart()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    imageControls[r, c].Source = null;
                }
            }

            PlayerImage.Source = imageSources[gameState.currPlayer];
            TransToGame();
        }

        private void GameGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double tileSize = GameGrid.Width / 3;
            Point clickPos = e.GetPosition(GameGrid);
            int row = (int)(clickPos.Y / tileSize);
            int col = (int)(clickPos.X / tileSize);
            gameState.MakeMove(row, col);
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            if (gameState.gameEnd)
            {
                gameState.Reset();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
