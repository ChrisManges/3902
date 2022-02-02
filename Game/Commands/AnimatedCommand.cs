using Homerchu.Engine;
using Microsoft.Xna.Framework;

namespace Homerchu.Mario
{
    class AnimatedCommand : Command<MarioGame>
    {
        public AnimatedCommand(MarioGame game) : base(game) { }
        public override void Execute() => _receiver.SetAnimated();
    }
}
