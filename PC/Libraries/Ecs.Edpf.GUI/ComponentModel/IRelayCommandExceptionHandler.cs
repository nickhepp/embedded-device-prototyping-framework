using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.GUI.ComponentModel
{
    public interface IRelayCommandExceptionHandler
    {

        void HandleException(Exception ex);

    }
}
