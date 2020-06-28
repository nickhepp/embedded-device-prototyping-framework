using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.Business
{
    public class BaseDevice : IDevice, IDisposable
    {

        private readonly BindingList<string> _deviceOutputBuffer = new BindingList<string>();
        public BindingList<string> DeviceOutputBuffer => _deviceOutputBuffer;

        private bool _isOpen = false;
        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            private set
            {
                _isOpen = value;
                RaiseNotifyPropertyChanged();
            }
        }        

        protected virtual bool InternalOpen()
        {
            return true;
        }

        public bool Open()
        {
            if (IsOpen)
            {
                throw new Exception("Error opening device more than once.");
            }
            IsOpen = InternalOpen();
            if (DeviceOpened != null)
            {
                DeviceOpened(this, new EventArgs());
            }
            return IsOpen;
        }

        protected virtual bool InternalClose()
        {
            return true;
        }

        public void Close()
        {
            if (!IsOpen)
            {
                throw new Exception("Device is not open.");
            }
            bool closed = InternalClose();
            IsOpen = (!closed);
        }


        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual string InternalWriteLine(string cmdText)
        {
            return null;
        }

        public string Write(string cmdText)
        {
            if (!IsOpen)
            {
                Open();
            }
            string response = InternalWriteLine(cmdText);
            // throw in some throttling
            //System.Threading.Thread.Sleep(100);
            if (!string.IsNullOrEmpty(response))
            {
                DeviceOutputBuffer.Add(response);
            }
            return response;
        }

        public void Dispose()
        {
            if (IsOpen)
            {
                Close();
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event that is raised when the device is opened.
        /// </summary>
        public event EventHandler DeviceOpened;
    }

}
