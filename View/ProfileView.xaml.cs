using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameLauncher.View {
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl {
        public ProfileView() {
            InitializeComponent();
            if(tbxFirstName.Text == "Guest") {
                btnUpdate.Visibility = Visibility.Hidden;
                btnEdit.Visibility = Visibility.Hidden;
            }
        }
        // Used to temp store previous values.
        public string tempFirstname;
        public string tempLastname;
        public string tempUsername;
        public string tempEmail;
        public string tempPassword;

        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            // Allow profile information to be edited.
            tbxFirstName.IsReadOnly = false;
            tbxLastName.IsReadOnly = false;
            tbxUsername.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtPass.IsReadOnly = false;

            // Save Prev values;
            tempFirstname = tbxFirstName.Text;
            tempLastname = tbxLastName.Text;
            tempUsername = tbxUsername.Text;
            tempEmail = txtEmail.Text;
            tempPassword = txtPass.Text;

            // Enable Save button
            btnUpdate.IsEnabled = true;
            var converter = new System.Windows.Media.BrushConverter();
            btnUpdate.Background = (Brush)converter.ConvertFromString("#462AD8");

            // Hide Edit button, Show Cancel button.
            btnEdit.Visibility = Visibility.Hidden;
            btnCancel.Visibility = Visibility.Visible;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e) {
            // Verify Information TODO
            if(!Regex.IsMatch(tbxFirstName.Text, @"^[A-Za-z]+$") || !Regex.IsMatch(tbxLastName.Text, @"^[A-Za-z]+$")
                || !Regex.IsMatch(tbxUsername.Text, @"^[A-Za-z0-9]+$") || !Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")
                || !Regex.IsMatch(txtPass.Text, @"^[A-Za-z0-9!$#&]+$")) {


                // Update color.
                var converter = new System.Windows.Media.BrushConverter();
                btnUpdate.Background = (Brush)converter.ConvertFromString("#DD1F11");
                btnUpdate.ToolTip = "Please enter valid values above.";
            } else {
                // Update values
                string sql_Add = "UPDATE UserInfo SET FirstName='" + tbxFirstName.Text + "', LastName='" + tbxLastName.Text + "', Username='" + tbxUsername.Text  + "', Email='" + txtEmail.Text + "', Password='" + txtPass.Text + "' WHERE Email='" + tempEmail + "' AND Password='" + tempPassword + "'";
                UserInfoDb.Execute_SQL(sql_Add);

                // Disable Save button
                btnUpdate.IsEnabled = false;

                // Hide Cancel button, Show Edit button.
                btnEdit.Visibility = Visibility.Visible;
                btnCancel.Visibility = Visibility.Hidden;

                // Read-Only
                tbxFirstName.IsReadOnly = true;
                tbxLastName.IsReadOnly = true;
                tbxUsername.IsReadOnly = true;
                txtEmail.IsReadOnly = true;
                txtPass.IsReadOnly = true;

                // reset to gray.
                var converter = new System.Windows.Media.BrushConverter();
                btnUpdate.Background = (Brush)converter.ConvertFromString("DarkGray");
            }
        }
        public void textChangedEventHandler(object sender, TextChangedEventArgs args) {
            // Anytime a textbox value changes, ensure correct colors are visible.
            if((tbxFirstName.Text == "" || Regex.IsMatch(tbxFirstName.Text, @"^[A-Za-z]+$")) && (tbxLastName.Text == "" || Regex.IsMatch(tbxLastName.Text, @"^[A-Za-z]+$"))
                && (txtEmail.Text == "" || Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")) && (tbxUsername.Text == "" || Regex.IsMatch(tbxUsername.Text, @"^[A-Za-z0-9]+$"))
                && (txtPass.Text == "" || Regex.IsMatch(txtPass.Text, @"^[A-Za-z0-9!$#&]+$"))) { // Both boxes are empty
                var converter = new System.Windows.Media.BrushConverter();
                btnUpdate.Background = (Brush)converter.ConvertFromString("#462AD8");
                btnUpdate.ToolTip = "Fill in the required information above.";

                // Hidden buttons if guest.
                if(tbxFirstName.Text == "Guest") {
                    btnUpdate.Visibility = Visibility.Hidden;
                    btnEdit.Visibility = Visibility.Hidden;
                }

                // Grey out edit if not editing.
                if(btnCancel.IsVisible == false) {
                    btnUpdate.Background = (Brush)converter.ConvertFromString("DarkGray");
                }
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            // Return values.
            tbxFirstName.Text = tempFirstname;
            tbxLastName.Text = tempLastname;
            tbxUsername.Text = tempUsername;
            txtEmail.Text = tempEmail;
            txtPass.Text = tempPassword;

            // Hide Cancel button, Show Edit button.
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Hidden;
        }
    }
}
