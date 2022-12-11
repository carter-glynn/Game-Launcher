using GameLauncher.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameLauncher.ViewModel {
    public class MainLauncherViewModel : ViewModelBase {
        public struct User {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public int UserId { get; set; }
        }
        public User CurrentUser;

        private ViewModelBase _currentChildViewModel;
        public ViewModelBase currentChildViewModel {
            get {
                return _currentChildViewModel;
            }
            set {
                _currentChildViewModel = value;
                OnPropertyChanged(nameof(currentChildViewModel));
            }
        }

        // Commands
        public ICommand ShowGamesViewCommand { get; }
        public ICommand ShowProfileViewCommand { get; }
        public ICommand ShowLeaderboardViewCommand { get; }

        public MainLauncherViewModel(string tFirstName, string tLastname, string tUsername, string tEmail, string tPassword) {
            // Initalize Commands.
            ShowGamesViewCommand = new ViewModelCommand(ExecuteShowGamesViewCommand);
            ShowProfileViewCommand = new ViewModelCommand(ExecuteShowProfileViewCommand);
            ShowLeaderboardViewCommand = new ViewModelCommand(ExecuteShowLeaderboardViewCommand);

            // Default view
            ExecuteShowGamesViewCommand(null);

            CurrentUser.FirstName = tFirstName;
            CurrentUser.LastName = tLastname;
            CurrentUser.Username = tUsername;
            CurrentUser.Email = tEmail;
            CurrentUser.Password = tPassword;
            
        }

        private void ExecuteShowLeaderboardViewCommand(object obj) {
            currentChildViewModel = new LeaderboardViewModel();
        }

        private void ExecuteShowProfileViewCommand(object obj) {
            currentChildViewModel = new ProfileViewModel(CurrentUser.FirstName, CurrentUser.LastName, CurrentUser.Username, CurrentUser.Email, CurrentUser.Password);
        }

        private void ExecuteShowGamesViewCommand(object obj) {
            currentChildViewModel = new GamesViewModel();
            
        }
    }
}
