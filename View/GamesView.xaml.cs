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
using Tetris;
using Snake_Game;
using Tic_Tac_Toe_Game;

namespace GameLauncher.View {
    /// <summary>
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl {
        public GamesView() {
            InitializeComponent();
        }

        private void btnTetris_Click(object sender, RoutedEventArgs e) {
            Tetris.MainWindow test = new Tetris.MainWindow(tbxUsername.Text);
            test.Show();
        }

        private void btnTicTacToe_Click(object sender, RoutedEventArgs e) {
            Tic_Tac_Toe_Game.MainWindow test = new Tic_Tac_Toe_Game.MainWindow(tbxUsername.Text);
            test.Show();
        }

        private void btnSnake_Click(object sender, RoutedEventArgs e) {
            Snake_Game.MainWindow test = new Snake_Game.MainWindow(tbxUsername.Text);
            test.Show();
        }
    }
}
