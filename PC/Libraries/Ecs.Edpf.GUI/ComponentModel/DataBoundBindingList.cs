using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public class DataBoundBindingList<T> : BindingList<T>
    {

        public string DisplayMember { get; private set; }

        public string ValueMember { get; private set; }

        public DataBoundBindingList(IEnumerable<T> items, string displayMember, string valueMember)
        {
            DisplayMember = displayMember;
            ValueMember = valueMember;

            foreach (T item in items)
            {
                this.Add(item);
            }

        }



    }
}
