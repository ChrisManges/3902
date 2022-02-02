using Microsoft.Xna.Framework;

namespace Homerchu.Engine
{
    class DynamicCommand : Command<Game1>
    {
        public DynamicCommand(Game1 game) : base(game) { }
        public override void Execute() => _receiver.SetDynamic();
    }
}
