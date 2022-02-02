namespace Homerchu.Engine
{
    abstract class Command<T> : ICommand
    {
        /// <summary>
        /// Redeclaration to fulfill the ICommand interface - see interface for reference.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Constructor for a command that takes in a receiver as an object. Commands will be executed on said receiver.
        /// </summary>
        /// <param name="receiver"> Receiver to receive a command. </param>
        protected Command(T receiver)
        {
            _receiver = receiver;
        }

        /// <summary>
        /// A generic receiver object
        /// </summary>
        protected T _receiver;
    }
}
