using Microsoft.Xna.Framework;

namespace Homerchu.Engine
{
    class AnimatedCommand : Command<Game1>
    {
        public AnimatedCommand(Game1 game) : base(game) { }
        public override void Execute() => _receiver.SetAnimated();
    }
}
