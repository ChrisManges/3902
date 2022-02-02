using Microsoft.Xna.Framework;

namespace Homerchu.Engine
{
    class StaticCommand : Command<Game1>
    {
        public StaticCommand(Game1 game) : base(game) { }
        public override void Execute() => _receiver.SetStatic();
    }
}
