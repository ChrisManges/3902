using Homerchu.Engine;
using Microsoft.Xna.Framework;

namespace Homerchu.Mario
{
    class StaticCommand : Command<MarioGame>
    {
        public StaticCommand(MarioGame game) : base(game) { }
        public override void Execute() => _receiver.SetStatic();
    }
}
