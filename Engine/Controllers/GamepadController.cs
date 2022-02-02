using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        private void CheckCommandList(System.Collections.Generic.KeyValuePair<int, ICommand> item)
        {
            if (_lastState.IsButtonDown((Buttons)item.Key)) return;

            if (_nextState.IsButtonDown((Buttons)item.Key))
                item.Value.Execute();
        }
        private GamePadState _lastState;
        private GamePadState _nextState;
    }
}
