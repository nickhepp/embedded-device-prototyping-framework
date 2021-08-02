using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp.ComponentModel
{
    public static class LinkVisitor
    {

        public static void VisitUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                // swallow this exception
            }
        }

    }
}
