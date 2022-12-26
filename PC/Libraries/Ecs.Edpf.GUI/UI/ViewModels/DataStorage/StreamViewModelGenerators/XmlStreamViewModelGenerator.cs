using Ecs.Edpf.Data.StreamSettings;
using Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.StreamViewModelGenerators
{
    public class XmlStreamViewModelGenerator : BaseDataStorageStreamViewModelGenerator
    {

        private XmlStreamSettings _xmlStreamSettings;

        public XmlStreamViewModelGenerator(XmlStreamSettings xmlStreamSettings)
        {
            _xmlStreamSettings = xmlStreamSettings;
        }

        protected override IDataStorageStreamViewModel InternalGetDataStorageStreamViewModel()
        {
            return new XmlStreamViewModel(_xmlStreamSettings);
        }
    }
}
