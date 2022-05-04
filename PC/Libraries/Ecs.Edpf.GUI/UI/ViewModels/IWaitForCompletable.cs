
namespace Ecs.Edpf.GUI.UI.ViewModels
{

    /// <summary>
    /// An object that can have a two part completion where a background service can be signaled that it can stop and then it can signal when its completed.
    /// </summary>
    public interface IWaitForCompletable
    {

        void BeginCompletion();

        void WaitForCompletion();

    }
}
