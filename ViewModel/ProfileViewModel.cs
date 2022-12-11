using GameLauncher.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameLauncher.ViewModel {
    public class ProfileViewModel : ViewModelBase {
        private string _FirstName;
        public string FirstName {
            get {
                return _FirstName;
            }
            set {
                _FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _LastName;
        public string LastName {
            get {
                return _LastName;
            }
            set {
                _LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string _Username;
        public string Username {
            get {
                return _Username;
            }
            set {
                _Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _Email;
        public string Email {
            get {
                return _Email;
            }
            set {
                _Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _Password;
        public string Password {
            get {
                return _Password;
            }
            set {
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private ImageSource _ProfilePic;
        public ImageSource ProfilePic {
            get {
                return _ProfilePic;
            }
            set {
                _ProfilePic = value;
                OnPropertyChanged(nameof(ProfilePic));
            }
        }

        public ProfileViewModel(string tFirstName, string tLastname, string tUsername, string tEmail, string tPassword) {
            FirstName = tFirstName;
            LastName = tLastname;
            Username = tUsername;
            Email = tEmail;
            Password = tPassword;
        }
    }
}
