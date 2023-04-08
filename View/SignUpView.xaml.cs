using GameLauncher.View_Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : Window {
        public SignUpView() {
            InitializeComponent();
            UsernameViewModel UsernameVM = new UsernameViewModel();
            this.DataContext = UsernameVM;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if(e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            LoginView LoginView = new LoginView();
            LoginView.Show();
            this.Close();
        }

        public void textChangedEventHandler(object sender, TextChangedEventArgs args) {
            // Anytime a textbox value changes, ensure correct colors are visible.
            if((txtFirstName.Text == "" || Regex.IsMatch(txtFirstName.Text, @"^[A-Za-z]+$")) && (txtLastName.Text == "" || Regex.IsMatch(txtLastName.Text, @"^[A-Za-z]+$")) 
                && (txtEmail.Text == "" || Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")) && (txtUsername.Text == "" || Regex.IsMatch(txtUsername.Text, @"^[A-Za-z0-9]+$"))
                && (txtPass.Text == "" || Regex.IsMatch(txtPass.Text, @"^[A-Za-z0-9!$#&]+$"))) { // Both boxes are empty
                var converter = new System.Windows.Media.BrushConverter();
                btnCreateAccount.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnCreateAccount.ToolTip = "Fill in the required information above.";
                return;
            }
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e) {
            // Verify Information TODO
            if(!Regex.IsMatch(txtFirstName.Text, @"^[A-Za-z]+$") || !Regex.IsMatch(txtLastName.Text, @"^[A-Za-z]+$")
                || !Regex.IsMatch(txtUsername.Text, @"^[A-Za-z0-9]+$") || !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")
                || !Regex.IsMatch(txtPass.Text, @"^[A-Za-z0-9!$#&]+$")) {

                // Clear Email and Password field.
                txtEmail.Text = "";
                txtPass.Text = "";

                // Update color.
                var converter = new System.Windows.Media.BrushConverter();
                btnCreateAccount.Background = (Brush)converter.ConvertFromString("#DD1F11");
                btnCreateAccount.ToolTip = "Please enter valid values above.";
            } else {
                // Init vals to make sql easier.
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string username = txtUsername.Text; 
                string email = txtEmail.Text;
                string password = txtPass.Text; 

                // Create new user.
                string sql_Add = "INSERT INTO UserInfo (FirstName,LastName,Username,Email,Password) VALUES('" + firstName + "', '" + lastName + "', '" + username + "', '" + email + "','" + password + "')";
                UserInfoDb.Execute_SQL(sql_Add);

                // Sql to run
                string sSQL = "SELECT * FROM UserInfo WHERE Username='" + txtUsername.Text + "'";
                DataTable tbl = UserInfoDb.Get_DataTable(sSQL);

                // Verify user exists.
                int UserId = 0;
                foreach(DataRow row in tbl.Rows) {
                    UserId = Int32.Parse(row[0].ToString()); // Cant address columns by string names, good software ;P
                }

                // Cleanup previous RememberMe file.
                if(File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt")) {
                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt");
                }

                // Save user on signup so values populate on Login Page.
                File.WriteAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/RememberMe.txt", UserId.ToString());
                
                // Reload Login page. New Account will auto populate.
                LoginView LoginView = new LoginView();
                LoginView.Show();
                this.Close();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
