using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HostApp.ComponentModel
{
    public class WarningMessageBoxService : IWarningMessageBoxService
    {


        public void ShowWarningMessageBox(string text, string caption)
        {
            System.Windows.MessageBox.Show(text, caption, button: MessageBoxButton.OK, icon: MessageBoxImage.Exclamation);
        }


    }
}
