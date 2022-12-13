﻿using System;
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

namespace GameLauncher.View {
    /// <summary>
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl {
        public GamesView() {
            InitializeComponent();
        }

        private void btnTetris_Click(object sender, RoutedEventArgs e) {
            MainWindow test = new MainWindow(tbxUsername.Text);
            test.Show();
        }
    }
}
