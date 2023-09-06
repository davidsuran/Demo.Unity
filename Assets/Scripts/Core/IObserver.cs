using Demo.Data.ObserverArguments;

namespace Assets.Scripts.Core
{
    public interface IObserver
    {
        public void OnNotify(IObserverArguments args);
    }
}
