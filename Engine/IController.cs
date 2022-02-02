namespace Homerchu.Engine
{
    /// <summary>
    /// IController is the interface for a Controller object which can accept commands and invokes them given a criteria.
    /// This criteria is typically a system input event, and the IController acts as the Invoker for a give ICommand.
    /// These commands can be dynamically mapped as needed for gameplay usage.
    /// </summary>
    interface IController
    {
        /// <summary>
        /// Updates a given controller to check for criteria to invoke commands.
        /// </summary>
        void Update();

        /// <summary>
        /// Add a command to a list of command-key pairs
        /// </summary>
        /// <param name="key">Key or Input code to check for.</param>
        /// <param name="command">Command to be invoked upon sufficient criteria.</param>
        void AddCommand(int key, ICommand command);

        /// <summary>
        /// Removes a single command from a list of command-key pairs
        /// </summary>
        /// <param name="key">Key or Input code to search for and remove if found.</param>
        void RemoveCommand(int key);

        /// <summary>
        /// Clears all stored command-key pair bindings and resets to a default state.
        /// </summary>
        void ClearCommands();
    }
}
