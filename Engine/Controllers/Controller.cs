using System.Collections.Generic;

namespace Homerchu.Engine
{
    abstract class Controller : IController
    {
        /// <summary>
        /// Updates a controller object
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Defines a method to add to the dictionary
        /// </summary>
        /// <param name="key">Key value of the pair</param>
        /// <param name="command">Command to be added</param>
        public void AddCommand(KeyData key, ICommand command) => _inputCommands.Add(key, command);

        /// <summary>
        /// Clears all set commands
        /// </summary>
        public void ClearCommands() => _inputCommands.Clear();

        /// <summary>
        /// Removes a single command
        /// </summary>
        /// <param name="key">Key from which to remove</param>
        public void RemoveCommand(KeyData key) => _inputCommands.Remove(key);

        protected Dictionary<KeyData, ICommand> _inputCommands;

        protected Controller()
        {
            _inputCommands = new Dictionary<KeyData, ICommand>();
        }
    }
}
