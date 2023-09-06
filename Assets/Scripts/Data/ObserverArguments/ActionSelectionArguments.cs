namespace Demo.Data.ObserverArguments
{
    public enum ActionSelectionDirection : byte
    {
        None = 0,
        Left = 1,
        Right = 2
    }

    public class ActionSelectionArguments : IObserverArguments
    {
        public ActionSelectionDirection ActionSelectionDirection { get => _actionSelectionDirection; }
        private ActionSelectionDirection _actionSelectionDirection;

        public ActionSelectionArguments(ActionSelectionDirection actionSelectionDirection)
        {
            _actionSelectionDirection = actionSelectionDirection;
        }
    }
}
