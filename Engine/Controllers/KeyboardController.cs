using Microsoft.Xna.Framework.Input;
using System;

namespace Homerchu.Engine
{
    sealed class KeyboardController : Controller
    {
        public KeyboardController()
        {
            _nextState = Keyboard.GetState();
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
            _nextState = Keyboard.GetState();
        }

        private void CheckCommandList(System.Collections.Generic.KeyValuePair<int, ICommand> item)
        {
            if (_lastState.IsKeyDown((Keys)item.Key)) return;

            if (_nextState.IsKeyDown((Keys)item.Key))
                item.Value.Execute();
        }

        private KeyboardState _lastState;
        private KeyboardState _nextState;
    }
}
