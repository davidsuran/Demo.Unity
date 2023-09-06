namespace Demo.Data.ObserverArguments
{
    public class ActionPointsArguments : IObserverArguments
    {
        /// <summary>
        /// Gets the current action points.
        /// </summary>
        /// <value>
        /// The current action points.
        /// </value>
        public float CurrentActionPoints { get => _currentActionPoints; }
        private float _currentActionPoints;

        /// <summary>
        /// Gets the maximum action points.
        /// </summary>
        /// <value>
        /// The maximum action points.
        /// </value>
        public float MaximumActionPoints { get => _maximumActionPoints; }
        private float _maximumActionPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionPointsArguments"/> class.
        /// </summary>
        /// <param name="currentActionPoints">The current action points.</param>
        /// <param name="maximumActionPoints">The maximum action points.</param>
        public ActionPointsArguments(float currentActionPoints, float maximumActionPoints)
        {
            _currentActionPoints = currentActionPoints;
            _maximumActionPoints = maximumActionPoints;
        }
    }
}
