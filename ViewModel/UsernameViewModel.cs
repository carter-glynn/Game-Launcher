using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.View_Model {
    public class UsernameViewModel : ViewModelBase {
        private string _UsernameInput;
        public string UsernameInput {
            get {
                return _UsernameInput;
            }
            set {
                _UsernameInput = value;
                OnPropertyChanged(nameof(UsernameInput));
            }
        }

        private string _PasswordInput;
        public string PasswordInput {
            get {
                return _PasswordInput;
            }
            set {
                _PasswordInput = value;
                OnPropertyChanged(nameof(PasswordInput));
            }
        }

        private string _EmailInput;
        public string EmailInput {
            get {
                return _EmailInput;
            }
            set {
                _EmailInput = value;
                OnPropertyChanged(nameof(EmailInput));
            }
        }

        private string _FirstNameInput;
        public string FirstNameInput {
            get {
                return _FirstNameInput;
            }
            set {
                _FirstNameInput = value;
                OnPropertyChanged(nameof(FirstNameInput));
            }
        }

        private string _LastNameInput;
        public string LastNameInput {
            get {
                return _LastNameInput;
            }
            set {
                _LastNameInput = value;
                OnPropertyChanged(nameof(LastNameInput));
            }
        }
    }
}
