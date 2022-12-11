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

namespace GameLauncher.View {
    /// <summary>
    /// Interaction logic for LeaderboardView.xaml
    /// </summary>
    public partial class LeaderboardView : UserControl {
        public LeaderboardView() {
            InitializeComponent();

            List<Scores> items = new List<Scores>();
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100"});
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });

            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });

            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            items.Add(new Scores() { Username = "TestUser", Game = "TestGame", Score = "100" });
            lbScores.ItemsSource = items;
        }

        public class Scores {
            public string Username { get; set; }
            public string Game { get; set; }
            public string Score { get; set; }
        }
    }
}
