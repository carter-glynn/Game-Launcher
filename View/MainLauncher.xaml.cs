using GameLauncher.ViewModel;
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
using System.Windows.Shapes;

namespace GameLauncher.View {
    /// <summary>
    /// Interaction logic for MainLauncher.xaml
    /// </summary>
    public partial class MainLauncher : Window {
        public struct User {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int UserId { get; set; }
        }
        public User CurrentUser = new User();
        public MainLauncher(int userId) {
            InitializeComponent();
            CurrentUser.UserId = userId; 
            if(CurrentUser.UserId != 0) { // 0 Is Guest
                // Get User info from Db
                string sSQL = "SELECT * FROM UserInfo WHERE Id=" + CurrentUser.UserId;
                DataTable tbl = UserInfoDb.Get_DataTable(sSQL);

                // Pull info from row
                foreach(DataRow row in tbl.Rows) {
                    CurrentUser.FirstName = string.Join("", row[1].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                    CurrentUser.LastName = string.Join("", row[2].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                    CurrentUser.Username = string.Join("", row[3].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                    CurrentUser.Email = string.Join("", row[4].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                    CurrentUser.Password = string.Join("", row[5].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                }
                this.DataContext = new MainLauncherViewModel(CurrentUser.FirstName, CurrentUser.LastName, CurrentUser.Username, CurrentUser.Email, CurrentUser.Password);
            }
            else {
                this.DataContext = new MainLauncherViewModel("Guest", "", "", "", "");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
