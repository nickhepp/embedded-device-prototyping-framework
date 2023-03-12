﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.UI.ViewModels.DataStorage.AddStorageViewModels
{
    public interface IChildAddDataStorageStreamViewModel
    {

        IChildDataStorageStreamSettings ChildDataStorageStreamSettings { get; }

        string TypeName { get; }

        IChildAddDataStorageStreamViewModel ThisValue { get; }

    }
}
