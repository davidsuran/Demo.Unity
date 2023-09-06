namespace Demo.Data.ObserverArguments
{
    public class HealthPointsArguments : IObserverArguments
    {
        /// <summary>
        /// Gets the current health points.
        /// </summary>
        /// <value>
        /// The current health points.
        /// </value>
        public float CurrentHealthPoints { get => _currentHealthPoints; }
        private float _currentHealthPoints;

        /// <summary>
        /// Gets the maximum health points.
        /// </summary>
        /// <value>
        /// The maximum health points.
        /// </value>
        public float MaximumHealthPoints { get => _maximumHealthPoints; }
        private float _maximumHealthPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthPointsArguments"/> class.
        /// </summary>
        /// <param name="currentHealthPoints">The current health points.</param>
        /// <param name="maximumHealthPoints">The maximum health points.</param>
        public HealthPointsArguments(float currentHealthPoints, float maximumHealthPoints)
        {
            _currentHealthPoints = currentHealthPoints;
            _maximumHealthPoints = maximumHealthPoints;
        }
    }
}
