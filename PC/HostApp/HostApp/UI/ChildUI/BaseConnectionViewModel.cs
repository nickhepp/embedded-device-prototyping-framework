using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HostApp.ComponentModel;

namespace HostApp.UI.ChildUI
{
    public abstract class BaseConnectionViewModel : BaseChildViewModel
    {
        private bool _isOpened = false;
        public bool IsOpened {
            get
            {
                return _isOpened;
            }
            set
            {
                _isOpened = value;
            }
        }

        public ICommand OpenConnectionCommand { get; private set; }


        public BaseConnectionViewModel()
        {
            OpenConnectionCommand = new RelayCommand(obj => OpenConnectionCommandCanExecute(obj), obj => OpenConnectionCommandHandler(obj));
        }

        protected abstract bool OpenConnectionCommandCanExecute(object obj);

        private void OpenConnectionCommandHandler(object obj)
        {
            //Device.
        }

        protected override void InternalDevice_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }



    }
}
