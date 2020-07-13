using Dan_XLV_Mladjan_Mrksic.Command;
using Dan_XLV_Mladjan_Mrksic.Validation;
using System;
using System.Windows.Input;

namespace Dan_XLV_Mladjan_Mrksic.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;
        LoginValidation lv = new LoginValidation();
        #region Constructor
        public MainWindowViewModel(MainWindow login)
        {
            main = login;
        }
        #endregion
        #region Commands
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(param => SubmitExecute(), param => CanSubmitExecute());
                }
                return submit;
            }
        }
        private void SubmitExecute()
        {
            lv.Login(main.usernameBox.Text, main.passwordBox.Password, main);
        }
        private bool CanSubmitExecute()
        {
            if (String.IsNullOrEmpty(main.usernameBox.Text) || String.IsNullOrEmpty(main.passwordBox.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
