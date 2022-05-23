using System;
using System.Collections.Generic;
using System.Text;

namespace Ecs.Edpf.Devices.ComponentModel
{
    public static class ExceptionUtility
    {

        private static void InternalGetExceptionMessages(Exception ex, StringBuilder stringBuilder)
        {
            if (ex.InnerException != null)
            {
                InternalGetExceptionMessages(ex.InnerException, stringBuilder);
            }
            stringBuilder.Append(ex.Message);
        }

        public static string GetExceptionMessages(Exception ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            InternalGetExceptionMessages(ex, stringBuilder);
            return stringBuilder.ToString();
        }


    }
}
