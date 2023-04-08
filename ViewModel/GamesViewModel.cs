using GameLauncher.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.ViewModel {
    public class GamesViewModel : ViewModelBase {
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

        public GamesViewModel(string tUsername) {
            Username = tUsername;
        }
    }
}
