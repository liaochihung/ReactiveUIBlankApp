using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace LoginModule.ViewModels
{
    [InjectValidation]
    public class LoginViewModel : ReactiveObject
    {
        [Reactive]
        public string User { get; set; }

        [Reactive]
        public string Password { get; set; }

        [Reactive]
        public bool IsUserLogin { get; set; }

        public ReactiveCommand<Unit, Unit> LoginCommand { get; private set; }
        public ReactiveCommand<Unit, Unit> ResetCommand { get; private set; }

        private readonly LoginViewModelValidator _viewModelValidator;

        public LoginViewModel()
        {
            _viewModelValidator = new LoginViewModelValidator();

            // assume a user is going to login
            IsUserLogin = true;

            var canLogin = this.WhenAny(
                vm => vm.User,
                vm => vm.Password,
                vm => vm.IsUserLogin,
                (user, pass, isUser) =>
                    !string.IsNullOrWhiteSpace(user.Value) &&
                    !string.IsNullOrWhiteSpace(pass.Value) &&
                    (pass.Value.Length > 3) ||
                    !isUser.Value);

            LoginCommand = ReactiveCommand.CreateFromObservable(this.LoginAsync, canLogin);

            var canReset = this.WhenAny(
                vm => vm.User,
                vm => vm.Password,
                (user, pass) =>
                    (!string.IsNullOrWhiteSpace(user.Value) || !string.IsNullOrWhiteSpace(pass.Value))
                );

            ResetCommand = ReactiveCommand.Create(() =>
            {
                User = string.Empty;
                Password = string.Empty;
            }, canReset);
        }

        private IObservable<Unit> LoginAsync() =>
            Observable
                .Return(new Random().Next(0, 2) == 1)
                .Delay(TimeSpan.FromSeconds(1))
                .Do(
                    success =>
                    {
                        if (!success)
                        {
                            Debug.WriteLine("Failed to login");
                            //MessageBox.Show("Failed to login");
                            //throw new InvalidOperationException("Failed to login.");
                        }
                    }
                )
                .Select(_ => Unit.Default);

        /*
        public string this[string columnName]
        {
            get
            {
                //// validate for single property
                //if (columnName == "User")
                //{
                //    if (_viewModelValidator.Validate(this, "User").Errors.Any())
                //    {
                //        return _viewModelValidator.Validate(this, "User").Errors.FirstOrDefault().ErrorMessage;
                //    }
                //    else
                //    {
                //        return string.Empty;
                //    }
                //}
                //*********************************************

                // validate for entire ViewModel
                var firstOrDefault =
                    _viewModelValidator
                        .Validate(this)
                        .Errors
                        .FirstOrDefault(item => item.PropertyName == columnName);

                if (firstOrDefault == null)
                    return string.Empty;

                return _viewModelValidator != null ? firstOrDefault.ErrorMessage : string.Empty;
            }
        }

        public string Error
        {
            get
            {
                var results = _viewModelValidator?.Validate(this);
                if (results == null || !results.Errors.Any())
                    return string.Empty;

                var errors = string.Join(
                    Environment.NewLine,
                    results.Errors
                        .Select(x => x.ErrorMessage)
                        .ToArray());

                return errors;
            }
        }
*/

        /*
    #region INotifyDataErrorInfo

    public IEnumerable GetErrors(string propertyName)
    {
        throw new NotImplementedException();
    }

    public bool HasErrors { get; }
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    #endregion
    */
    }
}
