using HostApp.Business;

namespace HostApp.UI.ViewModels
{
    public class SimpleMainViewModel : ISimpleMainViewModel
    {
        public IDevice Device { get; set; }
    }
}