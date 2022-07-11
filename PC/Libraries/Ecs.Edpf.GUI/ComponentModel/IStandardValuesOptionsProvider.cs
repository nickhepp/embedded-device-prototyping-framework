using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public interface IStandardValuesOptionsProvider
    {

        List<string> GetOptions(string optionsName);

        List<string> GetFilteredOptions(string optionsName);


    }
}
