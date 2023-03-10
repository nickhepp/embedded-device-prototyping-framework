using Ecs.Edpf.GUI.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecs.Edpf.GUI.Controls
{
    public class DataBindingComboBox : ComboBox
    {
        public DataBindingComboBox()
        {
            
        }
        public void BindToList<T>(DataBoundBindingList<T> bindingList)
        {
            this.DataSource = bindingList;
            this.DisplayMember = bindingList.DisplayMember;
            this.ValueMember = bindingList.ValueMember;
        }


    }

}
