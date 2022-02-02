using Homerchu.Engine;
using Microsoft.Xna.Framework;

namespace Homerchu.Mario
{
    class MoveCommand : Command<MarioGame>
    {
        public MoveCommand(MarioGame game) : base(game) { }
        public override void Execute() => _receiver.SetMove();
    }
}
