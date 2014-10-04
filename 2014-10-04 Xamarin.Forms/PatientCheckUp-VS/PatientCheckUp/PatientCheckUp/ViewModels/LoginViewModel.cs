using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Portable.Data.Sqlite;

using PatientCheckUp;
using PatientCheckUp.Models;
using PatientCheckUp.Views;

namespace PatientCheckUp.ViewModels {

    public delegate void UserSavedEventHandler(object sender, EventArgs e);
    public delegate void LoginFailureEventHandler(object sender, EventArgs e);

    public class LoginViewModel : INotifyPropertyChanged {

        public event UserSavedEventHandler UserSaved;
        public event LoginFailureEventHandler LoginFailed;
        
        private INavigation _navigation;
        private bool _userSetupMode = false;
        private EncryptedTable<AppUser> userTable;

        public LoginViewModel(INavigation navigation) {
            _navigation = navigation;
            userTable = new EncryptedTable<AppUser>(App.CryptEngine, App.DatabaseConnection);
            List<AppUser> users = userTable.GetItems(new TableSearch());
            if (users.Count < 1) {
                //No users yet, will need to create one
                _userSetupMode = true;
                this.PageTitle = "New User Setup";
                this.UsernameLabel = "Please create a new user - username:";
                this.LoginLabel = "Save New User";
                OnPropertyChanged("ShowConfirm");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _pageTitle = "Application Login";
        public string PageTitle {
            get { return _pageTitle; }
            set {
                value = (value ?? "").Trim();
                if (value != _pageTitle) {
                    _pageTitle = value;
                    OnPropertyChanged("PageTitle");
                }
            }
        }

        private string _username = "";
        public string Username {
            get { return _username; }
            set {
                if (value != _username) {
                    _username = value;
                    OnPropertyChanged("Username");
                    _userCredentials = Tuple.Create((value ?? "").Trim(), _userCredentials.Item2);
                    OnPropertyChanged("UserCredentials");
                }
            }
        }

        private string _password = "";
        public string Password {
            get { return _password; }
            set {
                if (value != _password) {
                    _password = value;
                    OnPropertyChanged("Password");
                    if (_userSetupMode) {
                        string tempPwd = "";
                        if ((value ?? "").Trim() != "" && value == _confirmPassword)
                            tempPwd = value.Trim();
                        _userCredentials = Tuple.Create(_userCredentials.Item1, tempPwd);
                    }
                    else {
                        _userCredentials = Tuple.Create(_userCredentials.Item1, (value ?? "").Trim());
                    }
                    OnPropertyChanged("UserCredentials");
                }
            }
        }

        private string _confirmPassword = "";
        public string ConfirmPassword {
            get { return _confirmPassword; }
            set {
                if (value != _confirmPassword) {
                    _confirmPassword = value;
                    OnPropertyChanged("ConfirmPassword");
                    if (_userSetupMode) {
                        string tempPwd = "";
                        if ((value ?? "").Trim() != "" && value == _password)
                            tempPwd = value.Trim();
                        _userCredentials = Tuple.Create(_userCredentials.Item1, tempPwd);
                    }
                    OnPropertyChanged("UserCredentials");
                }
            }
        }

        private string _usernameLabel = "Please login - username:";
        public string UsernameLabel {
            get { return _usernameLabel; }
            set {
                if (value != _usernameLabel) {
                    _usernameLabel = value;
                    OnPropertyChanged("UsernameLabel");
                }
            }
        }

        private string _loginLabel = "Login";
        public string LoginLabel {
            get { return _loginLabel; }
            set {
                if (value != _loginLabel) {
                    _loginLabel = value;
                    OnPropertyChanged("LoginLabel");
                }
            }
        }

        public bool ShowConfirm {
            get { return _userSetupMode;  }
        }

        //Item1 = username, Item2 = password
        private Tuple<string, string> _userCredentials = Tuple.Create("", "");
        public Tuple<string, string> UserCredentials {
            get { return _userCredentials; }
        }

        private Command<Tuple<string, string>> loginCommand;
        public Command LoginCommand {
            get {
                return loginCommand ?? (loginCommand = new Command<Tuple<string, string>>(DoLoginCommand, CanLogin));
            }
        }

        private bool CanLogin(Tuple<string, string> userCredentials) {
            bool canLogin = false;
            if (userCredentials != null) {
                canLogin = ((userCredentials.Item1 ?? "").Trim() != "" &&
                    (userCredentials.Item2 ?? "").Trim() != "");
            }
            return canLogin;
        }

        private void DoLoginCommand(Tuple<string, string> userCredentials) {
            if (CanLogin(userCredentials)) {
                if (_userSetupMode) {
                    App.User = new AppUser { Username = userCredentials.Item1, Password = userCredentials.Item2 };
                    userTable.AddItem(App.User, true);
                    if (UserSaved != null) UserSaved(this, EventArgs.Empty);
                    _navigation.PushAsync(new PatientsPage());
                }
                else {
                    var userSearch = new TableSearch();
                    userSearch.MatchItems.Add(new TableSearchItem("Username", UserCredentials.Item1.Trim()) {
                        CaseSensitivity = SearchItemCaseSensitivity.CaseInsensitive
                    });
                    List<AppUser> possibleUsers = userTable.GetItems(userSearch)
                        .Where(u => u.Password == UserCredentials.Item2).ToList();
                    if (possibleUsers.Count == 1) {
                        App.User = possibleUsers.Single();
                        _navigation.PushAsync(new PatientsPage());
                    }
                    else {
                        if (LoginFailed != null) LoginFailed(this, EventArgs.Empty);
                    }
                }
            }
        }

    }
}
