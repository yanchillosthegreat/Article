using Article.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.ViewModels
{
    public class RegistrationViewModel : BindableBase
    {
        private bool isUserNameValid = false;
        public bool IsUserNameValid
        {
            get { return isUserNameValid; }
            set
            {
                Set(ref isUserNameValid, value);
                RaisePropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }

        private bool isBirthdateValid = false;
        public bool IsBirthdateValid
        {
            get { return isBirthdateValid; }
            set
            {
                Set(ref isBirthdateValid, value);
                RaisePropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }

        private bool isEmailValid = false;
        public bool IsEmailValid
        {
            get { return isEmailValid; }
            set
            {
                Set(ref isEmailValid, value);
                RaisePropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }

        private bool isPasswordValid = false;
        public bool IsPasswordValid
        {
            get { return isPasswordValid; }
            set
            {
                Set(ref isPasswordValid, value);
                RaisePropertyChanged(nameof(IsRegisterButtonEnabled));
            }
        }

        public bool IsRegisterButtonEnabled
        {
            get { return IsUserNameValid && IsBirthdateValid && IsEmailValid && IsPasswordValid; }
        }

        public RegistrationViewModel()
        {

        }
    }
}
