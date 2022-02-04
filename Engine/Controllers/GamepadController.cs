using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Homerchu.Engine
{
    sealed class GamepadController : Controller
    {
        public GamepadController()
        {
            _nextState = GamePad.GetState(PlayerIndex.One);
        }
        public override void Update()
        {
            UpdateState();

            foreach (var item in _inputCommands)
                CheckCommandList(item);
        }

        private void UpdateState()
        {
            _lastState = _nextState;
            _nextState = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Determines if an item should be executed based upon the flag criteria.
        /// First takes the flag and verifies it, checks current and last for the given key.
        /// Then it compares the necessary state data to determine if it is correct to execute.
        /// </summary>
        /// <param name="item">Takes in an item pair</param>
        private void CheckCommandList(KeyValuePair<KeyData, ICommand> item)
        {
            var flags = item.Key.Flags;
            if (CheckFlag(flags, KeyFlags.eNone)) return;

            var last = LastDown(item.Key.Key);
            var curr = CurrentDown(item.Key.Key);

            if ((CheckFlag(flags, KeyFlags.ePress)     && curr  && !last) ||
                (CheckFlag(flags, KeyFlags.eHeld)      && curr  &&  last) ||
                (CheckFlag(flags, KeyFlags.eReleased)  && last  && !curr) ||
                (CheckFlag(flags, KeyFlags.eUntouched) && !last && !curr)
                )
                item.Value.Execute();
        }


        private bool CheckFlag(KeyFlags a, KeyFlags b) => (a & b) != 0;
        private bool LastDown(int key) => _lastState.IsButtonDown((Buttons)key);
        private bool CurrentDown(int key) => _nextState.IsButtonDown((Buttons)key);

        private GamePadState _lastState;
        private GamePadState _nextState;
    }
}
