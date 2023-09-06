
namespace Assets.Scripts.Battlefield.Data.StateMachine
{
    public abstract class StateMachineState
    {
        /// <summary>
        /// The name
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Enters this instance.
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// Ticks this instance.
        /// </summary>
        public abstract void Tick();

        /// <summary>
        /// Exits this instance.
        /// </summary>
        public abstract void Exit();
    }
}
