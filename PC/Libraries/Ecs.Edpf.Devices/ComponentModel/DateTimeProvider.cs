using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.ComponentModel
{
    public class DateTimeProvider : IDateTimeProvider
    {

        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }


    }
}
