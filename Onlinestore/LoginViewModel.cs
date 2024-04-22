using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.models;

namespace OnlineStore
{
    internal class LoginViewModel : LoginModel
    {
        LoginModel loginModel = new LoginModel();

        public string Username
        {
            get
            {
                return loginModel.Username;
            }
            set
            {
                loginModel.Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get
            {
                return loginModel.Password;
            }
            set
            {
                loginModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string RoleUser
        {
            get
            {
                return loginModel.RoleUser;
            }
            set
            {
                loginModel.RoleUser = value;
                OnPropertyChanged(nameof(RoleUser));
            }
        }

        public event EventHandler<bool> LoggedIn;

        private void OnLoggedIn(bool isAdmin)
        {
            LoggedIn?.Invoke(this, isAdmin);
        }

        private bool isAdmin;
        public bool IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
                OnPropertyChanged(nameof(BoolToVisibilityConverter));
            }
        }

        public void SetRole(string role)
        {
            RoleUser = role;
            OnPropertyChanged(nameof(IsAdmin));

        }

        public bool AttemptLogin()
        {

            if (Username == "admin" && Password == "admin")
            {
                isAdmin = true;
                return true;

            }
            else if (Username == "user" && Password == "user")
            {
                isAdmin = false;
                return true;
            }
            else if (Username == "emp" && Password == "emp")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
