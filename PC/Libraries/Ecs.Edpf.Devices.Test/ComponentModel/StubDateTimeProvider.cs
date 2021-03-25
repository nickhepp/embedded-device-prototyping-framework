using Ecs.Edpf.Devices.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecs.Edpf.Devices.Test.ComponentModel
{
    public class StubDateTimeProvider : IDateTimeProvider
    {
        private DateTime _currentDateTime;

        public void SetCurrentDateTime(DateTime currentDateTime)
        {
            _currentDateTime = currentDateTime;
        }

        public DateTime GetCurrentDateTime()
        {
            return _currentDateTime;
        }
    }
}
