﻿using HostApp.UI.ChildUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostApp.UI.ViewModels
{
    public interface IParentMainViewModel : IMainViewModel
    {


        List<IChildViewModel> GetChildViewModels();

    }
}