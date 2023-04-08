using GameLauncher.View_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window {
        public LoginView() {
            InitializeComponent();
            UsernameViewModel UsernameVM = new UsernameViewModel();
            this.DataContext = UsernameVM;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            // Gets RememberMe Info
            if(File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt")) {
                string rememberMe = File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt");
                // Sql to run
                string sSQL = "SELECT * FROM UserInfo WHERE Id=" + rememberMe;
                DataTable tbl = UserInfoDb.Get_DataTable(sSQL);

                // Verify user exists.
                string Username = "";
                string password = "";
                foreach(DataRow row in tbl.Rows) {
                    Username = string.Join("", row[3].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                    password = string.Join("", row[5].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
                }

                tbxUsername.Text = Username;
                tbxPassword.Text = password;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }
        
        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        public void textChangedEventHandler(object sender, TextChangedEventArgs args) {
            if(tbxUsername.Text == "" && tbxPassword.Text == "") { // Both boxes are empty
                var converter = new System.Windows.Media.BrushConverter();
                btnLogin.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnLogin.ToolTip = "Fill in the required information above.";
                return;
            }

            if(Regex.IsMatch(tbxUsername.Text, @"^[A-Za-z0-9]+$") && Regex.IsMatch(tbxPassword.Text, @"^[A-Za-z0-9]+$")) {
                var converter = new System.Windows.Media.BrushConverter();
                btnLogin.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnLogin.ToolTip = "Fill in the required information above.";
                return;
            } else if(tbxUsername.Text == "" && Regex.IsMatch(tbxPassword.Text, @"^[A-Za-z0-9]+$")) {
                var converter = new System.Windows.Media.BrushConverter();
                btnLogin.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnLogin.ToolTip = "Fill in the required information above.";
                return;
            } else if(Regex.IsMatch(tbxUsername.Text, @"^[A-Za-z0-9]+$") && tbxPassword.Text == "") {
                var converter = new System.Windows.Media.BrushConverter();
                btnLogin.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnLogin.ToolTip = "Fill in the required information above.";
                return;
            } else {

            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            // Sql to run
            string sSQL = "SELECT * FROM UserInfo WHERE Username='" + tbxUsername.Text + "'";
            DataTable tbl = UserInfoDb.Get_DataTable(sSQL);

            // Verify user exists.
            int UserId = 0;
            string password = "";
            foreach(DataRow row in tbl.Rows) {
                UserId = Int32.Parse(row[0].ToString()); // Cant address columns by string names, good software ;P
                password = string.Join("", row[5].ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)); // Database pads columns with spaces to fill char count. Not fixing cause i dont care.
            } 

            if(UserId != 0 && tbxPassword.Text.Equals(password) && tbxUsername.Text != "" && tbxPassword.Text != "") { // User Exists.
                if((bool)CheckBoxRemember.IsChecked) {
                    File.WriteAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt", UserId.ToString());
                } else {
                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt");
                }
                MainLauncher MainLauncher = new MainLauncher(UserId);
                MainLauncher.Show();
                this.Close();
            } else {
                tbxUsername.Text = "";
                tbxPassword.Text = "";

                var converter = new System.Windows.Media.BrushConverter();
                btnLogin.Background = (Brush)converter.ConvertFromString("#DD1F11");
                btnLogin.ToolTip = "Username OR Password are not correct. Please enter a valid username and password.";
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e) {
            SignUpView SignUp = new SignUpView();
            SignUp.Show();
            this.Close();
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e) {
            MainLauncher MainLauncher = new MainLauncher(0);
            MainLauncher.Show();
            this.Close();
        }

    }
}
