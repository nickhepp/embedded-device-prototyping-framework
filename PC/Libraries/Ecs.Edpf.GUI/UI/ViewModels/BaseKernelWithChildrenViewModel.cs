﻿using Ecs.Edpf.GUI.UI;
using Ecs.Edpf.GUI.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Ecs.Edpf.GUI.UI.ViewModels
{
    public class BaseKernelWithChildrenViewModel : BaseKernelViewModel, IChildViewModelProvider
    {
 


        public List<IChildViewModel> GetChildViewModels()
        {
            List<IChildViewModel> childViewModels = new List<IChildViewModel>
            {
                //new ComPortConnectionSettingsViewModel()
            };

            return childViewModels;
        }

  
    }
}
