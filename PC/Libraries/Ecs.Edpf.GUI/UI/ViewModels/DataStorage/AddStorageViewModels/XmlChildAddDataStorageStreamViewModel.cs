using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public class XmlChildAddDataStorageStreamViewModel : BaseChildAddDataStorageStreamViewModel
    {

        public const string XmlTypeName = "XML";

        private XmlDataStorageStreamSettings _storageStreamSettings = new XmlDataStorageStreamSettings();
        public override object ChildDataStorageStreamSettings => _storageStreamSettings;

        public override string TypeName => XmlTypeName;
    }
}
