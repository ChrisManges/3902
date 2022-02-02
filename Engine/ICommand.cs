namespace Homerchu.Engine
{
    /// <summary>
    /// ICommand is the interface for a Command object with a single method, Execute.
    /// A command can be created and then have its payload executed.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// The payload of the Command which does a single action inside of the function
        /// </summary>
        void Execute();
    }
}
