using System;
using System.Collections.Generic;
using System.Data;
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

            // Get scores from Database.
            string sSQL = "SELECT * FROM Scores";
            DataTable tbl = UserInfoDb.Get_DataTable(sSQL);

            // Verify user exists.
            foreach(DataRow row in tbl.Rows) {
                string Username = string.Join("", row[1].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                string Game = string.Join("", row[2].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                string score = string.Join("", row[3].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                items.Add(new Scores() { Username = Username, Game = Game, Score = score });
            }

            List<Scores> SortedList = items.OrderByDescending(o => o.Score).ToList();

            lbScores.ItemsSource = SortedList;
        }

        public class Scores {
            public string Username { get; set; }
            public string Game { get; set; }
            public string Score { get; set; }
        }
    }
}
