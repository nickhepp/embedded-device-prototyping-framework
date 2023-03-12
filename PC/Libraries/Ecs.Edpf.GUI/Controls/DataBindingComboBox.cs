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
            // only allow selection of items in the list
            DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void BindToList<T>(DataBoundBindingList<T> bindingList)
        {
            DataSource = bindingList;
            DisplayMember = bindingList.DisplayMember;
            ValueMember = bindingList.ValueMember;
        }


    }

}
