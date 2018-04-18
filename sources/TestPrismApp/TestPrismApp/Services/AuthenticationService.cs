using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TestPrismApp.Annotations;

namespace TestPrismApp.Services
{
    public class AuthenticationService : IAuthenticationService, INotifyPropertyChanged
    {
        private bool _isAuthenticated;
        private string _loggedUser;
        private const string MasterUser = "Georges";

        public bool IsAuthenticated
        {
            get => this._isAuthenticated;
            private set
            {
                if (this.IsAuthenticated == value)
                    return;
                this._isAuthenticated = value;
                this.OnPropertyChanged();
            }
        }

        public string LoggedUser
        {
            get => this._loggedUser;
            private set
            {
                if (this._loggedUser == value)
                    return;
                this._loggedUser = value;
                this.OnPropertyChanged();
            }
        }

        public async Task<bool> LoginAsync(string username)
        {
            await Task.Delay(TimeSpan.FromSeconds(2)); // Let's wait just because it's fun and for demo purpose.
            if (string.Equals(username, MasterUser, StringComparison.InvariantCultureIgnoreCase))
            {
                this.LoggedUser = username;
                this.IsAuthenticated = true;
            }

            return this.IsAuthenticated;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}